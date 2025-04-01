function ValidarRegistrarse() {
    //Se inicializa el arreglo de errores
    var eserror = false;

    const tieneNumero = /[0-9]/.test($("#nombrecompleto").val());
    const tieneNumeros = /[0-9]/.test($("#pin").val());

    //Se valida si el usuario esta vacio
    if ($("#nombreusuario").val() == "") {
        AplicarEstiloValidacion("nombreusuario", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("nombreusuario", true, true);
        //Se valida que la extensión del nombre sea mayor a 3 caracteres
        if ($("#nombreusuario").val().trim().length < 3) {
            AplicarEstiloValidacion("nombreusuario", true, true);
            mostrarMensajeNotificacion("El nombre debe tener al menos 3 caracteres", 2);
            eserror = true;
        }
        else {
            EliminarEstiloValidacion("nombreusuario", true, true);
            if (ValidaIdUsuarioExiste($("#nombreusuario").val()) == true) {
                mostrarMensajeNotificacion("El usuario indicado ya existe", 2);
                eserror = true;
            }
            else {
                EliminarEstiloValidacion("nombreusuario", true, true);
            }
        }
        
    }

    //Se valida si la contraseña esta vacia
    if ($("#nuevacontrasenia").val() == "") {
        AplicarEstiloValidacion("nuevacontrasenia", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("nuevacontrasenia", true, true);
    }

    //Se valida si la confirmacion de contraseña esta vacia
    if ($("#confirmarcontrasenia").val() == "") {
        AplicarEstiloValidacion("confirmarcontrasenia", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("confirmarcontrasenia", true, true);
    }

    //Se valida que las contraseñas coincidan
    if ($("#nuevacontrasenia").val() != $("#confirmarcontrasenia").val()) {
        AplicarEstiloValidacion("nuevacontrasenia", true, true);
        AplicarEstiloValidacion("confirmarcontrasenia", true, true);
        mostrarMensajeNotificacion("Las contraseñas no coinciden", 2);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("nuevacontrasenia", true, true);
        EliminarEstiloValidacion("confirmarcontrasenia", true, true);
        //se valida que la contraseña sea segura
        if (verificarSeguridadContraseña($("#nuevacontrasenia").val()) == false) {
            AplicarEstiloValidacion("nuevacontrasenia", true, true);
            AplicarEstiloValidacion("confirmarcontrasenia", true, true);
            mostrarMensajeNotificacion("La contraseña debe tener al menos 8 caracteres, una letra mayúscula, una letra minúscula y un número", 2);
            eserror = true;
        }
        else {
            EliminarEstiloValidacion("nuevacontrasenia", true, true);
        }
    }

    //Se valida que el correo no esté incorrecto o vacío
    if ($("#correo").val() == "" || (validarCorreo($("#correo").val())) == false) {
        AplicarEstiloValidacion("correo", true, true);
        mostrarMensajeNotificacion("Digite un correo electrónico válido", 2);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("correo", true, true);
        //se valida que el correo sea correcto
        if (!validarCorreo($("#correo").val())) {
            AplicarEstiloValidacion("correo", true, true);
            mostrarMensajeNotificacion("Digite un correo electrónico válido", 2);
            eserror = true;
        }
        else {
            EliminarEstiloValidacion("correo", true, true);
            //Se valida que el correo no exista
            if (ValidarCorreoExiste($("#correo").val()) == true) {
                AplicarEstiloValidacion("correo", true, true);
                mostrarMensajeNotificacion("El correo indicado ya existe", 2);
                eserror = true;
            }
            else {
                EliminarEstiloValidacion("correo", true, true);
            }
        }
    }

    //Se valida que el nombre completo no esté vacío
    if ($("#nombrecompleto").val() == "") {
        AplicarEstiloValidacion("nombrecompleto", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("nombrecompleto", true, true);
        //Se valida que el nombre completo no tenga números
        if ($("#nombrecompleto").val().trim().length < 16) {
            AplicarEstiloValidacion("nombrecompleto", true, true);
            mostrarMensajeNotificacion("El nombre debe tener al menos 16 caracteres", 2);
            eserror = true;
        }
        else {
            EliminarEstiloValidacion("nombrecompleto", true, true);
            if (tieneNumero) {
                AplicarEstiloValidacion("nombrecompleto", true, true);
                mostrarMensajeNotificacion("El nombre no puede contener números", 2);
                eserror = true;
            }
            else {
                EliminarEstiloValidacion("nombrecompleto", true, true);
            }
        }
        
    }

    //Se valida que el pin no esté vacío
    if ($("#pin").val() == "") {
        AplicarEstiloValidacion("pin", true, true);
        eserror = true;
    }
    else {
        EliminarEstiloValidacion("pin", true, true);
        //Se valida que el pin tenga mínimo 4 caracteres y máximo 6 caracteres numéricos
        if ($("#pin").val().length < 4 || $("#pin").val().length > 6 && tieneNumeros) {
            AplicarEstiloValidacion("pin", true, true);
            mostrarMensajeNotificacion("El pin debe tener entre 4 y 6 caracteres numéricos", 2);
            eserror = true;
        }
        else {
            EliminarEstiloValidacion("pin", true, true);
        }
    }
    //Se retorna la respuesta
    return eserror;
}

function Registrarse() {
    var eserror = ValidarRegistrarse();

    var datosUsuario =
    {
        CodUsuario: 0,
        IdUsuario: $("#nombreusuario").val().toString(),
        NombreCompleto: $("#nombrecompleto").val().toString(),
        TipoUsuario: 1,
        Correo: $("#correo").val(),
        Contrasenia: $("#nuevacontrasenia").val().toString(),
        Pin: parseInt($("#pin").val()),
        EsActivo: Boolean(true)
    };

    if (!eserror) {

        $.ajax({
            type: "POST",
            url: RutaRegistrarse,
            data: { datos: JSON.stringify(datosUsuario) },
            dataType: "json",
            async: false,
            success: function (data) {
                if (data.numError == 0) {
                    if (data.result == true) {
                        mostrarMensajeNotificacion("Usuario registrado correctamente, ya puede iniciar sesión", 1);
                        setTimeout(function () {
                            window.location.href = RutaIniciarSesion;
                        }, 3000);
                    }
                    else {
                        mostrarMensajeNotificacion("El usuario indicado no ya existe", 2);
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