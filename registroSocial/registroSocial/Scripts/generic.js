

var objBuscarGlobal;

var objPintarGlobal;

var objUrlGlobal;

function pintar(objPintar, objBuscar) {


    objBuscarGlobal = objBuscar;

    objPintarGlobal = objPintar;

    var raiz = document.getElementById("idRaiz").value;
    var raizAbsoluta = window.location.protocol + "//" + window.location.host +
        raiz+objPintar.url

    objUrlGlobal = window.location.protocol + "//" + window.location.host +
        raiz;

    console.log(raizAbsoluta)

    fetch(raizAbsoluta)
        .then(res => res.json())
        .then(res => {

 
           
            let contenido = "";
            if (objBuscar.editar = undefined)
                objBuscar.editar = false
            if (objBuscar.eliminar = undefined)
                objBuscar.eliminar = false
            if (objBuscar.lupa = undefined)
                objBuscar.lupa = false

            if (objBuscar != undefined && objBuscar.buscar == true){
                contenido =`<div class="input-group rounded">
                              <div class="form-outline" data-mdb-input-init>
                                <input type="search" id="${objBuscar.id}" class="form-control " placeholder="${objBuscar.placeholder}" />
                              </div>
                              <button type="button" class="btn btn-primary" onclick="buscar()">
                                <i class="fas fa-search"></i>
                              </button>
                            </div>`
             }



            contenido += `<div class="container-fluid" id="divTabla">`;

            contenido += generarTabla(objPintar, res);

            contenido += `</div>`;

            // Inserta el contenido de la tabla en el elemento HTML
            document.getElementById(objPintar.id).innerHTML = contenido;
        })
        .catch(error => console.error("Error al obtener datos:", error));
}

function generarTabla(objPintar,res) {


    var contenido= "";

        // Añade el contenido de la tabla con clases personalizadas
    contenido += "<table class='custom-table table-striped mt-3 mb-5 border'>";

    // Encabezado de la tabla
    contenido += "<tr>";
    for (let j = 0; j < objPintar.cabezeras.length; j++) {
        contenido += "<th>" + objPintar.cabezeras[j] + "</th>";
    }
    if (objPintar.editar) contenido += "<th>OPERACIONES</th>";
    if (objPintar.lupa) contenido += "<th>MAS INFO</th>";
    contenido += "</tr>";

    // Filas de datos
    res.forEach(fila => {
        contenido += "<tr>";
        objPintar.propiedades.forEach(propiedad => {
            let valor = fila[propiedad];
            contenido += "<td>" + (valor !== undefined ? (esFormatoFechaJson(valor) ? convertirFecha(valor) : valor) : "") + "</td>";
        });

    // Columnas de operaciones y más info
    if (objPintar.editar) {
        contenido += `<td><div class='icon-container'>
            <i class="btn btn-primary" title="Editar"  id="editar-${fila[objPintar.propiedadID]}" onclick=Editar(${fila[objPintar.propiedadID]}) >
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil" viewBox="0 0 16 16">
                    <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325"/>
                </svg>
            </i>
            <i class="btn btn-danger" title="Eliminar" id="eliminar-${fila[objPintar.propiedadID]}" onclick=Eliminar(${fila[objPintar.propiedadID]})>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z"/>
                    <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z"/>
                </svg>
            </i>
        </div></td>`;
    }

    if (objPintar.lupa) {
        contenido += `<td><div class='icon-container'>
            <i class="btn btn-warning" title="Ver más información"  onclick=MasInfo(${fila[objPintar.propiedadID]})>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search-heart" viewBox="0 0 16 16">
                    <path d="M6.5 4.482c1.664-1.673 5.825 1.254 0 5.018-5.825-3.764-1.664-6.69 0-5.018"/>
                    <path d="M13 6.5a6.47 6.47 0 0 1-1.258 3.844q.06.044.115.098l3.85 3.85a1 1 0 0 1-1.414 1.415l-3.85-3.85a1 1 0 0 1-.1-.115h.002A6.5 6.5 0 1 1 13 6.5M6.5 12a5.5 5.5 0 1 0 0-11 5.5 5.5 0 0 0 0 11"/>
                </svg>
            </i>
        </div></td>`;
    }
    contenido += "</tr>";
});

// Cierre de la tabla
contenido += "</table>";



    return contenido;
}

function ErrorSwing(text = "Ocurrio un error") {

    Swal.fire({
        icon: "error",
        title: "Error",
        text: text,

    });

}

function CorrectoSwing(text = "Guardado correctamente") {

    Swal.fire({
        position: "top-end",
        icon: "success",
        title: text,
        showConfirmButton: false,
        timer: 1500
    });
}

function ConfirmacionSwing(texto="Desea guardar los cambios?",title="Confirmacion",callback) {

   return  Swal.fire({
       title: title,
        text: texto,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, adelante"
    });
}

function convertirFecha(fechaJson) {
    // Extrae el timestamp del formato /Date(...)/
    const timestamp = parseInt(fechaJson.replace(/\/Date\((\d+)\)\//, "$1"), 10);
    const date = new Date(timestamp);

    // Formatea la fecha en YYYY-MM-DD
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Mes en formato MM
    const day = String(date.getDate()).padStart(2, '0'); // Día en formato DD

    return `${year}-${month}-${day}`;
}

function esFormatoFechaJson(valor) {
    return typeof valor === "string" && /^\/Date\(\d+\)\/$/.test(valor);
}

function buscar() {

    var parametro = document.getElementById(objBuscarGlobal.id).value;

    
    fetch("/"+objBuscarGlobal.url + "/?" + objBuscarGlobal.parametro + "=" + parametro)
            .then(res => res.json())
        .then(res => {

            var contenido = generarTabla(objPintarGlobal, res);

            document.getElementById("divTabla").innerHTML = contenido;

        })


}


