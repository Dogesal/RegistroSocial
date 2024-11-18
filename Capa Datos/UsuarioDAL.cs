using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
namespace Capa_Datos
{
    public class UsuarioDAL : CadenaDAL
    {

        public int verificarPassword(string usuario, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_verificarContraseña", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Parámetro de salida
                        SqlParameter resultado = new SqlParameter("@Resultado", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(resultado);

                        // Abrir conexión y ejecutar el comando
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        // Retornar el valor del parámetro de salida
                        return (int)resultado.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de excepción específica de SQL
                Console.WriteLine("Error en la base de datos: " + ex.Message);
                return -1; // Valor de retorno para indicar error
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones generales
                Console.WriteLine("Error: " + ex.Message);
                return -1; // Valor de retorno para indicar error
            }
        }

    }
}