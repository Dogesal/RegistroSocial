﻿using System;
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

        public string AgregarRegistroSocial(RegistroSocialCLS registroSocial)
        {
            string GUARDADO="";
            int idpaciente;
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();
                    SqlTransaction transaction = cn.BeginTransaction();

                    // Agregar Paciente
                    int pacienteId;
                    using (SqlCommand cmdPaciente = new SqlCommand("sp_AddPaciente", cn, transaction))
                    {
                        cmdPaciente.CommandType = CommandType.StoredProcedure;

                        cmdPaciente.Parameters.AddWithValue("@nombre_paciente", registroSocial.paciente.NombrePaciente);
                        cmdPaciente.Parameters.AddWithValue("@DNI", registroSocial.paciente.DNI);
                        cmdPaciente.Parameters.AddWithValue("@edad", registroSocial.paciente.Edad);
                        cmdPaciente.Parameters.AddWithValue("@estado_civil", registroSocial.paciente.EstadoCivil);
                        cmdPaciente.Parameters.AddWithValue("@grado_instruccion", registroSocial.paciente.GradoInstruccion);
                        cmdPaciente.Parameters.AddWithValue("@direccion", registroSocial.paciente.Direccion);
                        cmdPaciente.Parameters.AddWithValue("@celular_paciente", registroSocial.paciente.CelularPaciente);
                        cmdPaciente.Parameters.AddWithValue("@ocupacion", registroSocial.paciente.Ocupacion);
                        cmdPaciente.Parameters.AddWithValue("@num_hijos", registroSocial.paciente.NumHijos);
                        cmdPaciente.Parameters.AddWithValue("@num_hermanos", registroSocial.paciente.NumHermanos);
                        cmdPaciente.Parameters.AddWithValue("@seguro", registroSocial.paciente.Seguro);
                        cmdPaciente.Parameters.AddWithValue("@dx_medico", registroSocial.paciente.DxMedico);

                        // Ejecuta el comando y obtiene el ID del paciente insertado
                        pacienteId = Convert.ToInt32(cmdPaciente.ExecuteScalar());

                        // Asegúrate de que pacienteId sea válido
                        if (pacienteId <= 0)
                        {
                            
                            throw new Exception("Error al insertar paciente: ID no válido. Datos del paciente: " + pacienteId); 
                        }
                        idpaciente = pacienteId;
                        GUARDADO = "PACIENTE GUARDADO ";
                    }

                    // Agregar Datos Generales
                    int datosGeneralesId;
                    using (SqlCommand cmdDatosGenerales = new SqlCommand("sp_AddDatosGenerales", cn, transaction))
                    {
                        cmdDatosGenerales.CommandType = CommandType.StoredProcedure;

                        cmdDatosGenerales.Parameters.AddWithValue("@ID_paciente", pacienteId);
                        cmdDatosGenerales.Parameters.AddWithValue("@fecha_aplicacion", registroSocial.datos.FechaAplicacion);
                        cmdDatosGenerales.Parameters.AddWithValue("@fecha_ingreso", registroSocial.datos.FechaIngreso);
                        cmdDatosGenerales.Parameters.AddWithValue("@servicio", registroSocial.datos.Servicio);
                        cmdDatosGenerales.Parameters.AddWithValue("@cama", registroSocial.datos.Cama);
                        cmdDatosGenerales.Parameters.AddWithValue("@modalidad_ingreso", registroSocial.datos.ModalidadIngreso);
                        cmdDatosGenerales.Parameters.AddWithValue("@tipo_familia", registroSocial.datos.TipoFamilia);
                        cmdDatosGenerales.Parameters.AddWithValue("@observaciones_familia", registroSocial.datos.ObservacionesFamilia);
                        cmdDatosGenerales.Parameters.AddWithValue("@acciones_realizadas", registroSocial.datos.AccionesRealizadas);
                        cmdDatosGenerales.Parameters.AddWithValue("@diagnostico_social", registroSocial.datos.DiagnosticoSocial);

                        // Ejecuta el comando y obtiene el ID de datos generales insertado
                        try
                        {
                            datosGeneralesId = Convert.ToInt32(cmdDatosGenerales.ExecuteScalar());
                        }
                        catch (Exception ex)
                        {
                            // Guarda el error en un log o envía un mensaje detallado
                            throw new Exception($"Error en la inserción de Datos Generales: {ex.Message}");
                        }

                        GUARDADO += "DATOS GENERALES GUARDADOS";
                    }

                    // Agregar cada Responsable si existen en la lista
                    if (registroSocial.responsables != null && registroSocial.responsables.Count > 0)
                    {
                        int cont = 0;
                        foreach (var responsable in registroSocial.responsables)
                        {

                            using (SqlCommand cmdResponsable = new SqlCommand("sp_AddResponsable", cn, transaction))
                            {
                                cmdResponsable.CommandType = CommandType.StoredProcedure;

                                cmdResponsable.Parameters.AddWithValue("@ID_paciente", pacienteId);
                                cmdResponsable.Parameters.AddWithValue("@nombre_responsable", responsable.NombreResponsable);
                                cmdResponsable.Parameters.AddWithValue("@edad", responsable.Edad);
                                cmdResponsable.Parameters.AddWithValue("@DNI", responsable.DNI);
                                cmdResponsable.Parameters.AddWithValue("@ocupacion", responsable.Ocupacion);
                                cmdResponsable.Parameters.AddWithValue("@parentesco", responsable.Parentesco);
                                cmdResponsable.Parameters.AddWithValue("@celular_responsable", responsable.CelularResponsable);
                                cmdResponsable.Parameters.AddWithValue("@grado_instruccion", responsable.GradoInstruccion);

                                cmdResponsable.ExecuteNonQuery();
                                cont ++ ;
                                GUARDADO += "Res"+ cont;
                            }
                        }
                    }

                    // Confirma la transacción
                    transaction.Commit();
                    return GUARDADO;
                }
                catch (Exception e)
                {

                    return "Error al guardar el registro. " + e.Message + "\n" + e.StackTrace;
                }
            }
        }


    }
}
