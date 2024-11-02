async function guardarRegistroSocial() {
    // Crear objeto para enviar
    const registroSocial = {
        paciente: {
            NombrePaciente: document.querySelector('input[name="paciente"]').value,
            DNI: document.querySelector('input[name="dni"]').value,
            Edad: document.querySelector('input[name="edad"]').value,
            EstadoCivil: document.querySelector('select[name="estado_civil"]').value,
            GradoInstruccion: getGradoInstruccion(), // Función para obtener grado de instrucción
            Direccion: document.querySelector('input[name="direccion"]').value,
            CelularPaciente: document.querySelector('input[name="cel_px"]').value,
            Ocupacion: document.querySelector('input[name="ocupacion"]').value,
            NumHijos: document.querySelector('input[name="numero_hijos"]').value,
            NumHermanos: document.querySelector('input[name="numero_hermanos"]').value,
            Seguro: getSeguro(), // Función para obtener seguro
            DxMedico: document.querySelector('input[name="dx_medico"]').value,
        },
        datos: {
            FechaIngreso: document.querySelector('input[name="fecha_ingreso"]').value,
            FechaAplicacion: document.querySelector('input[name="fecha_aplicacion"]').value,
            Servicio: document.querySelector('input[name="servicio"]').value,
            Cama: document.querySelector('input[name="cama"]').value,
            ModalidadIngreso: getModalidadIngreso(), // Función para obtener modalidad de ingreso
            TipoFamilia: getTipoFamilia(), // Función para obtener tipo de familia
            ObservacionesFamilia: document.querySelector('textarea[name="observaciones"]').value,
            DiagnosticoSocial: document.querySelector('textarea[name="diagnostico_social"]').value,
            AccionesRealizadas: getAccionesRealizadas(), // Función para obtener acciones realizadas
        },
        responsables: getResponsables() // Función para obtener responsables
    };

    // **VERIFICA el contenido del objeto antes de enviar**
    console.log(JSON.stringify(registroSocial, null, 2));

    // Enviar datos con fetch
    try {
        const response = await fetch('/RegistroSocial/guardarRegistroSocial', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(registroSocial) // Convertir objeto a JSON
        });

        const result = await response.text();
        alert(result);
    } catch (error) {
        alert("Error al guardar el registro: " + error);
    }
}

// Funciones auxiliares
function getGradoInstruccion() {
    let gradoInstruccion = document.querySelector('select[name="grado_instruccion"]').value;
    const especificarGradoPaciente = document.querySelector('input[name="especificar_grado_paciente"]').value;
    if (especificarGradoPaciente) {
        gradoInstruccion += ` - ${especificarGradoPaciente}`;
    }
    return gradoInstruccion;
}

function getSeguro() {
    let seguro = document.querySelector('select[name="seguro"]').value;
    const especificarSeguroPaciente = document.querySelector('input[name="especificar_seguro_paciente"]').value;
    if (especificarSeguroPaciente) {
        seguro += ` - ${especificarSeguroPaciente}`;
    }
    return seguro;
}

function getModalidadIngreso() {
    let modalidadIngreso = document.querySelector('input[name="modalidad_ingreso"]:checked').value;
    const especificarModalidad = document.querySelector('input[name="especificar_modalidad"]').value;
    if (especificarModalidad) {
        modalidadIngreso += ` - ${especificarModalidad}`;
    }
    return modalidadIngreso;
}

function getTipoFamilia() {
    let tipoFamilia = document.querySelector('input[name="tipo_familia"]:checked').value;
    const especificarTipoFamilia = document.querySelector('input[name="especificar_tipo_familia"]').value;
    if (especificarTipoFamilia) {
        tipoFamilia += ` - ${especificarTipoFamilia}`;
    }
    return tipoFamilia;
}

function getAccionesRealizadas() {
    const accionesSeleccionadas = Array.from(document.querySelectorAll('input[name="acciones_realizadas"]:checked'))
        .map(checkbox => {
            let accion = checkbox.value;

            // Agregar la especificación correspondiente si está disponible
            if (accion === "entrevista") {
                const especificarEntrevista = document.querySelector('input[name="especificar_entrevista"]').value;
                if (especificarEntrevista) {
                    accion += `: ${especificarEntrevista}`;
                }
            } else if (accion === "gestion") {
                const especificarGestion = document.querySelector('input[name="especificar_gestion"]').value;
                if (especificarGestion) {
                    accion += `: ${especificarGestion}`;
                }
            } else if (accion === "otros") {
                const especificarOtros = document.querySelector('input[name="especificar_otros"]').value;
                if (especificarOtros) {
                    accion += `: ${especificarOtros}`;
                }
            }

            return accion;
        })
        .join(', ');

    return accionesSeleccionadas;
}

function getResponsables() {
    const responsables = [];
    document.querySelectorAll('#responsables-container .responsable').forEach(responsableEl => {
        const nombreResponsable = responsableEl.querySelector('input[name="nombre_r[]"]').value;
        const edad = responsableEl.querySelector('input[name="edad_r[]"]').value;
        const dni = responsableEl.querySelector('input[name="dni_r[]"]').value;
        const ocupacion = responsableEl.querySelector('input[name="ocupacion_r[]"]').value;
        const parentesco = responsableEl.querySelector('input[name="parentesco_r[]"]').value;
        const celularResponsable = responsableEl.querySelector('input[name="celular_r[]"]').value;

        // Grado de Instrucción para Responsable con Especificación
        let gradoInstruccion = responsableEl.querySelector('select[name="grado_instruccion_r[]"]').value;
        const especificarGrado = responsableEl.querySelector('input[name="especificar_grado_r[]"]').value;
        if (especificarGrado) {
            gradoInstruccion += ` - ${especificarGrado}`;
        }

        // Agregar el responsable al array
        responsables.push({
            NombreResponsable: nombreResponsable,
            Edad: edad,
            DNI: dni,
            Ocupacion: ocupacion,
            Parentesco: parentesco,
            CelularResponsable: celularResponsable,
            gradoInstruccion: gradoInstruccion
        });
    });
    return responsables;
}
