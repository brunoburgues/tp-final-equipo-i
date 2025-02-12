using BaseDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basededatos
{
    public class CarritoDB
    {
        public List<Carrito> ListarArticulos(int id)
        {
            List<Carrito> lista = new List<Carrito>();
            AccesoBaseDatos db = new AccesoBaseDatos();
            try
            {
                db.SetConsulta("SELECT  cp.Id AS CarritoProductoId, cp.IdCarrito, cp.IdArticulo, cp.Cantidad, a.Nombre, a.Precio, (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = a.Id) AS ImagenUrl FROM CARRITO_PRODUCTOS cp INNER JOIN ARTICULOS a ON cp.IdArticulo = a.Id WHERE cp.IdCarrito = @IdCarrito");
                db.setearparametros("IdCarrito", id);
                db.Lectura();
                while (db.Reader.Read())
                {
                    Carrito auxA = new Carrito();
                    auxA.Id = (int)db.Reader["CarritoProductoId"];
                    auxA.IdCarrito = (int)db.Reader["IdCarrito"];
                    auxA.IdArticulo = (int)db.Reader["IdArticulo"];
                    auxA.Cantidad= (int)db.Reader["Cantidad"];
                    auxA.Nombre= (string)db.Reader["Nombre"];
                    auxA.Precio = (decimal)db.Reader["Precio"];
                    auxA.ImagenUrl= (string)db.Reader["ImagenUrl"];
                    

                    lista.Add(auxA);
                }
                return lista;
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
        public void actualizarCantidad(int idCarrito, int idArticulo, int cantidad)
        {
            AccesoBaseDatos datos = new AccesoBaseDatos();
            try
            {
                datos.SetConsulta("update CARRITO_PRODUCTOS set Cantidad = @cantidad where IdCarrito = @idCarrito AND IdArticulo = @idArticulo ");
                datos.setParametro("@idCarrito", idCarrito);
                datos.setParametro("@idArticulo", idArticulo);
                datos.setParametro("@cantidad", cantidad);
                
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.CloseConexion(); }
        }

        public void eliminar(int id)
        {
            AccesoBaseDatos datos = new AccesoBaseDatos();
            try
            {
                datos.SetConsulta("delete from CARRITO_PRODUCTOS where id = @id");
                datos.setearparametros("@id", id);
                datos.ejecutarAccion();
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
