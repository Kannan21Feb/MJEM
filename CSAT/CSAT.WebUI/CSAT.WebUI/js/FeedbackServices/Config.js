﻿//var hostURL = 'http://localhost:56868';
//var token = localStorage['Token'];
//var userId=localStorage['UserId'];


//$(document).ready(function () {
//    if (localStorage["ImgSrc"] === null || localStorage["ImgSrc"] === undefined) {
//        $.ajax({
//            cache: false,
//            type: 'GET',
//            url: hostURL + '/api/CSAT/GetImage',
//            cache: false,
//            async: false,
//            dataType: "json",
//            crossDomain: true,
//            beforeSend: function () {

//            },
//            success: function (response) {
//                console.log(response);
//                if (response != undefined) {
//                    localStorage["ImgSrc"] = response;
//                }
//            },
//            complete: function () {

//            },
//            error: function (xhr, textStatus, errorThrown) {
//                if (xhr.status == 440) {
//                    window.location.href = "/Login/Index";
//                }
//                else {
//                    return false;
//                }
//            }
//        });
//    }
//});
