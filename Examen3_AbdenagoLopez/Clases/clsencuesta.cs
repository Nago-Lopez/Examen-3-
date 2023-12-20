using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen3_AbdenagoLopez.Clases
{
    public class clsencuesta
    {
        public static int ID { get; set; }
        public static string Nombre { get; set; }

        public static int Edad { get; set; }
        public static string CorreoElectronico { get; set; }


        public clsencuesta(int Id, string nombre, int edad, string Correo)
        {

            ID = Id;
            Nombre = nombre;
            Edad = edad;
            CorreoElectronico = Correo;


        }

        public clsencuesta() { }



        public static int Agregar(string texto, string text3, string text1, string text2)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGARENCUESTA", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", texto));
                    cmd.Parameters.Add(new SqlParameter("@EDAD", text3));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", text1));
                    cmd.Parameters.Add(new SqlParameter("@PARTIDO", text2));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int Borrar(int cod)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRARENCUESTA", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", cod));



                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int Modificar(int cod, string texto, string text1, string text2, string text3)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZARENCUESTA", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", cod));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", texto));
                    cmd.Parameters.Add(new SqlParameter("@EDAD", text1));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", text2));
                    cmd.Parameters.Add(new SqlParameter("@PARTIDO", text3));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
    }
}