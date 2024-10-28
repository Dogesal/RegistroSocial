
window.onload = function (){

    listarPacientes();

}

function listarPacientes() {

    pintar({
        url: "RegistroSocial/pacientes",
        id: "tablaBusquedaPaciente",
        cabezeras: ["ID Paciente", "Fecha Aplicación", "Fecha Ingreso", "Servicio", "Cama", "Modalidad Ingreso", "Tipo Familia", "Observaciones Familia", "Acciones Realizadas", "Diagnóstico Social"],
        propiedades: ["IDPaciente", "FechaAplicacion", "FechaIngreso", "Servicio", "Cama", "ModalidadIngreso", "TipoFamilia", "ObservacionesFamilia", "AccionesRealizadas", "DiagnosticoSocial"]
    })
}
