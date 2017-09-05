var months_en = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]

$(document).ready(function () {
    CreateMonths();
});

//creates months band
function CreateMonths() {
    var data = { months: months_en };
    var tmpl = $.templates("#monthTmpl");
    var html = tmpl.render(data);
    $("#MonthsBand").html("| " + html);
}

function PopulateAppointments(month) {
    var jqxhr = $.ajax("CalendarService.ashx/Appointments/" + month)
        .done(function (data) {
            var tmpl = $.templates("#appointmentsTmpl");
            var html = tmpl.render(data);
            $("#Appointments").html(html);
        });
}

function PopulateAppointmentDetails(appointment) {
    var jqxhr = $.ajax("CalendarService.ashx/AppointmentDetail/" + appointment)
    .done(function (data) {
        var tmpl = $.templates("#appointmentDetailTmpl");
        var html = tmpl.render(data);
        $("#AppointmentDetails").html(html);
    });
}