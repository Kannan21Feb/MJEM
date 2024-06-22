

appMJEM.controller("Location.LocationListController", function ($scope, LocationDetailsService) {

    $scope.init = function () {

        var GetAll = LocationDetailsService.GetAll();
        GetAll.then(function (response) {
            var dataModel = response.data;

            $scope.LocationList = dataModel;


        },
            function () {
                alert("Service Error to receive data");
            })

    }


    $scope.LocationDelete = function (Id) {

        var getById = LocationDetailsService.Delete((parseInt(Id)));
        getById.then(function (response) {
            alert(" Location Details Deleted");
            $scope.init();


        },
       function () {
           alert("Error in Deletion");
       });
    }



    $scope.LocationEdit = function (id) {
        window.location.href = "/LocationMst/Edit/" + id;
    }


});


appMJEM.controller("Location.LocationDetailsController", function ($scope, LocationDetailsService) {
    var ActionType = $('#ActionType').val();


    $scope.init = function () {
        var LoadBasicValues = LocationDetailsService.Load();
        LoadBasicValues.then(function (response) {
            $scope.ParentLocationList = response.data;
            $scope.ParentLocationId = response.data[0].LocationId = "";

        },
       function () {
           alert("Error in  LocationDetails");
       });
    }




    if (ActionType == "Edit") {



        var Id = $('#ActionId').val();
        setTimeout(function () {
            var getById = LocationDetailsService.Get(parseInt(Id));
            getById.then(function (response) {
                var data = response.data;

                $scope.LocationId = data.LocationId;
                $scope.LocationName = data.LocationName;
                $scope.ParentLocationId = data.ParentLocationId;


            },
           function () {
               alert("Error in  LocationDetails");
           });
        }, 2000);
    }

    $scope.PerformAction = function () {

        var Locationmodel = {};

        Locationmodel = {
            LocationId: $scope.LocationId,
            LocationName: $scope.LocationName,
            ParentLocationId: $scope.ParentLocationId,
        }

        var Promiseget = LocationDetailsService.Save(Locationmodel);
        Promiseget.then(function (response) {
            if (response.data != null || response.data != undefined) {

                alert(response.data);
                $scope.clearfield();
                window.location.href = "/LocationMst/Index";
            }

        })

    }



    $scope.clearfield = function () {
        $scope.LocationName = "",
        $scope.ParentLocationId = ""
    }



});