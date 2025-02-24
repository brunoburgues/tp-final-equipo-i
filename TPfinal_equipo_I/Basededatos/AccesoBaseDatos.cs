using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Data;

namespace BaseDatos
{
    public class AccesoBaseDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader reader;

        public SqlDataReader Reader { get { return reader; } }

        public AccesoBaseDatos() 
        {
            conexion = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Ventas_Web_DB1;Integrated Security=True;");


            comando = new SqlCommand();
        }

        public void SetConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void Lectura()
        {
            comando.Connection =  conexion;
            try
            {
                conexion.Open();
                reader = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void setearparametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void setearprocedimiento(string sp)
        {
        comando.CommandType= System.Data.CommandType.Text;
            comando.CommandText = sp;
        }
           
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConexion()
        {
            if (reader != null) 
                reader.Close();
            conexion.Close();
        }
        public void setParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public object ListarArticulosSP()
        {
            throw new NotImplementedException();
        }
       

        public void SetParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        

    }
}
