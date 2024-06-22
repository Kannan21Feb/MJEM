//// Global declaration variable
//var userAreaList = null;
//var complaintCategory = null;
//var reader = null;

//$(document).ready(function () {
   
//    document.getElementById("logoId").src = "data:image/png;base64," + localStorage['ImgSrc'];
//    reader = new FileReader();
//    $('#error').hide();
//    Load();
//});

//function Load(){
//    $.support.cors = true;
//    $.ajax({
//        cache: false,
//        type: 'GET',
//        url: hostURL +'/api/CSAT/CSSurvey/Load/' + 1 +'/null',
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
//                complaintCategory = response["Table2"];

//                var option = '';
//                $.each(complaintCategory, function (val, text) {
//                    option += '<option value="' + text.ComplaintCategoryID + '">' + text.CategoryName + '</option>';
//                });
//                $('#ddlcomplaintCategory').append(option);

//                BindDropdownVlues(facilityList, '#ddlHospital');
//                BindDropdownVlues(userAreaList, '#ddlUserLocation');
//                var userCode = localStorage['userCode'];
//                var facilityCode=localStorage['facilityCode'];
//                $('#ddlHospital').val(facilityCode);
//                $('#ddlUserLocation').val(userCode);
//                //$("#ddlHospital").get(0).selectedIndex = 1;
//                //$("#ddlUserLocation").get(0).selectedIndex = 1;
//                $("#ddlcomplaintCategory").get(0).selectedIndex = 0;

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


//function Validation() {
//    var _bool = false;
//    var byteData = reader.result;


//    if ($('#ddlcomplaintCategory :selected').val() == "" || $('#ddlUserLocation :selected').val() == ""
//          || $('#ddlHospital :selected').val() == "")
//        { _bool = true };
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
//    var byteData = reader.result;
//    if (byteData != null) {
//        byteData = byteData.split(';')[1].replace("base64,", "");
//    }
//    var ComplaintCategoryID = $('#ddlcomplaintCategory :selected').val();
//    var dataObj = { "UserAreaID": UserAreaID, "ComplaintCategoryID": ComplaintCategoryID, "Comments": $('#txtComments').val(), "ByteData": byteData  };
//    console.log(byteData);
//    $.ajax({
//        cache: false,
//        type: 'POST',
//        url: hostURL +'/api/CSAT/Complaint',
//        cache: false,
//        async: false,
//        data: dataObj,
//        dataType: "json",
//        crossDomain: true,
//        beforeSend: function () {

//        },
//        success: function (response) {
//            window.location.href = "/FeedbackServices/Index";
//            //alert("Updated Successfully!");
//        },
//        complete: function () {
//            window.location.href = "/FeedbackServices/Index";
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

//function readURL(input) {

//    try {
//        if (input.files && input.files[0]) {
//            reader.onload = function (e) {
//                $('#dynamic-image').attr('src', e.target.result);
//                $(".feature_logo").addClass('display_none');
//                $(".delete_link_one").css("cursor", "pointer");
//            };
//            reader.readAsDataURL(input.files[0]);
//            $(".feature_logo").removeClass('display_none');
//        }

//    }
//    catch (err) {

//        $(".feature_logo").addClass('display_none');
//    }
//}