

    // Initialize the counter outside the event listener
    let contador = 0;

    document.getElementById('add-responsable').addEventListener('click', function () {
        const container = document.getElementById('responsables-container');
        const newResponsable = document.createElement('div');
        newResponsable.classList.add('responsable', 'mb-3', 'border', 'p-3');

        // Assign unique ID to the extra-field-container for each new responsible
        newResponsable.innerHTML = `
            <div class="row">
                <div class="col-md-3">
                    <label class="form-label">Nombre Responsable:</label>
                    <input type="text" class="form-control" name="nombre_r[]">
                </div>
                <div class="col-md-3">
                    <label class="form-label">Ocupación:</label>
                    <input type="text" class="form-control" name="ocupacion_r[]">
                </div>
                <div class="col-md-3">
                    <label class="form-label">Parentesco:</label>
                    <input type="text" class="form-control" name="parentesco_r[]">
                </div>
                <div class="col-md-3">
                    <label class="form-label">Edad:</label>
                    <input type="number" class="form-control" name="edad_r[]">
                </div>
                <div class="col-md-3">
                    <label class="form-label">DNI:</label>
                    <input type="text" class="form-control" name="dni_r[]">
                </div>
            |
                <div class="col-md-3">
                    <label class="form-label">Celular:</label>
                    <input type="tel" class="form-control" name="celular_r[]">
                </div>
                <div class="col-md-3">
                    <label class="form-label">Grado de Instrucción:</label>
                    <select class="form-select" name="grado_instruccion_r[]" onchange="toggleExtraField(this, ${contador})">
                        <option value="IL">Iletrado/a</option>
                        <option value="PC">Primaria Completa</option>
                        <option value="PI">Primaria Incompleta</option>
                        <option value="SC">Secundaria Completa</option>
                        <option value="SI">Secundaria Incompleta</option>
                        <option value="SU">Superior Universitaria</option>
                        <option value="ST">Superior Técnica</option>
                    </select>
                </div>
                <div class="col-md-3" id="extra-field-container${contador}" style="display: none;">
                    <label class="form-label">Especificar Grado Responsable ${contador+1}:</label>
                    <input type="text" class="form-control" name="especificar_grado_r[]">
                </div>
            </div>
            <button type="button" class="btn btn-danger mt-2 remove-responsable">Eliminar</button>
        `;

        contador += 1;
        container.appendChild(newResponsable);
    });

   
    function toggleExtraField(selectElement, id) {
        const extraField = document.getElementById(`extra-field-container${id}`);
        if (selectElement.value === 'SU' || selectElement.value === 'ST' || selectElement.value === 'PI' || selectElement.value === 'SI') {
            extraField.style.display = 'block';
        } else {
            extraField.style.display = 'none';
        }
    }



    
    document.getElementById('responsables-container').addEventListener('click', function (e) {
        if (e.target.classList.contains('remove-responsable')) {
            e.target.closest('.responsable').remove();
        }
    });

    function toggleExtraFieldPaciente(selectElement) {
        const extraField = document.getElementById(`extra-field-paciente`);
        if (selectElement.value === 'SU' || selectElement.value === 'ST' || selectElement.value === 'PI' || selectElement.value === 'SI') {
            extraField.style.display = 'block';
        } else {
            extraField.style.display = 'none';
        }
    }

function toggleExtraFieldPacienteSeguro(selectElement) {
    const extraField = document.getElementById(`extra-field-seguro-paciente`);
    if (selectElement.value === 'PARTICULAR') {
        extraField.style.display = 'block';
    } else {
        extraField.style.display = 'none';
    }
}

