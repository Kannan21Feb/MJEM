
//var rateId = 0;
//var facilityList = null;
//var userAreaList = null;
//$(document).ready(function () {
//    document.getElementById("logoId").src = "data:image/png;base64," + localStorage['ImgSrc'];
//    $('#error').hide();
//    Load();
//});

//function Load() {

//    var shortKey = $('#hdShortURL').val();
//    console.log(shortKey);
//    if (shortKey == undefined || shortKey == '') {
//        shortKey = null;
//    }

//    $.support.cors = true;
//    $.ajax({
//        cache: false,
//        type: 'GET',
//        url: hostURL + '/api/CSAT/CSSurvey/Load/' + 0 + '/' + shortKey,
//        cache: false,
//        async: false,
//        dataType: "json",
//        crossDomain: true,
//        beforeSend: function () {

//        },
//        success: function (response) {
//            if (response != undefined) {
//                facilityList = response["Table1"];
//                userAreaList = response["Table"];
//                var getUserDetails = response["Table2"];
//                //console.log(getUserDetails);
//                //console.log(facilityList);
//                //console.log(userAreaList);
//                BindDropdownVlues(facilityList, '#ddlHospital');
//                BindDropdownVlues(userAreaList, '#ddlUserLocation');
//                if (getUserDetails == undefined || getUserDetails.length==0) {
//                    $("#ddlHospital").get(0).selectedIndex = 0;
//                    $("#ddlUserLocation").get(0).selectedIndex = 0;
//                    localStorage['userCode'] = '';
//                    localStorage['facilityCode'] = '';
//                }
//                else {
//                    var facilityCode = $.map(facilityList, function (fac, indexInArray) {
//                        if (fac.FacilityID == getUserDetails[0].FacilityID) {
//                            return fac.Code;
//                        }
//                    });
//                    var userCode = $.map(userAreaList, function (user, indexInArray) {
//                        if (user.UserAreaID == getUserDetails[0].UserAreaID) {
//                            return user.Code;
//                        }
//                    });
//                    localStorage['userCode'] = userCode;
//                    localStorage['facilityCode'] = facilityCode;
//                    $('#ddlHospital').val(facilityCode);
//                    $('#ddlUserLocation').val(userCode);

//                }
//                $("#txtHospitalCode").val($('#ddlHospital :selected').val());
//                $("#txtLocationCode").val($('#ddlUserLocation :selected').val());
//            }
//        },
//        complete: function () {

//        },
//        error: function (xhr, textStatus, errorThrown) {
//            if (xhr.status == 440) {
//                window.location.href = "/Login/Index";
//            }
//            else {
//                return false;
//            }
//        }
//    });
//}

//function BindDropdownVlues(items, controlId) {
//    var option = '';
//    $.each(items, function (val, text) {
//        option += '<option value="' + text.Code + '">' + text.Name + '</option>';
//    });
//    $(controlId).append(option);
//}

//function SelectHospital() {
//    $("#txtHospitalCode").val($('#ddlHospital :selected').val());
//}

//function SelectUserLocation() {
//    $("#txtLocationCode").val($('#ddlUserLocation :selected').val());
//}

//function Rating(id) {
//    rateId = id;
//}

//function Validation() {
//    var _bool = false;
//    if (rateId == 0 || $('#ddlUserLocation :selected').val() == "" || $('#ddlHospital :selected').val() == "") { _bool = true };
//    return _bool;
//}

//function Submit() {
//    $('#error').hide();
//    var res = submitter();
//    if (!res) {
//        return;
//    }

//    res = Validation();
//    if (res) {
//        $('#error').show();
//        return;
//    }
//    var UserAreaID = $.map(userAreaList, function (user, indexInArray) {
//        if (user.Code == $('#ddlUserLocation :selected').val()) {
//            return user.UserAreaID;
//        }
//    });
//    var dataObj = { "UserAreaID": UserAreaID, "CssRateID": rateId, "Comments": $('#txtComments').val() }
//    $.ajax({
//        cache: false,
//        type: 'POST',
//        url: hostURL + '/api/CSAT/CSSurvey',
//        cache: false,
//        async: false,
//        data: dataObj,
//        dataType: "json",
//        crossDomain: true,
//        beforeSend: function () {

//        },
//        success: function (response) {
//            if (rateId >= 4) {
//                window.location.href = "/FeedbackServices/Index";
//            }
//            else {
//                window.location.href = "/FeedbackServices/Complaint";
//            }
//            //alert("Updated Successfully!");
//        },
//        complete: function () {
//            if (rateId >= 4) {
//                window.location.href = "/FeedbackServices/Index";
//            }
//            else {
//                window.location.href = "/FeedbackServices/Complaint";
//            }
//        },
//        error: function (xhr, textStatus, errorThrown) {
//            if (xhr.status == 440) {
//                window.location.href = "/FeedbackServices/Index";
//            }
//            else {
//                return false;
//            }
//        }
//    });
//}