
function ValidarRegMovimiento() {
    //Se inicializa el arreglo de errores
    var eserror = false;

    var codCuenta = parseInt($("#ddlCuenta").val());
    var codCategoria = parseInt($("#ddlCategoria").val());
    var codClasificacion = parseInt($("#ddlClasificaciones").val());
    var codMoneda = parseInt($("#ddlMoneda").val());
    var monto = parseInt($("#Monto").val());
    var fecha = $("#fechamov").val();
    var codUsuario = parseInt($("#idUsuario").val());
    var esActivo = true;

    if (codCuenta == 0) {
        AplicarEstiloValidacion("ddlCuenta", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("ddlCuenta", true, true);
    }

    if (codCategoria == 0) {
        AplicarEstiloValidacion("ddlCategoria", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("ddlCategoria", true, true);
    }

    if (codClasificacion == 0) {
        AplicarEstiloValidacion("ddlClasificaciones", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("ddlClasificaciones", true, true);
    }

    if (codMoneda == 0) {
        AplicarEstiloValidacion("ddlMoneda", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("ddlMoneda", true, true);
    }

    if ((monto == 0) || (monto == null) || (monto == undefined)) {
        AplicarEstiloValidacion("Monto", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("Monto", true, true);
    }

    if (fecha == 0) {
        AplicarEstiloValidacion("fechamov", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("fechamov", true, true);
    }

    if ((codUsuario == 0) || (codUsuario == null) || (idUsuario == undefined)) {
        AplicarEstiloValidacion("idUsuario", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("idUsuario", true, true);
    }

    //Se retorna la respuesta
    return eserror;
}

function RegistrarMovimiento() {
    var eserror = ValidarRegMovimiento();

    var datosMov =
    {
        CodMovimiento: 0,
        CodCuenta: parseInt($("#ddlCuenta").val()),
        CodCategoria: parseInt($("#ddlCategoria").val()),
        CodClasificacion: parseInt($("#ddlClasificaciones").val()),
        Monto: parseInt($("#Monto").val()),
        Fecha: $("#fechamov").val(),
        CodUsuario: parseInt($("#idUsuario").val()),
        EsActivo: true

    };

    if (!eserror) {

        $.ajax({
            type: "POST",
            url: RutaRegistrarMov,
            data: { datos: JSON.stringify(datosMov) },
            dataType: "json",
            async: false,
            success: function (data) {
                if (data.numError == 0) {
                    if (data.result == true) {
                        mostrarMensajeNotificacion("Movimiento registrado correctamente", 1);
                    }
                    else {
                        mostrarMensajeNotificacion("Ocurrió un error en el registro del movimiento", 2);
                    }
                }
                else if (data.numError == 1) {
                    mostrarMensajeNotificacion(data.textError, 2);
                }
                else if (data.numError == 2) {
                    mostrarMensajeNotificacion(data.textError, 2);
                }
            },
            error: function (data) {
                mostrarMensajeNotificacion(data.textError, 2);
            }
        });
    }
}

function LimpiarCamposMovimiento() {
    $("#ddlCuenta").val(0);
    $("#ddlCategoria").val(0);
    $("#ddlClasificaciones").val(0);
    $("#Monto").val("0.00");
    $("#fechamov").val("");
    RenderizarComponentes();
}