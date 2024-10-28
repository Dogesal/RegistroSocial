using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capa_Entidad;

namespace Capa_Datos
{
    public class PacienteDAL:CadenaDAL
    {

        public List<PacienteCLS> listarPaciente()
        {
            List<PacienteCLS> lista = null;


            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerDatosPacientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {
                            lista = new List<PacienteCLS>();

                            while (drd.Read())
                            {
                                PacienteCLS registro = new PacienteCLS();

                                // Asignación de columnas a las propiedades de RegistroSocialCLS

                                registro.IDPaciente = drd["ID_paciente"] != DBNull.Value ? (int)drd["ID_paciente"] : 0;
                                registro.NombrePaciente = drd["nombre_paciente"] != DBNull.Value ? drd["nombre_paciente"].ToString() : "";
                                registro.DNI = drd["DNI"] != DBNull.Value ? drd["DNI"].ToString() : "";
                                registro.Edad = drd["edad"] != DBNull.Value ? Convert.ToInt32(drd["edad"]) : 0;
                                registro.EstadoCivil = drd["estado_civil"] != DBNull.Value ? drd["estado_civil"].ToString() : "";
                                registro.GradoInstruccion = drd["grado_instruccion"] != DBNull.Value ? drd["grado_instruccion"].ToString() : "";
                                registro.Direccion = drd["direccion"] != DBNull.Value ? drd["direccion"].ToString() : "";
                                registro.CelularPaciente = drd["celular_paciente"] != DBNull.Value ? drd["celular_paciente"].ToString() : "";
                                registro.Ocupacion = drd["ocupacion"] != DBNull.Value ? drd["ocupacion"].ToString() : "";
                                registro.NumHijos = drd["num_hijos"] != DBNull.Value ? Convert.ToInt32(drd["num_hijos"]) : 0;
                                registro.NumHermanos = drd["num_hermanos"] != DBNull.Value ? Convert.ToInt32(drd["num_hermanos"]) : 0;
                                registro.Seguro = drd["seguro"] != DBNull.Value ? drd["seguro"].ToString() : "";
                                registro.DxMedico = drd["dx_medico"] != DBNull.Value ? drd["dx_medico"].ToString() : "";
                                
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
