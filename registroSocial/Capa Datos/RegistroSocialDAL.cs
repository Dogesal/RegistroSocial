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
    public class RegistroSocialDAL:CadenaDAL
    {
        public List<RegistroSocialCLS> listarRegistroSocial()
{
    List<RegistroSocialCLS> lista = null;

            

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
                            lista = new List<RegistroSocialCLS>();

                            while (drd.Read())
                            {
                                RegistroSocialCLS registro = new RegistroSocialCLS();

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
//lista.Add(new RegistroSocialCLS
            //{
            //    IDPaciente = 1,
            //    FechaAplicacion = DateTime.Parse("2023-01-01"),
            //    FechaIngreso = DateTime.Parse("2023-01-05"),
            //    Servicio = "Cardiología",
            //    Cama = "A1",
            //    ModalidadIngreso = "Urgencia",
            //    TipoFamilia = "Nuclear",
            //    ObservacionesFamilia = "Familia de apoyo",
            //    AccionesRealizadas = "Orientación",
            //    DiagnosticoSocial = "Buen estado social"
            //}
            //    );

            //lista.Add(new RegistroSocialCLS
            //{
            //    IDPaciente = 2,
            //    FechaAplicacion = DateTime.Parse("2023-02-10"),
            //    FechaIngreso = DateTime.Parse("2023-02-15"),
            //    Servicio = "Neurología",
            //    Cama = "B2",
            //    ModalidadIngreso = "Electivo",
            //    TipoFamilia = "Extendida",
            //    ObservacionesFamilia = "Falta de apoyo económico",
            //    AccionesRealizadas = "Consulta social",
            //    DiagnosticoSocial = "Vulnerabilidad económica"
            //}
            //    );