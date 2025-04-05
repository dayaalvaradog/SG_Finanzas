function ValidarLogin()
{
    //Se inicializa el arreglo de errores
    var eserror = false;

    var usuario = $("#txtUsuario").val();
    var password = $("#Contrasenia").val();

    //Se valida si el usuario esta vacio
    if (usuario == "") {
        AplicarEstiloValidacion("txtUsuario", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("txtUsuario", true, true);
    }

    //Se valida si la contraseña esta vacia
    if (password == "") {
        AplicarEstiloValidacion("Contrasenia", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("Contrasenia", true, true);
    }

    //Se retorna la respuesta
    return eserror;
}

function IniciarSesion() {
    var eserror = ValidarLogin();

    var us = $("#txtUsuario").val();
    var pass = $("#Contrasenia").val();

    if (!eserror) {

        $.ajax({
            type: "GET",
            url: RutaValidarLogin,
            data: { usuario : us, contraseña : pass },
            dataType: "json",
            async: false,
            success: function (data) {
                if (data.numError == 0) {
                    if (data.result.tipoRespuesta == 1) {
                        mostrarMensajeNotificacion(data.result.mensajeRespuesta, 1);
                        window.location.href = RutaInicio;
                    }
                    else {
                        mostrarMensajeNotificacion(data.result.mensajeRespuesta, 2);
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

