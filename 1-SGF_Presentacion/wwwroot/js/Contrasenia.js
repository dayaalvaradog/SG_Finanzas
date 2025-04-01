function ValidarCambiarContrasenia() {
    //Se inicializa el arreglo de errores
    var eserror = false;

    const tieneNumeros = /[0-9]/.test($("#pin").val());

    //Se valida si el usuario esta vacio
    if (($("#idusuario").val() == "") && $("#idusuario").is(":checked")) {
        AplicarEstiloValidacion("idusuario", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("idusuario", true, true);
        if (ValidaIdUsuarioExiste($("#idusuario").val()) == false) {
            mostrarMensajeNotificacion("El usuario indicado ya existe", 2);
            eserror = true;
        }
        else {
            EliminarEstiloValidacion("idusuario", true, true);
        }
    }

    //Se valida si la contraseña esta vacia
    if ($("#contrasenianueva").val() == "") {
        AplicarEstiloValidacion("contrasenianueva", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("contrasenianueva", true, true);
    }

    //Se valida si la confirmacion de contraseña esta vacia
    if ($("#confirmarcontrasenianueva").val() == "") {
        AplicarEstiloValidacion("confirmarcontrasenianueva", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("confirmarcontrasenianueva", true, true);
    }

    //Se valida que las contraseñas coincidan
    if ($("#contrasenianueva").val() != $("#confirmarcontrasenianueva").val()) {
        AplicarEstiloValidacion("contrasenianueva", true, true);
        AplicarEstiloValidacion("confirmarcontrasenianueva", true, true);
        mostrarMensajeNotificacion("Las contraseñas no coinciden", 2);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("contrasenianueva", true, true);
        EliminarEstiloValidacion("confirmarcontrasenianueva", true, true);
        //se valida que la contraseña sea segura
        if (verificarSeguridadContraseña($("#contrasenianueva").val()) == false) {
            AplicarEstiloValidacion("contrasenianueva", true, true);
            AplicarEstiloValidacion("confirmarcontrasenianueva", true, true);
            mostrarMensajeNotificacion("La contraseña debe tener al menos 8 caracteres, una letra mayúscula, una letra minúscula y un número", 2);
            eserror = true;
        }
        else {
            EliminarEstiloValidacion("contrasenianueva", true, true);
        }
    }

    //Se valida que el correo no esté incorrecto o vacío
    if ((($("#correoelect").val() == "" || (validarCorreo($("#correoelect").val())) == false)) && ($("#correoelect").is(":checked"))) {
        AplicarEstiloValidacion("correoelect", true, true);
        mostrarMensajeNotificacion("Digite un correo electrónico válido", 2);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("correoelect", true, true);
        if ((ValidarCorreoExiste($("#correoelect").val()) == true) && ($("#correoelect").is(":checked"))) {
            AplicarEstiloValidacion("correoelect", true, true);
            mostrarMensajeNotificacion("El correo indicado ya existe", 2);
            eserror = true;
        }
        else {
            EliminarEstiloValidacion("correoelect", true, true);
        }
    }

    //Se valida que el pin no esté vacío
    if ($("#pin").val() == "") {
        AplicarEstiloValidacion("pin", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("pin", true, true);
    }
    //Se retorna la respuesta
    return eserror;
}

function CambiarContrasenia() {
    var eserror = ValidarCambiarContrasenia();

    var datosUsuario =
    {
        CodUsuario: 0,
        IdUsuario: $("#idusuario").val().toString(),
        NombreCompleto: "",
        TipoUsuario: 1,
        Correo: $("#correoelect").val(),
        Contrasenia: $("#contrasenianueva").val().toString(),
        Pin: parseInt($("#pin").val()),
        EsActivo: Boolean(true)
    };
    if (!eserror) {

        $.ajax({
            type: "GET",
            url: RutaCambiarContrasenia,
            data: { datos: JSON.stringify(datosUsuario) },
            dataType: "json",
            async: false,
            success: function (data) {
                if (data.numError == 0) {
                    if (data.result.tipoRespuesta == 1) {
                        mostrarMensajeNotificacion(data.result.mensajeRespuesta, 1);
                        setTimeout(function () {
                            window.location.href = RutaIniciarSesion;
                        }, 3000);
                    } else {
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

function ValidaIdUsuarioExiste(idusuario) {
    $.ajax({
        type: "GET",
        url: RutaValidaIdUsuarioExiste,
        data: { usuario: idusuario },
        dataType: "json",
        async: false,
        success: function (data) {
            return data.result;
        },
        error: function (data) {
            mostrarMensajeNotificacion("Ocurrio un error al validar el Nombre de Usuario", 2);
        }
    });
}

function ValidarCorreoExiste(email) {
    $.ajax({
        type: "GET",
        url: RutaValidarCorreoExiste,
        data: { correo: email },
        dataType: "json",
        async: false,
        success: function (data) {
            return data.result;
        },
        error: function (data) {
            mostrarMensajeNotificacion("Ocurrio un error al validar el correo electrónico", 2);
        }
    });
}

function Cambiar(tipo) {
    switch (tipo) {
        case "1":
            $("#div_usuario").show("slow");
            $("#divCorreo").hide("slow");
            break;
        case "2":
            $("#div_usuario").hide("slow");
            $("#divCorreo").show("slow");
            break;
    }
}