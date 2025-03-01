using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using BaseDatos;

namespace Basededatos
{
    public class UsuarioDB
    { public bool Loguear(Usuario usuario)
        {
            AccesoBaseDatos datos = new AccesoBaseDatos();

            try
            {
            datos.SetConsulta("SELECT Id, TipoUser * FROM Usuarios WHERE User = @user AND Pass = @pass");
                datos.setearparametros("@user", usuario.User);
                datos.setearparametros("@pass", usuario.Pass);
                datos.Lectura();
                if (datos.Reader.Read())
                {
                    usuario.Id = (int)datos.Reader["Id"];
                    usuario.tipoUsuario = (bool)datos.Reader["TipoUser"] ? TipoUsuario.Admin : TipoUsuario.Normal;
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception("Error en Loguear(): " + ex.Message, ex);
            }
            finally
            {
                datos.CloseConexion();
            }
        }
    }
}
