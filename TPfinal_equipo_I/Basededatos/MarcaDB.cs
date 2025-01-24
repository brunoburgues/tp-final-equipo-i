using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
    public class PerfilDB
    {
        public List<Marca> listarMarcas()
        {
            List<Marca> lista = new List<Marca>();
            AccesoBaseDatos datos = new AccesoBaseDatos();
            try
            {
                datos.SetConsulta("Select Id,Descripcion from MARCAS");
                datos.Lectura();
                while (datos.Reader.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)datos.Reader["Id"];
                    marca.Nombre = (string)datos.Reader["Descripcion"];
                    lista.Add(marca);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.CloseConexion(); }
        }
        public void agregar(string nombre)
        {
            AccesoBaseDatos datos = new AccesoBaseDatos();
            try
            {
                datos.SetConsulta("Insert into Marcas(descripcion) values ('" + nombre + "' )");
                datos.Lectura();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                datos.CloseConexion();
            }
        }
        public void editar(Marca marca, string nombre)
        {
            AccesoBaseDatos accesoBaseDatos = new AccesoBaseDatos();
            try
            {
                accesoBaseDatos.SetConsulta("Update MARCAS Set Descripcion = '" + nombre + "' where Id = " + marca.Id.ToString());
                accesoBaseDatos.Lectura();
            }
            catch (Exception ex)
            {

                throw ex;
            }finally
            {
                accesoBaseDatos.CloseConexion();
            }
        }
        public void eliminar(int id)
        {
            AccesoBaseDatos accesoBaseDatos = new AccesoBaseDatos();
            try
            {
                accesoBaseDatos.SetConsulta("Delete Marcas where Id = " + id);
                accesoBaseDatos.Lectura();
            }
            catch (Exception ex)
            {

                throw ex;

            }finally
            {
                accesoBaseDatos.CloseConexion();
            }
        }
    }
}
