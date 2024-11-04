
window.onload = function () {

   listarRegistros();
    
};


function Editar(id){

    // Redirige a la vista RegistroSocialVista pasando el ID en la URL
    window.location.href = `/RegistroSocial/RegistroSocialEdit?id=${id}`;

}

function Eliminar(id) {
    ConfirmacionSwing("¿Está seguro de que desea eliminar este registro?", "Confirmación")
        .then((result) => {
            if (result.isConfirmed) {
                // Si el usuario confirma, realizar la eliminación
                fetch(`/RegistroSocial/eliminarRegistroSocial/?id=${id}`)
                    .then(response => {
                        if (response.ok) {
                            // Mostrar el mensaje de éxito después de que se elimine el registro
                            Swal.fire({
                                title: "Borrado!",
                                text: "El registro fue borrado.",
                                icon: "success"
                            });

                            // Recargar la página después de un breve retraso para permitir que el usuario vea el mensaje
                            setTimeout(() => {
                                window.location.reload(); // Recargar la página
                            }, 1500); // 1500 milisegundos (1.5 segundos)
                        } else {
                            ErrorSwing("Error al eliminar el registro.");
                        }
                    })
                    .catch(error => {
                        ErrorSwing("Ocurrió un error de red: " + error.message);
                    });
            } else {
                // Si el usuario cancela, no hacer nada
                console.log("Eliminación cancelada.");
            }
        });
}

function MasInfo(id) {
    // Redirige a la vista RegistroSocialVista pasando el ID en la URL
    window.location.href = `/RegistroSocial/RegistroSocialVista?id=${id}`;
}


function listarRegistros() {

    pintar({
        url: "DatosGenerales/registroSocialPaciente",
        id: "tablaBusquedaRegistro",
        cabezeras: ["Nombre Paciente", "Fecha Aplicación", "Fecha Ingreso", "Servicio", "Cama", "Modalidad Ingreso", "Tipo Familia", "Observaciones Familia", "Acciones Realizadas", "Diagnóstico Social"],
        propiedades: ["nombrePaciente", "FechaAplicacion", "FechaIngreso", "Servicio", "Cama", "ModalidadIngreso", "TipoFamilia", "ObservacionesFamilia", "AccionesRealizadas", "DiagnosticoSocial"],
        editar: true,
        eliminar: true,
        lupa: true,
        propiedadID:"IDRegistroSocial"
    }, {    

            buscar: true,
            id: "filtrarRegistro",
            placeholder: "Buscar Registro",
            url: "DatosGenerales/filtrarregistroSocial",
            parametro: "parametro"

        });



}


