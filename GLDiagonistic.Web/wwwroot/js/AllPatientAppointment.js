
var dtAppointment;

$(document).ready(function () {
    LoadAllCurrentAppointments();

});

function LoadAllCurrentAppointments() {

    dtAppointment = $('.dt_Appointment').DataTable({
        ajax: '/PatientAppointment/LoadCurrentAllAppointment',
        columns: [
            { data: '' },
            { data: 'appointmentId', visible: false }, // Hidden column for ID
            { data: 'patientName' }, // Use lowercase property names based on your UsmCompanyProfileDto
            { data: 'age' },
            { data: 'contactNumber' },
            { data: 'doctorName' },
            { data: 'doctorFee' }

        ],
        columnDefs: [
            {
                // Actions
                targets: 0,
                title: 'Action',
                render: function (data, type, full, meta) {
                    var id = full[0];
                    return (

                        '<a href="javascript:;" class="btn btn-sm btn-text-secondary rounded-pill btn-icon item-edit"><i class="fas fa-edit text-primary"></i></a>' +
                        '<a href="javascript:;" class="btn btn-sm btn-text-secondary rounded-pill btn-icon item-delete"><i class="fas fa-trash-alt text-danger"></i></a>'

                    );
                }
            },
            {
                render: function (data, type, full, meta) {
                    return '';
                }
            },

            {
                targets: 1,
                searchable: false,
                visible: false
            }

        ],
        order: [[1, 'asc']]
    });
}







