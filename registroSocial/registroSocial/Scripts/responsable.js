
window.onload = function () {

    listarResponsables();

}

function listarResponsables() {


    pintar({
        url: "/Responsable/listarResponsables", 
        id: "tablaBusquedaResposable",
        cabezeras: [

            "NombreResponsable",
            "Edad",
            "DNI",
            "Ocupacion",
            "Parentesco",
            "CelularResponsable",
            "GradoInstruccion"
        ],
        propiedades: [

            "NombreResponsable",
            "Edad",
            "DNI",
            "Ocupacion",
            "Parentesco",
            "CelularResponsable",
            "GradoInstruccion"
        ]
    })





}
