using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Negocio;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Capa_Datos
{
    public class RegistroSocialDAL:CadenaDAL
    {
        private readonly EstadoContextDAL _contextEstado;
        private readonly ServicioContextDAL _contextServicio;

        public RegistroSocialDAL(EstadoContextDAL contextEstado, ServicioContextDAL contextServicio)
        {
            _contextEstado = contextEstado;
            _contextServicio = contextServicio;
        }

   

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
                            ServicioCLS servicio = new ServicioCLS();
                            EstadoCLS estado = new EstadoCLS();
                            while (drd.Read())
                            {


                                // Asignación de columnas a las propiedades de RegistroSocialCLS
                                DatosGeneralesCLS registro = new DatosGeneralesCLS();
                                

                                registro.IDRegistroSocial = drd["ID_datos_generales"] != DBNull.Value ? (int)drd["ID_datos_generales"] : 0;
                                registro.IDPaciente = drd["ID_paciente"] != DBNull.Value ? (int)drd["ID_paciente"] : 0;
                                registro.FechaAplicacion = drd["fecha_aplicacion"] != DBNull.Value
                                 ? ((DateTime)drd["fecha_aplicacion"]).ToString("dd-MM-yyyy")
                                 : DateTime.MinValue.ToString("dd-MM-yyyy");

                                registro.FechaIngreso = drd["fecha_ingreso"] != DBNull.Value
                                    ? ((DateTime)drd["fecha_ingreso"]).ToString("dd-MM-yyyy")
                                    : DateTime.MinValue.ToString("dd-MM-yyyy");


                                try
                                {
                                    servicio = _contextServicio.servicios.Find(drd["ID_servicio"]);
                                    registroSocial.servicio = servicio;

                                    estado = _contextEstado.estado.Find(drd["ID_estado"]);
                                    registroSocial.estado = estado;
                                }
                                catch (Exception e)
                                {
                                    
                                    throw new Exception(e.Message);
                                }

                                

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

                                registro.IDResponsable = drd["ID_responsable"] != DBNull.Value ? (int)drd["ID_responsable"] : 0;
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
            EstadoCLS estadoCLS;
            ServicioCLS servicioCLS;


            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();
                    SqlTransaction transaction = cn.BeginTransaction();

                   

                    EstadoBL estadoBL = new EstadoBL(_contextEstado);
                    ServiciosBL servicioBL = new ServiciosBL(_contextServicio);
                    try
                    {

                        estadoCLS = _contextEstado.estado
                                     .FirstOrDefault(e => e.nombre == registroSocial.estado.nombre);

                        if (estadoCLS == null)
                        {
                            // Si no se encuentra ningún estado, lanzar una excepción con un mensaje más específico
                            throw new Exception($"No se encontró un estado con el nombre '{registroSocial.estado.nombre}'.");
                        }
                     

                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }


                    try
                    {


                        servicioCLS = _contextServicio.servicios
                                     .FirstOrDefault(e => e.nombre == registroSocial.servicio.nombre);

                        if (estadoCLS == null)
                        {
                            // Si no se encuentra ningún estado, lanzar una excepción con un mensaje más específico
                            throw new Exception($"No se encontró un estado con el nombre '{registroSocial.servicio.nombre}'.");
                        }

                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }





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
                        cmdDatosGenerales.Parameters.AddWithValue("@ID_servicio", estadoCLS.ID_estado);
                        cmdDatosGenerales.Parameters.AddWithValue("@ID_estado", servicioCLS.ID_servicio);
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
                                GUARDADO += "Res:"+ responsable.GradoInstruccion + cont;
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

        public int EliminarRegistroSocial(int id)
        {
            int filasAfectadas = 0;

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmdPaciente = new SqlCommand("spEliminarPacientePorDatosGenerales", cn))
                    {
                        cmdPaciente.CommandType = CommandType.StoredProcedure;
                        cmdPaciente.Parameters.AddWithValue("@id_datos_generales",id);
                        filasAfectadas = cmdPaciente.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    // Manejo de errores
                    filasAfectadas = -1; 
                }
            }

            return filasAfectadas;
        }

        public string EditarRegistroSocial(int id, RegistroSocialCLS registroSocialR)
        {
            int filas = 0;
            StringBuilder errores = new StringBuilder();

            //try {

            //    ServicioCLS servicio = _contextServicio.servicios.FirstOrDefault(e => e.nombre == registroSocialR.servicio.nombre);

            //}

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                cn.Open();
                SqlTransaction transaction = cn.BeginTransaction();

                try
                {
                    // 1. Modificar datos del paciente
                    using (SqlCommand cmd = new SqlCommand("EditarPacienteXIDdatosGenerales", cn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_datos_generales", id);
                        cmd.Parameters.AddWithValue("@Nombre", registroSocialR.paciente.NombrePaciente);
                        cmd.Parameters.AddWithValue("@DNI", registroSocialR.paciente.DNI);
                        cmd.Parameters.AddWithValue("@Edad", registroSocialR.paciente.Edad);
                        cmd.Parameters.AddWithValue("@EstadoCivil", registroSocialR.paciente.EstadoCivil);
                        cmd.Parameters.AddWithValue("@GradoInstruccion", registroSocialR.paciente.GradoInstruccion);
                        cmd.Parameters.AddWithValue("@Direccion", registroSocialR.paciente.Direccion);
                        cmd.Parameters.AddWithValue("@Celular", registroSocialR.paciente.CelularPaciente);
                        cmd.Parameters.AddWithValue("@Ocupacion", registroSocialR.paciente.Ocupacion);
                        cmd.Parameters.AddWithValue("@NumHijos", registroSocialR.paciente.NumHijos);
                        cmd.Parameters.AddWithValue("@NumHermanos", registroSocialR.paciente.NumHermanos);
                        cmd.Parameters.AddWithValue("@Seguro", registroSocialR.paciente.Seguro);
                        cmd.Parameters.AddWithValue("@DxMedico", registroSocialR.paciente.DxMedico);

                        try
                        {
                            filas += cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            errores.AppendLine("Error al modificar datos del paciente: " + e.Message);
                        }
                    }

                    // 2. Modificar datos generales
                    using (SqlCommand cmd = new SqlCommand("sp_EditDatosGenerales", cn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@fecha_aplicacion", registroSocialR.datos.FechaAplicacion);
                        cmd.Parameters.AddWithValue("@fecha_ingreso", registroSocialR.datos.FechaIngreso);
                        cmd.Parameters.AddWithValue("@ID_servicio", registroSocialR.servicio.ID_servicio);
                        cmd.Parameters.AddWithValue("@ID_estado", registroSocialR.estado.ID_estado);
                        cmd.Parameters.AddWithValue("@cama", registroSocialR.datos.Cama);
                        cmd.Parameters.AddWithValue("@modalidad_ingreso", registroSocialR.datos.ModalidadIngreso);
                        cmd.Parameters.AddWithValue("@tipo_familia", registroSocialR.datos.TipoFamilia);
                        cmd.Parameters.AddWithValue("@observaciones_familia", registroSocialR.datos.ObservacionesFamilia);
                        cmd.Parameters.AddWithValue("@acciones_realizadas", registroSocialR.datos.AccionesRealizadas);
                        cmd.Parameters.AddWithValue("@diagnostico_social", registroSocialR.datos.DiagnosticoSocial);

                        try
                        {
                            filas += cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            errores.AppendLine("Error al modificar datos generales: " + e.Message);
                        }
                    }

                    // 3. Modificar datos de responsables
                    if (registroSocialR.responsables != null)
                    {
                        foreach (var responsable in registroSocialR.responsables)
                        {
                            using (SqlCommand cmd = new SqlCommand("EditarResponsableXIDdatosGenerales", cn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@ID_datos_generales", id);
                                cmd.Parameters.AddWithValue("@Nombre", responsable.NombreResponsable);
                                cmd.Parameters.AddWithValue("@edad", responsable.Edad);
                                cmd.Parameters.AddWithValue("@DNI", responsable.DNI);
                                cmd.Parameters.AddWithValue("@Ocupacion", responsable.Ocupacion);
                                cmd.Parameters.AddWithValue("@Parentesco", responsable.Parentesco);
                                cmd.Parameters.AddWithValue("@Celular", responsable.CelularResponsable);
                                cmd.Parameters.AddWithValue("@GradoInstruccion", responsable.GradoInstruccion);

                                try
                                {
                                    filas += cmd.ExecuteNonQuery();
                                }
                                catch (Exception e)
                                {
                                    errores.AppendLine($"Error al modificar datos del responsable {responsable.NombreResponsable}: " + e.Message);
                                }
                            }
                        }
                    }
                    // Confirmar la transacción si todas las operaciones son exitosas
                    if (errores.Length == 0)
                    {
                        transaction.Commit();
                        return $"Se han actualizado {filas} registros correctamente.";
                    }
                    else
                    {
                        // Revertir la transacción en caso de errores
                        transaction.Rollback();
                        return "Se encontraron errores: " + errores.ToString();
                    }
                }
                catch (Exception e)
                {
                    // Revertir la transacción en caso de error crítico
                    transaction.Rollback();
                    return "Error crítico: " + e.Message;
                }
                finally
                {
                    cn.Close();
                }
            }
        }



    }
}
