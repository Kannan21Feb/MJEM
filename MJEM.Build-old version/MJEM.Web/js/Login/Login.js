﻿
//$(document).ready(function () {

//});


function Submit() {
    var uname = $('#txtusername').val();
    var pword = $('#txtpassword').val();
    if ((uname == undefined || uname == '') && (pword == undefined || pword == ''))
        return alert('Enter the username and password');

    //var headerObj = { 'Authorization': 'Basic ' + btoa(uname + ':' + pword) };
    //$.ajax({
    //    //data:null,
    //    url: 'http://localhost:56868/api/CSAT/Account/login',
    //    method: "GET",
    //    //dataType: "jsonp",
    //    crossDomain: true,
    //    contentType: "application/json; charset=utf-8",
    //    //data: JSON.stringify(data),
    //    cache: false,
    //    headers: headerObj,
    //    success: function (data, textStatus, response) {
    //        //console.log(response.getAllResponseHeaders());
    //        var token = response.getResponseHeader('Token');
    //        var userId = response.getResponseHeader('UserId');
    //        if (token != undefined && userId != undefined) {
    //            localStorage['Token'] = token;
    //            localStorage['UserId'] = userId;
    //        }
    //        //console.log(token);
    //        window.location.href = '/Admin/Index';
    //        //'http://localhost:56713/FeedbackServices/QRCodePrint';
    //    },
    //    error: function (xhr, textStatus, errorThrown) {
    //        alert('login failed');
    //        console.log(xhr);
    //    }
    //});

    if (uname=="Admin" && pword=="Admin")
    {
        window.location.href = '/Admin/Index'
    }
    else
    {
        alert("Invalid Credentials");
    }
}