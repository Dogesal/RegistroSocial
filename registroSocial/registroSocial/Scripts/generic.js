function pintar(objPintar,objBuscar) {



    var raiz = document.getElementById("idRaiz").value;
    var raizAbsoluta = window.location.protocol + "//" + window.location.host +
        raiz+objPintar.url

    console.log(raizAbsoluta)

    fetch(raizAbsoluta)
        .then(res => res.json())
        .then(res => {

            let contenido = "";

            if (objBuscar != undefined && objBuscar.busqueda == true){
        contenido =`<div class="input-group">
                      <div class="form-outline" data-mdb-input-init>
                        <input type="search" id="${objBuscar.id}" class="form-control" />
                        <label class="form-label" for="form1">${objBuscar.placeholder}</label>
                      </div>
                      <button type="button" class="btn btn-primary" onclick="filtrarPaciente()">
                        <i class="fas fa-search"></i>
                      </button>
                    </div>`
             }


            // Inicio de la tabla
            contenido += "<table class='table'>";
            contenido += "<tr>";
            for (let j = 0; j < objPintar.cabezeras.length; j++) {
                contenido += "<th>" + objPintar.cabezeras[j] + "</th>";
            }
            contenido += "</tr>";
            console.log(res)
            // Relleno de filas
            res.forEach(fila => {
                contenido += "<tr>";
                objPintar.propiedades.forEach(propiedad => {
                    let valor = fila[propiedad];
                    if (esFormatoFechaJson(valor)) {
                        contenido += "<td>" + convertirFecha(valor) + "</td>";
                    } else {
                        contenido += "<td>" + (valor !== undefined ? valor : "") + "</td>";
                    }
                });
                contenido += "</tr>";
            });

            // Cierre de la tabla
            contenido += "</table>";

            // Inserta el contenido de la tabla en el elemento HTML
            document.getElementById(objPintar.id).innerHTML = contenido;
        })
        .catch(error => console.error("Error al obtener datos:", error));
}


function convertirFecha(fechaJson) {
    const timestamp = parseInt(fechaJson.replace(/\/Date\((\d+)\)\//, "$1"), 10);
    return new Date(timestamp).toLocaleDateString();
}

function esFormatoFechaJson(valor) {
    return typeof valor === "string" && /^\/Date\(\d+\)\/$/.test(valor);
}