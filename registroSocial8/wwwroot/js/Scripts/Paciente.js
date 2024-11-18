
window.onload = function (){

    listarPacientes();

}

function listarPacientes() {

 
    pintar({
        url: "Paciente/listarPacientes",
        id: "tablaBusquedaPaciente",
        cabezeras: [
            "NombrePaciente",
            "DNI",
            "Edad",
            "EstadoCivil",
            "GradoInstruccion",
            "Direccion",
            "CelularPaciente",
            "Ocupacion",
            "NumHijos",
            "NumHermanos",
            "Seguro",
            "DxMedico"
        ],
        propiedades: [
            "NombrePaciente",
            "DNI",
            "Edad",
            "EstadoCivil",
            "GradoInstruccion",
            "Direccion",
            "CelularPaciente",
            "Ocupacion",
            "NumHijos",
            "NumHermanos",
            "Seguro",
            "DxMedico"
        ]
    }, {
            buscar: true,
            id: "filtrarPaciente",
            placeholder:"Buscar Paciente",
            url: "Paciente/filtrarPacientes",
            parametro:"parametro"

        })

}





