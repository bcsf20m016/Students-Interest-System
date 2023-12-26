$(document).ready(function () {
    $('#StudentsTable').DataTable({
        "bDestroy": true,
        pagingType: 'full_numbers',
        lengthMenu: [[5, 10, 20, 30, 50], [5, 10, 20, 30, 50]],
        pageLength: 10,
        "language": {
            "info": "Page _PAGE_ of _PAGES_",
            "paginate": {
                "first": "<<",
                "previous": "<",
                "next": ">",
                "last": ">>"
            }
        }
    });

    // Event handler for page size change
    $('#StudentsTable').on('length.dt', function (e, settings, len) {
        logActivity('Page size changed');
    });

    // Event handler for page change
    $('#StudentsTable').on('page.dt', function () {
        logActivity('Page changed');
    });

});

function logActivity(activity) {
    // Use AJAX to send a request to the server to log the activity
    $.ajax({
        url: '/ActionLogger/LogDataTableActivity',
        type: 'POST',
        data: { activity: activity },
        success: function (response) {
            // Handle success if needed
        },
        error: function (error) {
            // Handle error if needed
        }
    });
}