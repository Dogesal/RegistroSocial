
window.onload = function () {

   listarRegistros();
    
};


function Editar(id){

    // Redirige a la vista RegistroSocialVista pasando el ID en la URL
    window.location.href = `/RegistroSocial/RegistroSocialEdit?id=${id}`;

}

function Eliminar(id) {
    // Show confirmation dialog
    ConfirmacionSwing("¿Está seguro de que desea eliminar este registro?", "Confirmación")
        .then((result) => {
            if (!result.isConfirmed) {
                console.log("Eliminación cancelada.");
                return;
            }

            // Show authentication modal
            Swal.fire({
                title: 'Autenticación Requerida',
                html:
                    '<div class="login-container">' +
                    '<input type="text" id="usuario" class="swal2-input" placeholder="Usuario">' +
                    '<input type="password" id="password" class="swal2-input" placeholder="Contraseña">' +
                    '</div>',
                confirmButtonText: 'Verificar',
                focusConfirm: false,
                preConfirm: () => {
                    const usuario = Swal.getPopup().querySelector('#usuario').value;
                    const password = Swal.getPopup().querySelector('#password').value;

                    if (!usuario || !password) {
                        Swal.showValidationMessage("Por favor, complete todos los campos");
                    }

                    return { usuario, password };
                }
            }).then((loginResult) => {
                if (!loginResult.isConfirmed) return;

                const { usuario, password } = loginResult.value;

                // Verify credentials with server
                return fetch('/Usuario/verificarPassword', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ usuario, password })
                }).then(response => response.json())
                  .then(data => {
                        if (data === 1) {
                            console.log(data)
                            return fetch(`/RegistroSocial/eliminarRegistroSocial/${id}`);
                        } else {
                            // Invalid credentials
                            Swal.fire("Error", "Usuario o contraseña incorrectos.", "error");
                            throw new Error("Invalid credentials");
                        }
                    })
                    .then(response => {

                        Swal.fire({
                            title: "Borrado!",
                            text: "El registro fue borrado.",
                            icon: "success"
                        });
                        setTimeout(() => {
                            window.location.reload();
                        }, 1500);
                    })
                    .catch(error => {
                        if (error.message !== "Invalid credentials") {
                            Swal.fire("Error", "Ocurrió un error de red: " + error.message, "error");
                        }
                    });
            });
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
        propiedades: ["nombrePaciente", "fechaAplicacion", "fechaIngreso", "servicio", "cama", "modalidadIngreso", "tipoFamilia", "observacionesFamilia", "accionesRealizadas", "diagnosticoSocial"],
        editar: true,
        eliminar: true,
        lupa: true,
        propiedadID:"idRegistroSocial"
    }, {    

            buscar: true,
            id: "filtrarRegistro",
            placeholder: "Buscar Registro",
            url: "DatosGenerales/filtrarregistroSocial",
            parametro: "parametro"

        });



}


