﻿function Logout() {

    //$.support.cors = true;
    //var Id = localStorage['UserId'];
    //var headerObj = { 'Token': token };

    //$.ajax({
    //    data: Id,
    //    cache: false,
    //    type: 'POST',
    //    url: hostURL + '/api/CSAT/Account/Logout',
    //    cache: false,
    //    async: false,
    //    dataType: "json",
    //    crossDomain: true,
    //    contentType: "application/json",
    //    //headers: headerObj,
    //    beforeSend: function () {

    //    },
    //    success: function (response) {
    //        //console.log(response);
    //        localStorage.clear();
    //        if (response != undefined) {
    //            window.location.href = "/Home/Index";
    //        }
    //    },
    //    complete: function () {

    //    },
    //    error: function (xhr, textStatus, errorThrown) {
    //        if (xhr.status == 404) {
    //            window.location.href = "/Home/Index";
    //        }
    //        else {
    //            return false;
    //        }
    //    }
    //});

    window.location.href = "/Home/Index";
}