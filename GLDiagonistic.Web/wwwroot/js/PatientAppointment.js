
var doctorId = 0;
var doctorList = [];
var investigationList = [];
var dtAppointment;

$(document).ready(function () {
    LoadDoctorList();
    LoadInvestigation();
    LoadAllCurrentAppointments();
    var selectElement = $('#select2Basic');

    selectElement.on('change', function () {
        var selectedDoctorId = $(this).val();
        doctorId = selectedDoctorId;
        console.log('Selected doctorId ID:', selectedDoctorId);

        // Find the doctor in the doctorList based on the selectedDoctorId
        var selectedDoctor = doctorList.find(function (doctor) {
            var doctor_Id = doctor.id.toString().trim();
            var selectedId = selectedDoctorId.toString().trim();
            return doctor_Id === selectedId;
        });

        if (selectedDoctor) {
            // You can access the selected doctor's properties here
            console.log('Selected doctor:', selectedDoctor);

            $('#doctorFee').val(selectedDoctor.doctorsFee);
        } else {
            console.log('Doctor not found with ID:', selectedDoctorId);
        }
    });

    var testSelect = $('#investigation');

    testSelect.on('change', function () {
        var selectedtestId = $(this).val();
        investigationId = selectedtestId;
        console.log('Selected investigationId:', selectedtestId);

        // Find the doctor in the doctorList based on the selectedDoctorId
        var selectedInvestigation = investigationList.find(function (test) {
            var test_Id = test.id.toString().trim();
            var selectedId = selectedtestId.toString().trim();
            return test_Id === selectedId;
        });

        if (selectedInvestigation) {
            // You can access the selected doctor's properties here
            console.log('Selected Investigation:', selectedInvestigation);

            $('#investigationFee').val(selectedInvestigation.cost);
        } else {
            console.log('Investigation not found with ID:', selectedtestId);
        }
    });
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

function LoadDoctorList() {
    $.ajax({
        url: '/Doctor/LoadAllDoctorList',
        method: 'GET',
        dataType: 'json',
        success: function (response) {
            doctorList = response.data;
            console.log(doctorList);
            // Assuming 'data' is an array of objects with 'value' and 'text' properties
            var selectElement = $('#select2Basic');
            // Clear any existing options
            selectElement.empty();
            // Add an empty option if you want to allow clearing
            selectElement.append($('<option>', {
                value: '',
                text: 'Select an option'
            }));
            // Iterate through the data and populate the options
            response.data.forEach(function (item) {
                selectElement.append($('<option>', {
                    value: item.id,
                    text: item.doctorName
                }));
            });

            // Initialize Select2 after updating the options
            selectElement.select2({
                placeholder: 'Select an option',
                allowClear: true
            });
        },
        error: function (error) {
            console.error('Error fetching data:', error);
        }
    });
}

function LoadInvestigation()
{
    $.ajax({
        url: '/Investigation/LoadAllInvestigationList',
        method: 'GET',
        dataType: 'json',
        success: function (response) {
            investigationList = response.data;
            console.log(investigationList);
            // Assuming 'data' is an array of objects with 'value' and 'text' properties
            var selectElement = $('#investigation');
            // Clear any existing options
            selectElement.empty();
            // Add an empty option if you want to allow clearing
            selectElement.append($('<option>', {
                value: '',
                text: 'Select an option'
            }));
            // Iterate through the data and populate the options
            response.data.forEach(function (item) {
                selectElement.append($('<option>', {
                    value: item.id,
                    text: item.investigationName
                }));
            });

            // Initialize Select2 after updating the options
            selectElement.select2({
                placeholder: 'Select an option',
                allowClear: true
            });
        },
        error: function (error) {
            console.error('Error fetching data:', error);
        }
    });
}


function SavePatientAppointment() {
    var form = document.getElementById('patientAppointment'); // Get the form element
    var patientAppointmentDto = $(form).serializeArray(); // Serialize form data
   
    if (form.checkValidity()) {
        // Form is valid, proceed with AJAX request
        $.ajax({
            url: '/PatientAppointment/CreateOrUpdatePatientAppointment',
            type: 'POST',
            data: patientAppointmentDto,
            success: function (response) {
                if (response.success) {
                    console.log(response);
                    clearForm();
                    Swal.fire({icon: 'success',title: response.message,timer: 2000, buttonsStyling: false});
                  //  LoadData();// Reload new data from the server

                } else {
                    Swal.fire({icon: 'error', title: response.errors,showConfirmButton: false,timer: 1800, buttonsStyling: false});
                }
            },
            error: function (xhr, status, error) {
                Swal.fire({ icon: 'error', title: error, showConfirmButton: false, timer: 1500, buttonsStyling: false});
            }
        });


    } else {
        // Form validation failed, prevent default form submission and show validation messages
        form.classList.add('was-validated');
    }
}


function clearForm() {
    
}



