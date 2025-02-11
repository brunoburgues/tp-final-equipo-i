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
            AccesoBaseDatos datos = new AccesoBaseDatos();

            try
            {
                datos.SetConsulta("select Id, Descripcion from CATEGORIAS");
                datos.Lectura();
                while (datos.Reader.Read())
                {
                    Categoria c = new Categoria();
                    c.Id = (int)datos.Reader["Id"];
                    c.Descripcion = (string)datos.Reader["Descripcion"];
                    listaCategorias.Add(c);
                }
                return listaCategorias;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.CloseConexion(); }
        }
        public List<Categoria> listarCategoria(string ID)
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            AccesoBaseDatos datos = new AccesoBaseDatos();

            try
            {
                datos.SetConsulta("select Id, Descripcion from CATEGORIAS");
                datos.Lectura();
                while (datos.Reader.Read())
                {
                    Categoria c = new Categoria();
                    c.Id = (int)datos.Reader["Id"];
                    c.Descripcion = (string)datos.Reader["Descripcion"];
                    listaCategorias.Add(c);
                }
                return listaCategorias;
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
                datos.SetConsulta("Insert into Categorias (descripcion) values ('" + nombre + "' )");
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
