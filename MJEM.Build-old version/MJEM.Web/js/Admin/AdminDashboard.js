﻿$(document).ready(function () {
    //Load();
});

function Load() {
    //$.support.cors = true;
    //var token = localStorage['Token'];
    //var headerObj = { 'Token': token };
    //if (token == undefined)
    //    return window.location.href = "/Home/Index";
    //$.ajax({
    //    cache: false,
    //    type: 'GET',
    //    url: hostURL + '/api/CSAT/Admin/Dashboard',
    //    cache: false,
    //    async: false,
    //    dataType: "json",
    //    crossDomain: true,
    //    headers: headerObj,
    //    beforeSend: function () {

    //    },
    //    success: function (response) {
    //        if (response != undefined) {
    //            var customerLst = response["Table2"];
    //            var facilityLst = response["Table1"];
    //            var TotalLst = response["Table"];
    //            console.log(TotalLst);
    //            if (TotalLst != undefined) {
    //                //$('#cnt1span1').text(TotalLst[0].Total);
    //                //$('#cnt1span3').text(parseFloat(TotalLst[1].Total));

    //                //$('#cnt2 span').text(TotalLst[1].Total);
    //                //$('#cnt3 span').text(TotalLst[2].Total);
    //                //$('#cnt4 span').text(TotalLst[3].Total);
    //            }

    //            var tbody = $('#tblFacility tbody'),
    //                props = ["Id", "Name", "Status"];
    //            BindTable(tbody, facilityLst, props);

    //            var tbody = $('#tblCustomer tbody'),
    //                props = ["Id", "Name", "Status"];
    //            BindTable(tbody, customerLst, props);

    //        }
    //    },
    //    complete: function () {

    //    },
    //    error: function (xhr, textStatus, errorThrown) {
    //        if (xhr.status == 404) {
    //           // window.location.href = "/Home/Index";
    //        }
    //        else {
    //            return false;
    //        }
    //    }
    //});
}
function BindTable(tbody, List, props) {
    $.each(List, function (i, lst) {
        var tr = $('<tr>');
        $.each(props, function (id, prop) {
            var td = '<td>'
            if (id == 0) {
                td = '<td class="serial">'
                //$(td).html((i+1) + '</td>').appendTo(tr);
            }
            else if (id == 1) {
               // $(td).html('<span class="name">' + lst[prop] + '</span> </td>').appendTo(tr);
            }
            else if (id == 2) {
               // $(td).html('<span class="badge badge-complete">Active</span>').appendTo(tr);
            }
        });
        tbody.append(tr);
    });
}
