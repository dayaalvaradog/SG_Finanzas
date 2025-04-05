function AplicarEstiloValidacion(idCampo, mostrarValidador, aplicarBorde) {
    //Si se debe mostrar el label del error
    if (mostrarValidador) {
        $(".Msg_" + idCampo).show("slow");
    }

    //Si se debe mostrar el borde rojo en el contenedor del campo
    if (aplicarBorde) {
        //Se aplica el borde rojo al campo
        $("#" + idCampo).parent().addClass("input-rojo");
    }
}

//Esta funcion quita el mensaje de validacion para el campo
function EliminarEstiloValidacion(idCampo, mostrarValidador, aplicarBorde) {
    //Si se debe mostrar el label del error
    if (mostrarValidador) {
        $(".Msg_" + idCampo).hide("slow");
    }

    //Si se debe mostrar el borde rojo en el contenedor del campo
    if (aplicarBorde) {
        //Se aplica el borde rojo al campo
        $("#" + idCampo).parent().removeClass("input-rojo");
    }
}

//Muestra una alerta de mensaje
function mostrarMensajeNotificacion(message, type) {
    var icon = '';
    var alert = '';
    switch (type) {
        case 1: //Sucess
            alert = "azul";
            icon = '<svg xmlns="http://www.w3.org/2000/svg" class="feather-check-circle" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-check-circle"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"></path><polyline points="22 4 12 14.01 9 11.01"></polyline></svg>';
            break;
        case 2: //Error
            alert = "rojo";
            icon = '<svg xmlns="http://www.w3.org/2000/svg" class="feather-check-circle" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-check-circle"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"></path><polyline points="22 4 12 14.01 9 11.01"></polyline></svg>';
            break;
        default:
    }

    message = icon + message;

    const alertPlaceholder = document.getElementById('liveAlertPlaceholder');

    const wrapper = document.createElement('div');
    wrapper.innerHTML = [
        `<div class="alert alert-${alert} alert-dismissible fade show" role="alert">`,
        `   <div>${message}</div>`,
        '   <a type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></a>',
        '</div>'
    ].join('');

    alertPlaceholder.append(wrapper);
    setTimeout(function () {
        bootstrap.Alert.getOrCreateInstance(wrapper).close();
    }, 5000)
}

function validarCorreo(email) {
    var regex =
        /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false
    }
    else {
        return true;
    }
}

function verificarSeguridadContraseña(contraseña) {
    // Criterios de seguridad
    const longitudMinima = 8;
    const tieneMayuscula = /[A-Z]/.test(contraseña);
    const tieneMinuscula = /[a-z]/.test(contraseña);
    const tieneNumero = /[0-9]/.test(contraseña);
    const tieneCaracterEspecial = /[^A-Za-z0-9]/.test(contraseña);

    // Verificar criterios
    if (contraseña.length < longitudMinima) {
        mostrarMensajeNotificacion("La contraseña debe tener al menos 8 caracteres.", 2);
        return false;
    }

    if (!tieneMayuscula) {
        mostrarMensajeNotificacion("La contraseña debe contener al menos una letra mayúscula.", 2);
        return false;
    }

    if (!tieneMinuscula) {
        mostrarMensajeNotificacion("La contraseña debe contener al menos una letra minúscula.", 2);
        return false;
    }

    if (!tieneNumero) {
        mostrarMensajeNotificacion("La contraseña debe contener al menos un número.", 2);
        return false;
    }

    if (!tieneCaracterEspecial) {
        mostrarMensajeNotificacion("La contraseña debe contener al menos un carácter especial (por ejemplo, !@#$%^&*).", 2);
        return false;
    }

    // Si todos los criterios se cumplen, la contraseña es segura
    return true;
}

function ObtenerRuta(codTipo, codMenu) {
    //Aquí se agrega las rutas de las vistas que se van a utilizar
    var ruta;
    switch (codTipo) {
        case 1:
            switch (codMenu) {
                //Registro de Movimientos
                case 1:
                    ruta = RutaRegistrarMovimiento;
                    break;
                //Registro de Presupuesto
                case 2:
                    ruta = RutaRegistrarPresupuesto;
                    break;
                //Registro de Metas Presupuestarias
                case 3:
                    ruta = RegistroMetasPresupuesto;
                    break;
                default:
                    ruta = RutaLogin;
                    break;
            }
            break;
        case 2:
            switch (codMenu) {
                //Consulta de Estado de Cuentas
                case 4:
                    ruta = RutaConsultaEstadoCuentas;
                    break;
                //Consulta de Movimientos
                case 5:
                    ruta = RutaConsultaMovimientos;
                    break;
                default:
                    ruta = RutaLogin;
                    break;
            }
            break;
        case 3:
            switch (codMenu) {
                default:
                    ruta = RutaLogin;
                    break;
            }
            break;
        case 4:
            switch (codMenu) {
                //Resumen Estadísticas
                case 6:
                    ruta = RutaInicio;
                    break;
                default:
                    ruta = RutaLogin;
                    break;
            }
            break;
        case 5:
            switch (codMenu) {
                //Registro de Cuentas Bancarias
                case 8:
                    ruta = RutaRegistroCuentas;
                    break;
                default:
                    ruta = RutaLogin;
                    break;
            }
        default:
            ruta = RutaLogin;
            break;
    }
    return ruta;
}

function RedireccionarRuta(codTipo, codMenu) {
    var ruta = ObtenerRuta(codTipo, codMenu);
    window.location.href = ruta;
}

function RenderizarComponentes() {
    const tooltipTriggerList = document.querySelectorAll('[data-toggle="tooltip"]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

    const popoverTriggerList = document.querySelectorAll('[data-toggle="popover"]')
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl))

    feather.replace();

    $('[data-mdb-toggle="tooltip"]').tooltip();

}

