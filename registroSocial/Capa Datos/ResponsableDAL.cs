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

        public List<ResponsableCLS> listarRegistroSocial()
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
                                registro.NombreResponsable = drd["edad"] != DBNull.Value ? drd["edad"].ToString() : "";
                                registro.Edad = drd["DNI"] != DBNull.Value ? (int)drd["DNI"] : 0;
                                registro.DNI = drd["ocupacion"] != DBNull.Value ? drd["ocupacion"].ToString() : "";
                                registro.Ocupacion = drd["cama"] != DBNull.Value ? drd["cama"].ToString() : "";
                                registro.Parentesco = drd["modalidad_ingreso"] != DBNull.Value ? drd["modalidad_ingreso"].ToString() : "";
                                registro.CelularResponsable = drd["tipo_familia"] != DBNull.Value ? drd["tipo_familia"].ToString() : "";
                                registro.GradoInstruccion = drd["observaciones_familia"] != DBNull.Value ? drd["observaciones_familia"].ToString() : "";
                                
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
