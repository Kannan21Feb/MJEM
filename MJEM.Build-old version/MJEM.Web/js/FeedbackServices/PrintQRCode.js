
//$(document).ready(function () {
   
//});


function Submit() {
   // window.location.href = 'http://localhost:56868/api/CSAT/PrintQRCode/';
    $.ajax({
        cache: false,
        type: 'GET',
        url: 'http://localhost:56868/api/CSAT/PrintQRCode/',
        cache: false,
        async: false,
        dataType: "json",
        crossDomain: true,
        complete: function () {
            alert('Print success');
        },
        success: function () {
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr);
        }
    });
}