using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class RegistroSocialDAL:CadenaDAL
    {

        public RegistroSocialCLS RegistroSocial(int id)
        {

            RegistroSocialCLS registroSocial = new RegistroSocialCLS(); ;

            
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();


                    using (SqlCommand cmd = new SqlCommand("sp_datosGeneralesXid", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id",id);
                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {
                            

                            while (drd.Read())
                            {


                                // Asignación de columnas a las propiedades de RegistroSocialCLS
                                DatosGeneralesCLS registro = new DatosGeneralesCLS();


                                registro.IDRegistroSocial = drd["ID_datos_generales"] != DBNull.Value ? (int)drd["ID_datos_generales"] : 0;
                                registro.IDPaciente = drd["ID_paciente"] != DBNull.Value ? (int)drd["ID_paciente"] : 0;
                                registro.FechaAplicacion = drd["fecha_aplicacion"] != DBNull.Value ? (DateTime)drd["fecha_aplicacion"] : DateTime.MinValue;
                                registro.FechaIngreso = drd["fecha_ingreso"] != DBNull.Value ? (DateTime)drd["fecha_ingreso"] : DateTime.MinValue;
                                registro.Servicio = drd["servicio"] != DBNull.Value ? drd["servicio"].ToString() : "";
                                registro.Cama = drd["cama"] != DBNull.Value ? drd["cama"].ToString() : "";
                                registro.ModalidadIngreso = drd["modalidad_ingreso"] != DBNull.Value ? drd["modalidad_ingreso"].ToString() : "";
                                registro.TipoFamilia = drd["tipo_familia"] != DBNull.Value ? drd["tipo_familia"].ToString() : "";
                                registro.ObservacionesFamilia = drd["observaciones_familia"] != DBNull.Value ? drd["observaciones_familia"].ToString() : "";
                                registro.AccionesRealizadas = drd["acciones_realizadas"] != DBNull.Value ? drd["acciones_realizadas"].ToString() : "";
                                registro.DiagnosticoSocial = drd["diagnostico_social"] != DBNull.Value ? drd["diagnostico_social"].ToString() : "";

                                registroSocial.datos = registro;

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

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();


                    using (SqlCommand cmd = new SqlCommand("sp_pacienteXIDdatosGenerales", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {


                            while (drd.Read())
                            {


                                // Asignación de columnas a las propiedades de RegistroSocialCLS
                                PacienteCLS registro = new PacienteCLS();


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


                                registroSocial.paciente = registro;

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


            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();

                    List<ResponsableCLS> listaResponsables = new List<ResponsableCLS>();

                    using (SqlCommand cmd = new SqlCommand("sp_responsablesxIDdatosGenerales", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {


                            while (drd.Read())
                            {


                                // Asignación de columnas a las propiedades de RegistroSocialCLS
                                ResponsableCLS registro = new ResponsableCLS();

                                // Asignación de columnas a las propiedades de RegistroSocialCLS

                                registro.IDPaciente = drd["ID_responsable"] != DBNull.Value ? (int)drd["ID_responsable"] : 0;
                                registro.IDPaciente = drd["ID_paciente"] != DBNull.Value ? (int)drd["ID_paciente"] : 0;
                                registro.NombreResponsable = drd["nombre_responsable"] != DBNull.Value ? drd["nombre_responsable"].ToString() : "";
                                registro.Edad = drd["edad"] != DBNull.Value ? (int)drd["edad"] : 0;
                                registro.DNI = drd["DNI"] != DBNull.Value ? drd["DNI"].ToString() : "";
                                registro.Ocupacion = drd["ocupacion"] != DBNull.Value ? drd["ocupacion"].ToString() : "";
                                registro.Parentesco = drd["parentesco"] != DBNull.Value ? drd["parentesco"].ToString() : "";
                                registro.CelularResponsable = drd["celular_responsable"] != DBNull.Value ? drd["celular_responsable"].ToString() : "";
                                registro.GradoInstruccion = drd["grado_instruccion"] != DBNull.Value ? drd["grado_instruccion"].ToString() : "";

                                // Agregar el registro a la lista
                                listaResponsables.Add(registro);


                               

                            }
                            registroSocial.responsables = listaResponsables;
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



            return registroSocial;





        }

    }
}
