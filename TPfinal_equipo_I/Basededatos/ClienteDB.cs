using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace BaseDatos
{
    public class ClienteDB
    {
        public List<Cliente> ListarClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            AccesoBaseDatos db = new AccesoBaseDatos();
            try
            {
                db.SetConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes");
                db.Lectura();
                while (db.Reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = (int)db.Reader["Id"];
                    cliente.Documento = (string)db.Reader["Documento"];
                    cliente.Nombre = (string)db.Reader["Nombre"];
                    cliente.Apellido = (string)db.Reader["Apellido"];
                    cliente.Email = (string)db.Reader["Email"];
                    cliente.Direccion = (string)db.Reader["Direccion"];
                    cliente.Ciudad = (string)db.Reader["Ciudad"];
                    cliente.CP = (int)db.Reader["CP"];
                    listaClientes.Add(cliente);
                }
                return listaClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.CloseConexion();
            }
        }

        public void agregar(Cliente nuevo)
        {
            AccesoBaseDatos datos = new AccesoBaseDatos();
            try
            {
                datos.SetConsulta("Insert into Clientes values ('" + nuevo.Id + "', '" + nuevo.Documento + "', '" + nuevo.Nombre + "', " + nuevo.Apellido + ", " + nuevo.Email + ", " + nuevo.Direccion + ", " + nuevo.Ciudad + ", " + nuevo.CP + ")");
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
    }
}
