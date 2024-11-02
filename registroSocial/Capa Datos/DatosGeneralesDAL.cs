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
    public class DatosGeneralesDAL:CadenaDAL
    {
        public List<DatosGeneralesCLS> listarRegistroSocial()
{
    List<DatosGeneralesCLS> lista = null;

            

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerDatosGenerales", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {
                            lista = new List<DatosGeneralesCLS>();

                            while (drd.Read())
                            {
                                DatosGeneralesCLS registro = new DatosGeneralesCLS();

                                // Asignación de columnas a las propiedades de RegistroSocialCLS
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

        public int agregarDatosGenerales(DatosGeneralesCLS datosGenerales)
        {
            int filasAfectadas = 0;

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_AddDatosGenerales", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agrega todos los parámetros necesarios para el procedimiento "sp_AddDatosGenerales"
                        cmd.Parameters.AddWithValue("@ID_paciente", datosGenerales.IDPaciente);
                        cmd.Parameters.AddWithValue("@fecha_aplicacion", datosGenerales.FechaAplicacion);
                        cmd.Parameters.AddWithValue("@fecha_ingreso", datosGenerales.FechaIngreso);
                        cmd.Parameters.AddWithValue("@servicio", datosGenerales.Servicio);
                        cmd.Parameters.AddWithValue("@cama", datosGenerales.Cama);
                        cmd.Parameters.AddWithValue("@modalidad_ingreso", datosGenerales.ModalidadIngreso);
                        cmd.Parameters.AddWithValue("@tipo_familia", datosGenerales.TipoFamilia);
                        cmd.Parameters.AddWithValue("@observaciones_familia", datosGenerales.ObservacionesFamilia);
                        cmd.Parameters.AddWithValue("@acciones_realizadas", datosGenerales.AccionesRealizadas);
                        cmd.Parameters.AddWithValue("@diagnostico_social", datosGenerales.DiagnosticoSocial);

                        // Ejecuta el comando sin esperar un resultado de lectura
                        filasAfectadas=cmd.ExecuteNonQuery();
                    }

                    cn.Close();
                    return filasAfectadas;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    return filasAfectadas;
                }
            }
        }

        public int editarDatosGenerales(DatosGeneralesCLS datosGenerales)
        {

            int filasAfectadas = 0;

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_EditDatosGenerales", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agrega los parámetros necesarios para el procedimiento "sp_EditDatosGenerales"
                        cmd.Parameters.AddWithValue("@id", datosGenerales.IDRegistroSocial);
                        cmd.Parameters.AddWithValue("@ID_paciente", datosGenerales.IDPaciente);
                        cmd.Parameters.AddWithValue("@fecha_aplicacion", datosGenerales.FechaAplicacion);
                        cmd.Parameters.AddWithValue("@fecha_ingreso", datosGenerales.FechaIngreso);
                        cmd.Parameters.AddWithValue("@servicio", datosGenerales.Servicio);
                        cmd.Parameters.AddWithValue("@cama", datosGenerales.Cama);
                        cmd.Parameters.AddWithValue("@modalidad_ingreso", datosGenerales.ModalidadIngreso);
                        cmd.Parameters.AddWithValue("@tipo_familia", datosGenerales.TipoFamilia);
                        cmd.Parameters.AddWithValue("@observaciones_familia", datosGenerales.ObservacionesFamilia);
                        cmd.Parameters.AddWithValue("@acciones_realizadas", datosGenerales.AccionesRealizadas);
                        cmd.Parameters.AddWithValue("@diagnostico_social", datosGenerales.DiagnosticoSocial);

                        // Ejecuta el comando para actualizar el registro
                        filasAfectadas=cmd.ExecuteNonQuery();
                    }

                    cn.Close();
                    return filasAfectadas;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    return filasAfectadas;
                }
            }
        }


        public List<DatosGeneralesCLS> filtrarRegistroSocial(string parametro)
        {
            List<DatosGeneralesCLS> lista = null;



            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("spFiltrarDatosGenerales", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@parametro", parametro);
                        SqlDataReader drd = cmd.ExecuteReader();


                        if (drd != null)
                        {
                            lista = new List<DatosGeneralesCLS>();

                            while (drd.Read())
                            {
                                DatosGeneralesCLS registro = new DatosGeneralesCLS();

                                // Asignación de columnas a las propiedades de RegistroSocialCLS
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
