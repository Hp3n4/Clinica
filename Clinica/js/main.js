//Pacientes
$(function () {

    $.ajax({
        dataType: "json",
        url: "../Home/ListaPacientes",
        success: function (result) {
            var opts = "";
            for (var i = 0; i < result.length; ++i) {

                opts += "<option value=\"" + result[i][0] + "\">" + result[i][1] + "</option>";
            }

            $("#tbl_citas_nombrep").html(opts);
        }
    });
});

function pacientesIns() {
    $("#dlg_pacientes_title").text("Nuevo Paciente");
    $("#tbl_pacientes_accion").val("INS");
    $("#tbl_pacientes_nombre").val("");
    $("#tbl_pacientes_nacimiento").val("");
    $("#dlg_pacientes_errores").html("");
    $("#dlg_pacientes").modal("show");
}

function pacientesInsUpd() {
    var accion = $("#tbl_pacientes_accion").val();
    var idpaciente = $("#tbl_pacientes_idpaciente").val();
    var nombre = $("#tbl_pacientes_nombre").val();
    var nacimiento = $("#tbl_pacientes_nacimiento").val();

    if (accion === "INS") {

        $.ajax({
            type: "POST",
            dataType: "json",
            url: urlGerneral + "Pacientes/PacientesIns",
            content: "application/json;charset=utf-8",
            data: {
                nombre: nombre,
                nacimiento: nacimiento
            },
            success: function (result) {
                if (result.msg === "") {

                    window.location = "../";

                } else {
                    $("#dlg_pacientes_errores").html(result.msg);
                }
            }
        });
    } 
}

function pacientesDel(idpaciente, nombre) {
     $("#dlg_confirm_dato1").val("DEL_PACIENTE");
    $("#dlg_confirm_dato2").val(idpaciente);
    $("#dlg_confirm_error").hide();
    $("#dlg_confirm_title").text("Retirar Paciente");
    $("#dlg_confirm_msg").text("¿Desea retirar a " + nombre + "?");
    $("#dlg_confirm").modal("show");
}


//Medicos
function medicosIns(idespecialidad,especialidad) {
    $("#dlg_medicos_title").text("Nuevo Medico");
    $("#tbl_medicos_accion").val("INS");
    $("#tbl_medicos_idespecialidad").val(idespecialidad);
    $("#tbl_medicos_especialidad").val(especialidad);
    $("#tbl_medicos_nombre").val("");    
    $("#dlg_medicos_errores").html("");
    $("#dlg_medicos").modal("show");
}

function medicosInsUpd() {
    var accion = $("#tbl_medicos_accion").val();
    var idespecialidad = $("#tbl_medicos_idespecialidad").val();
    var nombre = $("#tbl_medicos_nombre").val();


    if (accion === "INS") {

        $.ajax({
            type: "POST",
            dataType: "json",
            url: urlGerneral + "Medicos/MedicosIns",
            content: "application/json;charset=utf-8",
            data: {
                idespecialidad: idespecialidad,
                nombre: nombre,

            },
            success: function (result) {
                if (result.msg === "") {

                    window.location = "../";

                } else {
                    $("#dlg_medicos_errores").html(result.msg);
                }
            }
        });

    } else if (accion === "UPD") {

    }
}

function medicosDel(idmedico, nombre) {
    $("#dlg_confirm_dato1").val("DEL_MEDICO");
    $("#dlg_confirm_dato2").val(idmedico);
    $("#dlg_confirm_error").hide();
    $("#dlg_confirm_title").text("Retirar Medico");
    $("#dlg_confirm_msg").text("¿Desea retirar Medico? " + nombre + "?");
    $("#dlg_confirm").modal("show");
}

//especialidades
function especialidadesIns() {
    $("#dlg_especialidades_title").text("Nueva Especialidad");
    $("#tbl_especialidades_accion").val("INS");
    $("#tbl_especialidades_especialidad").val("");    
    $("#dlg_especialidades_errores").html("");
    $("#dlg_especialidades").modal("show");
}

function especialidadesInsUpd() {
    var accion = $("#tbl_especialidades_accion").val();
    var idpespecialidad = $("#tbl_especialidades_idespecialidad").val();

    var especialidad = $("#tbl_especialidades_especialidad").val();
    
    if (accion === "INS") {

        $.ajax({
            type: "POST",
            dataType: "json",
            url: urlGerneral + "Especialidades/EspecialidadesIns",
            content: "application/json;charset=utf-8",
            data: {
                especialidad: especialidad
            },
            success: function (result) {
                if (result.msg === "") {

                    window.location = "../";

                } else {
                    $("#dlg_especialidades_errores").html(result.msg);
                }
            }
        });
    } 
}

//Citas
//function CitasIns(idmedico, nombre) {
//    $("#dlg_medicos_title").text("Nueva Cita");
//    $("#tbl_medicos_accion").val("INS");
//    $("#tbl_medicos_idespecialidad").val(idmedico);
//    $("#tbl_medicos_especialidad").val(nombre);
//    $("#tbl_medicos_nombre").val("");
//    $("#dlg_medicos_errores").html("");
//    $("#dlg_medicos").modal("show");
//}


function citasIns(idespecialidad, especialidad, idmedico, nombre) {
    $("#dlg_citas_title").text("Nuevo Cita en : " + especialidad + "?");
    $("#tbl_citas_accion").val("INS");
    $("#tbl_citas_idmedico").val(idmedico);
    $("#tbl_citas_medico").val(nombre);
    $("#tbl_citas_nombrep").val("");
    $("#tbl_citas_diahora").val("");
    $("#dlg_citas_errores").html("");
    $("#dlg_citas").modal("show");
}

function citasInsUpd() {
    var accion = $("#tbl_citas_accion").val();
    var idcita = $("#tbl_citas_idcita").val();
    var idpaciente = $("#tbl_citas_nombrep").val();
    var idmedico = $("#tbl_citas_idmedico").val();
    var diahora = $("#tbl_citas_diahora").val();


    if (accion === "INS") {

        $.ajax({
            type: "POST",
            dataType: "json",
            url: urlGerneral + "Citas/CitasIns",
            content: "application/json;charset=utf-8",
            data: {
                idpaciente: idpaciente,
                idmedico: idmedico,
                diahora: diahora,

            },
            success: function (result) {
                if (result.msg === "") {

                    window.location = "../";

                } else {
                    $("#dlg_citas_errores").html(result.msg);
                }
            }
        });
    }
}

function citasDel(idcita) {
    $("#dlg_confirm_error").hide();
    $("#dlg_confirm_dato1").val("DEL_CITAS");
    $("#dlg_confirm_dato2").val(idcita);
    $("#dlg_confirm_title").text("Advertencia");
    $("#dlg_confirm_msg").html("¿Desea Eliminar Cita?");
    $("#dlg_confirm").modal("show");
}

//Confirm DEL
function dlg_confirm_confirm() {
    var accion = $("#dlg_confirm_dato1").val();

    if (accion === "DEL_PACIENTE") {
        var idpaciente = $("#dlg_confirm_dato2").val();

        $.ajax({
            type: "POST",
            dataType: "json",
            url: urlGerneral + "Pacientes/PacientesDel",
            content: "application/json;charset=utf-8",
            data: {
                idpaciente: idpaciente
            },


            success: function (result) {
                if (result.msg === "") {

                    window.location = "../";
                    /* alert("dasfwdsa");*/
                    //$("#dlg_confirm").modal("hide");

                } else {
                    $("#dlg_pacientes_errores").html(result.msg);
                }
            }

        });
    } else if (accion === "DEL_MEDICO") {

        var idmedico = $("#dlg_confirm_dato2").val();

        $.ajax({
            type: "POST",
            dataType: "json",
            url: urlGerneral + "Medicos/MedicosDel",
            content: "application/json;charset=utf-8",
            data: {
                idmedico: idmedico
            },
            success: function (result) {
                if (result.msg === "") {

                    window.location = "../";

                } else {
                    $("#dlg_confirm_error").html(result.msg);
                }
            }
        });
    } else if (accion === "DEL_CITAS") {
        var idcita = $("#dlg_confirm_dato2").val();

        $.ajax({
            type: "POST",
            dataType: "json",
            url: urlGerneral + "Citas/CitasDel",
            content: "application/json;charset=utf-8",
            data: {
                idcita: idcita
            },
            success: function (result) {
                if (result.msg === "") {

                    window.location = "../";

                } else {
                    $("#dlg_confirm_error").html(result.msg);
                }
            }
        });
    }
}
