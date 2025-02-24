using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseDatos
{
    public class CategoriaDB
    {
        public List<Categoria> listarCategoria()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            AccesoBaseDatos datos = new AccesoBaseDatos(); // Sin using

            try
            {
                datos.SetConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.Lectura();

                while (datos.Reader.Read())
                {
                    Categoria c = new Categoria
                    {
                        Id = datos.Reader.GetInt32(0),
                        Descripcion = datos.Reader.IsDBNull(1) ? "Sin descripción" : datos.Reader.GetString(1)
                    };
                    listaCategorias.Add(c);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en listarCategoria(): " + ex.Message, ex);
            }
            finally
            {
                datos.CloseConexion(); // Cierra la conexión manualmente
            }

            return listaCategorias;
        }

        public List<Categoria> listarCategoria(string ID)
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            AccesoBaseDatos datos = new AccesoBaseDatos();

            try
            {
                string consulta = "SELECT Id, Descripcion FROM CATEGORIAS";

                if (!string.IsNullOrEmpty(ID))
                {
                    consulta += " WHERE Id = @Id";
                }

                datos.SetConsulta(consulta);

                if (!string.IsNullOrEmpty(ID))
                {
                    if (int.TryParse(ID, out int idNumerico))
                    {
                        datos.SetParametro("@Id", idNumerico);
                    }
                    else
                    {
                        throw new Exception("El ID proporcionado no es un número válido.");
                    }
                }

                datos.Lectura();

                while (datos.Reader.Read())
                {
                    Categoria c = new Categoria
                    {
                        Id = (int)datos.Reader["Id"],
                        Descripcion = (string)datos.Reader["Descripcion"]
                    };
                    listaCategorias.Add(c);
                }

                return listaCategorias;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en listarCategoria(): " + ex.Message);
            }
            finally
            {
                datos.CloseConexion();
            }
        }


        public void agregar(Categoria categoria)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Ventas_Web_DB1;Integrated Security=True;"))

                {
                    conexion.Open();
                    string query = "INSERT INTO Categorias (Descripcion) VALUES (@Descripcion)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en agregar(): " + ex.Message);
            }
        }

        public void editar(Categoria categoria, string nombre)
        {
            AccesoBaseDatos accesoBaseDatos = new AccesoBaseDatos();
            try
            {
                accesoBaseDatos.SetConsulta("Update Categorias Set Descripcion = '" + nombre + "' where Id = " + categoria.Id.ToString());
                accesoBaseDatos.Lectura();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoBaseDatos.CloseConexion();
            }
        }
        public void eliminar(int id)
        {
            AccesoBaseDatos accesoBaseDatos = new AccesoBaseDatos();
            try
            {
                accesoBaseDatos.SetConsulta("Delete Categorias where Id = " + id);
                accesoBaseDatos.Lectura();
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                accesoBaseDatos.CloseConexion();
            }
        }
        

       
    }
}
