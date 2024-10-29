window.onload = function () {

    //listarPacientes();
    listarRegistros();
    
};

function listarRegistros() {

    pintar({
        url: "RegistroSocial/registroSocial",
        id: "tablaBusquedaRegistro",
        cabezeras: ["ID Paciente", "Fecha Aplicación", "Fecha Ingreso", "Servicio", "Cama", "Modalidad Ingreso", "Tipo Familia", "Observaciones Familia", "Acciones Realizadas", "Diagnóstico Social"],
        propiedades: ["IDPaciente", "FechaAplicacion", "FechaIngreso", "Servicio", "Cama", "ModalidadIngreso", "TipoFamilia", "ObservacionesFamilia", "AccionesRealizadas", "DiagnosticoSocial"]
    }, {    

            buscar: true,
            id: "filtrarRegistro",
            placeholder: "Buscar Registro",
            url: "RegistroSocial/filtrarregistroSocial",
            parametro: "parametro"

        });



}


//function listarPacientes() {

//    pintar({
//        url: "RegistroSocial/pacientes",
//        id: "tablaBusquedaPaciente",
//        cabezeras: [
//            "IDPaciente",
//            "Nombre Paciente",
//            "DNI",
//            "Edad"
//        ],
//        propiedades: [
//            "IDPaciente",
//            "NombrePaciente",
//            "DNI",
//            "Edad"
//        ]
//    })
//}
