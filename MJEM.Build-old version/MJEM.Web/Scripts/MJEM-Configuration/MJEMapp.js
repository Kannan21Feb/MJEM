//$(document).ready(function () {

//    document.getElementById("loginimg").src = "data:image/png;base64," + localStorage['ImgSrc'];
//    var reader = new FileReader();

//});

var appMJEM = angular.module('appMJEM', [])

////Name - Allow special characters like ‘Space’, Hyphen ‘-‘, Closed brackets ‘()’, At sign '@', Single quote ‘'‘, double quotes ‘"‘, front slash '/', ampersand '&', and underscore '_'
//appMJEM.directive('onlyName', function () {
//    return {
//        require: 'ngModel',
//        restrict: 'A',
//        link: function (scope, element, attrs, modelCtrl) {
//            modelCtrl.$parsers.push(function (inputValue) {
//                if (inputValue == null)
//                    return ''
//                cleanInputValue = inputValue.replace(/[^a-zA-Z0-9\s\-\(\)\_\'\"\@\/\&]\./g, '');
//                if (cleanInputValue != inputValue) {
//                    modelCtrl.$setViewValue(cleanInputValue);
//                    modelCtrl.$render();
//                }
//                return cleanInputValue;
//            });
//        }
//    }
//});

////MobileNumber in UM-User registration Screen
//appMJEM.directive('onlyMobile', function () {
//    return {
//        require: 'ngModel',
//        restrict: 'A',
//        link: function (scope, element, attrs, modelCtrl) {
//            modelCtrl.$parsers.push(function (inputValue) {
//                if (inputValue == null)
//                    return ''

//                if (inputValue != null && inputValue != undefined) {
//                    cleanInputValue = inputValue.replace(/[^0-9]/g, '');

//                    if (cleanInputValue.length > attrs.local) {
//                        cleanInputValue = cleanInputValue.substring(0, attrs.local);
//                    }
//                }

//                if (cleanInputValue != inputValue) {
//                    modelCtrl.$setViewValue(cleanInputValue);
//                    modelCtrl.$render();
//                    // modelCtrl.preventDefault();
//                }

//                return cleanInputValue;
//            });
//            modelCtrl.$formatters.push(function (value) {
//                if (value == undefined)
//                    return;
//                //console.log(modelCtrl);
//                //console.log(attrs);

//                if (attrs.local == undefined)
//                    attrs.local = angular.copy(attrs.maxlength);
//                else
//                    attrs.maxlength = angular.copy(attrs.local);

//                if (value.length > 3) {
//                    var maxlength = (parseInt(attrs.maxlength) + 2);
//                    attrs.$set('maxlength', maxlength.toString());
//                    //attrs.maxlength = maxlength.toString();
//                    var val = value.replace(/[^0-9]/g, "");
//                    var actualValue = val.slice(0, 3) + "-" + value.slice(3, 6) + value.slice(6);
//                    return actualValue;
//                }
//                else {
//                    return value;
//                }
//            });
//            element.bind('keypress', function (event) {
//                if (event.keyCode === 32) {
//                    event.preventDefault();
//                }
//                else {
//                    var actualValue = $(element).val();

//                    if (actualValue != undefined) {
//                        if (actualValue.length == attrs.local) {
//                            event.preventDefault();
//                        }
//                    }
//                }

//            });
//            $(element).focusout(function () {
//                var actualValue = $(element).val();
//                if (actualValue.length > 3) {
//                    if (attrs.local == undefined)
//                        attrs.local = angular.copy(attrs.maxlength);
//                    else
//                        attrs.maxlength = angular.copy(attrs.local);
//                    var maxlength = (parseInt(attrs.maxlength) + 2);
//                    attrs.maxlength = maxlength.toString();
//                    var val = actualValue.replace(/[^0-9]/g, "");
//                    actualValue = val.slice(0, 3) + "-" + val.slice(3, 6) + val.slice(6);
//                    $(element).val(actualValue);
//                }
//            });
//            $(element).focusin(function () {
//                var inputValue = $(element).val();
//                inputValue = inputValue.replace(/[^0-9]/g, '');
//                $(element).val(inputValue);
//            });
//        }
//    }
//});

//appMJEM.directive('mmmDateFormatter', function () {
//    return {
//        restrict: 'A',
//        require: 'ngModel',
//        link: function (scope, element, attr, ngModel) {

//            ngModel.$parsers.push(function (value) {
//                if (typeof value == 'undefined' || value == null || value == "") {
//                    return "";
//                }

//                var isCorrect = value.match(/-/g);
//                if (isCorrect == null) {
//                    return undefined;
//                }
//                if (isCorrect.length > 2) {
//                    return undefined;
//                }
//                var hour, minutes;
//                var from = value.split("-");
//                var day = parseInt(from[0]);

//                var month = parseInt(getMonthFromString(from[1]));
//                var yearAndTime = from[2].split(" ");
//                var isCorrectTimeFormat = from[2].match(/[\s]/g);
//                if (isCorrectTimeFormat != null) {
//                    if (isCorrectTimeFormat.length > 1) {
//                        return undefined;
//                    }
//                }
//                else {
//                    hour = 0;
//                    minutes = 0;
//                }
//                var year = parseInt(yearAndTime[0]);

//                if (!(yearAndTime[1] == undefined)) {
//                    time = yearAndTime[1].split(":");
//                    hour = parseInt(time[0]);
//                    minutes = parseInt(time[1]);

//                    if (!(hour < 24)) {
//                        value = undefined;
//                        return value;
//                    }

//                    if (!(minutes < 61)) {
//                        value = undefined;
//                        return value;
//                    }
//                }
//                else {
//                    hour = 0;
//                    minutes = 0;
//                }

//                if (!(year < 10000)) {
//                    value = undefined;
//                    return value;
//                }

//                if (!(year > 1752)) {
//                    value = undefined;
//                    return value;
//                }
//                if (!(0 < month < 13)) {
//                    value = undefined;
//                    return value;
//                }
//                if ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 10) || (month == 12)) {
//                    if (!(0 < day && day < 32)) {
//                        value = undefined;
//                        return value;
//                    }
//                    else {
//                        var ChangedValue = new Date(Date.UTC(yearAndTime[0], month - 1, from[0], hour, minutes, 0));
//                        return ChangedValue;
//                    }
//                }
//                if ((month == 4) || (month == 6) || (month == 9) || (month == 11)) {
//                    if (!(0 < day && day < 31)) {
//                        value = undefined;
//                        return value;
//                    }
//                    else {
//                        var ChangedValue = new Date(Date.UTC(yearAndTime[0], month - 1, from[0], hour, minutes, 0));
//                        return ChangedValue;
//                    }
//                }
//                if (month == 2) {
//                    var leapYear = year % 4;
//                    if (leapYear == 0) {
//                        if (!(0 < day && day < 30)) {
//                            value = undefined;
//                            return value;
//                        }
//                        else {
//                            var ChangedValue = new Date(Date.UTC(yearAndTime[0], month - 1, from[0], hour, minutes, 0));
//                            return ChangedValue;
//                        }
//                        if (!(0 < day && day < 29)) {
//                            value = undefined;
//                            return value;
//                        }
//                        else {
//                            var ChangedValue = new Date(Date.UTC(yearAndTime[0], month - 1, from[0], hour, minutes, 0));
//                            return ChangedValue;
//                        }

//                    }
//                    if (leapYear != 0) {
//                        if (!(0 < day && day < 29)) {
//                            value = undefined;
//                            return value;
//                        }
//                        else {
//                            var ChangedValue = new Date(Date.UTC(yearAndTime[0], month - 1, from[0], hour, minutes, 0));
//                            return ChangedValue;
//                        }
//                    }
//                }

//            });
//            ngModel.$formatters.push(function (value) {
//                if (typeof value == 'undefined' || value == null) {
//                    return null;
//                }
//                else if (typeof value == 'object') {
//                    return moment(value).format("DD-MMM-YYYY HH:mm");
//                }
//                else {
//                    // convert zone time to utc time
//                    if (value.search('Z') > 0) {
//                        value = value.replace('Z', "");
//                    }
//                    return moment(value).format("DD-MMM-YYYY HH:mm");
//                }
//            });
//        }
//    };
//});





//function reloadSameScreen($scope) {
//    var forms = $('form');
//    var _count = 0;
//    var _count1 = 0;
    

//    angular.forEach(forms, function (data, index) {
//        var form = $scope[data.name];
//        _count1++;
//        if (form) {
//            if (form.$dirty) {
//                _count++;

//            }
//        }
//        if (forms.length == _count1) {
//            if (_count > 0) {
//                bootbox.dialog({
//                    message: "Record(s) not Saved/Updated. Do you want to continue?",
//                    onEscape: function () { },
//                    closeButton: true,
//                    buttons: {
//                        success: {
//                            label: "Yes",
//                            className: "btn-primary",
//                            callback: function (result) {
//                                if (result) {
//                                    window.location.reload(true);
//                                }
//                            }

//                        },
//                        "No": {
//                            className: "btn-grey",
//                            callback: function () { }

//                        },
//                    }
//                });
//            }
//            else {
//                window.location.reload(true);
//            }
//        }

//    });
//}

