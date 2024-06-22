
appMJEM.controller("Emplyoee.EmplyoeeListController", function ($scope, EmplyoeeDetailsService) {

    $scope.init = function () {
        var GetAll = EmplyoeeDetailsService.GetAll();
        GetAll.then(function (response) {
            var dataModel = response.data;

            $scope.EmployeeList = dataModel;

        },
            function () {
                alert("Service Error to receive data");
            })

    }


    $scope.EmplyoeeDelete = function (Id) {
        var getById = EmplyoeeDetailsService.Delete((parseInt(Id)));
        getById.then(function (response) {
            alert("Emplyoee Details Deleted");
            $scope.init();

        },
       function () {
           alert("Error in Deletion");
       });
    }



    $scope.EmplyoeeEdit = function (id) {
        window.location.href = "/EmployeeMst/Edit/" + id;
    }


});


appMJEM.controller("Emplyoee.EmplyoeeDetailsController", function ($scope, EmplyoeeDetailsService) {
    var ActionType = $('#ActionType').val();


    if (ActionType == "Edit") {
        var Id = $('#ActionId').val();
        var getById = EmplyoeeDetailsService.Get(parseInt(Id));
        getById.then(function (response) {
            var data = response.data;
            $scope.EmplyoeeId = data.EmplyoeeId;
            $scope.EmplyoeeName = data.EmplyoeeName;
            $scope.MobileNumber = data.MobileNumber;
            $scope.GovtId = data.GovtId;
            $scope.Address = data.Address;
        },
       function () {
           alert("Error in EmplyoeeDetails");
       });
    }

    $scope.PerformAction = function () {
        var Emplyoeemodel = {};


        Emplyoeemodel = {
            EmplyoeeId: $scope.EmplyoeeId,
            EmplyoeeName: $scope.EmplyoeeName,
            MobileNumber: $scope.MobileNumber,
            GovtId: $scope.GovtId,
            Address: $scope.Address
        }

        var Promiseget = EmplyoeeDetailsService.Save(Emplyoeemodel);
        Promiseget.then(function (response) {
            if (response.data != null || response.data != undefined) {
                alert(response.data);
                $scope.clearfield();
                window.location.href = "/EmployeeMst/Index";
            }

        })

    }









    $scope.clearfield = function () {
        $scope.EmplyoeeName = "";
        $scope.MobileNumber = "";
        $scope.GovtId = "";
        $scope.Address = "";
        
    }



});