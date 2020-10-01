//function templateRow() {
//    var template = "<tr>";
//    template += "<td>" + "123" + "</td>";
//    template += "<td>" + "Jeffrey" + "</td>";
//    template += "<td>" + "Valerio" + "</td>";
//    template += "<td>" + "123" + "</td>";
//    template += "<td>" + "123" + "</td>";
//    template += "<td>" + "123" + "</td>";
//    template += "<td>" + "123" + "</td>";
//    template += "</tr>";
//    return template;
//}

//function addRowToDataTable() {
//    var template = templateRow();
//    for (var i = 0; i < 10; i++) {
//        $("#tbl_body_table").append(template);
//    }
//}

////addRowToDataTable();

//var data;

//function addRowDT(data) {
//    var tabla = $('#table_pacientes').DataTable();
//    for (var i = 0; i < data.length; i++) {
//        tabla.fnAddData([
//            data[i].idPacient,
//            data[i].num_social,
//            data[i].name,
//            data[i].telephone,
//            data[i].address,
//            data[i].birth,
//            data[i].gender,
//            data[i].status
//        ]);
//    };
//}

//function sendDataAjax() {
//    console.log('entra');
//    $.ajax({
//        type: "POST",
//        url: "Patient.aspx/ListPatients",
//        data: {},
//        contentType: "application/json; charset=utf-8",
//        error: function (xhr, ajaxOptions, thrownError) {
//        },
//        success: function (data) {
//            console.log('EXITOSO')
//            console.log(data.d)
//            addRowDT(data.d);
//        }
//    });
//}

//// LLAMADA A LA FUNCION AJAX
//sendDataAjax();