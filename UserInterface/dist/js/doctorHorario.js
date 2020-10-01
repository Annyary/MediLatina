$('#btnBuscarDoctor').on('click', function (event) {
    event.preventDefault();

    // OBTENER DATOS DEL ID DEL DOCTOR
    var id = $('#txtInputDoctor').val();
    var obj = JSON.stringify({ id: id });

    if (id.length > 0) {
        // AJAX
        $.ajax({
            type: 'POST',
            url: 'DoctorHorario.aspx/BuscarDoctor',
            data: obj,
            contentType: 'application/json; chartset=utf-8',
            error: function (xhr, throwError) {
                console.log(xhr.status + "\n" + xhr.responseText, + "\n" + throwError);
            },
            success: function (data) {
                console.log("exito", data);
                llenarDatos(data.d);
            }
        });

    } else {
        // PONER ALERTA MAS BONITA
        alert('Debe ingresar un número');
    }
    // LLAMADA A AJAX
});

function llenarDatos(obj) {
    $('#lblColegiado').text(obj.Num_colegiado);
    $('#lblNombre').text(obj.Name);
    $('#lblServicio').text(obj.Service.Name);
}