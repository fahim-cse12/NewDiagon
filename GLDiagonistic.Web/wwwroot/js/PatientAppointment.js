
var doctorId = 0;
var doctorList = [];
var investigationList = [];
var dtAppointment;

$(document).ready(function () {
    LoadDoctorList();

  //  LoadAllCurrentAppointments();
    var selectElement = $('#select2Basic');

    selectElement.on('change', function () {
        var selectedDoctorId = $(this).val();
        doctorId = selectedDoctorId;
        console.log('Selected doctorId ID:', selectedDoctorId);

        // Find the doctor in the doctorList based on the selectedDoctorId
        var selectedDoctor = doctorList.find(function (doctor) {
            var doctor_Id = doctor.Id;
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

            var selectElement = $('#select2Basic');
            selectElement.empty();
            selectElement.append($('<option>', {
                value: '',
                text: 'Select an option'
            }));

            response.data.forEach(function (item) {
                selectElement.append($('<option>', {
                    value: item.id,
                    text: item.doctorName
                }));
            });

            selectElement.select2({
                placeholder: 'Select an option',
                allowClear: true
            }).on('change', function () {
                var selectedDoctorId = $(this).val();
                var selectedDoctor = doctorList.find(function (doctor) {
                    return doctor.id == selectedDoctorId;
                });

                var feeSelectElement = $('#doctorFee');
                feeSelectElement.empty();
                feeSelectElement.append($('<option>', {
                    value: '',
                    text: 'Select an option'
                }));

                if (selectedDoctor) {
                    feeSelectElement.append($('<option>', {
                        value: selectedDoctor.doctorsFee.forNew,
                        text: 'For New: ' + selectedDoctor.doctorsFee.forNew
                    }));

                    feeSelectElement.append($('<option>', {
                        value: selectedDoctor.doctorsFee.forOld,
                        text: 'For Old: ' + selectedDoctor.doctorsFee.forOld
                    }));
                }

                feeSelectElement.select2({
                    placeholder: 'Select an option',
                    allowClear: true
                });
            });
        },
        error: function (error) {
            console.error('Error fetching data:', error);
        }
    });
}
$('#doctorFee').on('change', function () {
    var selectedFeeOption = $(this).find('option:selected').text();
    var feeType = selectedFeeOption.split(':')[0].trim(); // This will be either "For New" or "For Old"
    var patientType = feeType.split(' ')[1]; // This will be either "New" or "Old"
    $('#patientType').val(patientType);

    console.log(patientType);
});

$('#doctorFee, #paymentAmount').on('input', function () {
    var selectedFeeOption = $('#doctorFee').find('option:selected').text();
    var feeAmount = parseFloat(selectedFeeOption.split(':')[1].trim()); // Extract the fee amount from the selected option
    var paymentAmount = parseFloat($('#paymentAmount').val()); // Get the payment amount entered by the user

    if (isNaN(feeAmount)) {
        feeAmount = 0; // If no fee is selected, consider it as 0
    }
    if (isNaN(paymentAmount)) {
        paymentAmount = 0; // If no payment is entered, consider it as 0
    }

    var dueAmount = feeAmount - paymentAmount; // Calculate the due amount
    $('#dueAmount').val(dueAmount.toFixed(2)); // Set the due amount in the #dueAmount field
});

function SavePatientAppointment() {
    var form = document.getElementById('patientAppointment');
    var patientAppointmentDto = $(form).serializeArray();
    //var patientAppointmentDto = {
    //    Id: $('#appointmentId').val(),
    //    PatientName: $('#patientname').val(),
    //    PatientAge: $('#age').val(),
    //    PatientGender: $('#gender').val(),
    //    MobileNo: $('#contactNumber').val(),
    //    PatientAddress: $('#address').val(),
    //    PatientType: $('#patientType').val(),
    //    DoctorId: $('#select2Basic').val(),
    //    DoctorsFee: $('#doctorFee').val(),
    //    Paid: $('#paymentAmount').val(),
    //    Due: $('#dueAmount').val()
    //};
   
    if (form.checkValidity()) {
        // Form is valid, proceed with AJAX request
        $.ajax({
            url: '/PatientAppointment/CreateOrUpdatePatientAppointment',
            type: 'POST',
            /*data: JSON.stringify(patientAppointmentDto),*/
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



