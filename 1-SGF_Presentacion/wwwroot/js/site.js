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