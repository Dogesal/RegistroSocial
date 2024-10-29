using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;

namespace Capa_Datos
{
    public class ResponsableDAL:CadenaDAL
    {

        public List<ResponsableCLS> listarResponsable()
        {
            List<ResponsableCLS> lista = null;



            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerResponsables", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {
                            lista = new List<ResponsableCLS>();

                            while (drd.Read())
                            {
                                ResponsableCLS registro = new ResponsableCLS();

                                // Asignación de columnas a las propiedades de RegistroSocialCLS

                                registro.IDPaciente = drd["ID_responsable"] != DBNull.Value ? (int)drd["ID_responsable"] : 0;
                                registro.IDPaciente = drd["ID_paciente"] != DBNull.Value ? (int)drd["ID_paciente"]: 0;
                                registro.NombreResponsable = drd["nombre_responsable"] != DBNull.Value ? drd["nombre_responsable"].ToString() : "";
                                registro.Edad = drd["edad"] != DBNull.Value ? (int)drd["edad"] : 0;
                                registro.DNI = drd["DNI"] != DBNull.Value ? drd["DNI"].ToString() : "";
                                registro.Ocupacion = drd["ocupacion"] != DBNull.Value ? drd["ocupacion"].ToString() : "";
                                registro.Parentesco = drd["parentesco"] != DBNull.Value ? drd["parentesco"].ToString() : "";
                                registro.CelularResponsable = drd["celular_responsable"] != DBNull.Value ? drd["celular_responsable"].ToString() : "";
                                registro.GradoInstruccion = drd["grado_instruccion"] != DBNull.Value ? drd["grado_instruccion"].ToString() : "";
                                
                                // Agregar el registro a la lista
                                lista.Add(registro);
                            }
                        }
                    }

                    cn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    cn.Close();
                }
            }

            return lista;
        }

    }
}
