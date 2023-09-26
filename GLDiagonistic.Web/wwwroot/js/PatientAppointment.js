
var doctorId = 0;
var doctorList = [];

$(document).ready(function () {
    var selectElement = $('#select2Basic');
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

    //selectElement.on('change', function () {
    //    var selectedDoctorId = $(this).val();
    //    doctorId = selectedDoctorId;

    //    console.log('Selected doctorId ID:', selectedDoctorId);
    //    var selectedDoctor = doctorList.find(function (doctorId) {
    //        return doctor = doctorId;
    //    });

    //    console.log(selectedDoctor);
    //    $('#doctorFee').val(selectedDoctor.doctorsFee);
        
        
    //});

});

function clearForm() {
    $('#select2Basic').val(null);
    $('#currentNoUser').val('');
    $('#currentuserlimit').val('');
    $('#rquestuserlimit').val('');
    $('#rererenceFile').val('');
    $('#selectedReference').text('');
    // Clear the file input if needed
}



