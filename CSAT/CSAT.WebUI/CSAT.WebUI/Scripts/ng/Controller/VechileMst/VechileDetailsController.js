

appMJEM.controller("Vechile.VechileListController", function ($scope, VechileDetailsService) {

    $scope.init= function ()
    {
       
        var GetAll = VechileDetailsService.GetAll();
        GetAll.then(function (response) {
            var dataModel = response.data;
        
            $scope.VechileList = dataModel;
           
            
        },
            function () {
                alert("Service Error to receive data");
            })

    }
    

    $scope.VechileDelete = function (Id) {
       
        var getById = VechileDetailsService.Delete((parseInt(Id)));
        getById.then(function (response) {
            alert(" Vechile Details Deleted");
            $scope.init();
           

        },
       function () {
           alert("Error in Deletion");
       });
    }



    $scope. VechileEdit = function (id) {
        window.location.href = "/VechileMst/Edit/" + id;
    }


});


appMJEM.controller("Vechile.VechileDetailsController", function ($scope, VechileDetailsService)
{
    var ActionType = $('#ActionType').val();
    
    
    $scope.init = function ()
    {
        var LoadBasicValues = VechileDetailsService.Load();
        LoadBasicValues.then(function (response) {
            $scope.VechileTypeList = response.data;
            $scope.VehcileType = response.data[0].LovId = "";

        },
       function () {
           alert("Error in  VechileDetails");
       });
    }




    if (ActionType == "Edit")
    {
       
        
        
        var Id = $('#ActionId').val();
        setTimeout(function () {
        var getById = VechileDetailsService.Get(parseInt(Id));
        getById.then(function (response)
        {
            var data = response.data;
          
                    $scope.VechileId = data.VechileId;
                    $scope.VechileNumber = data.VechileNumber;
                    $scope.VehcileType = data.VehcileType;
                    
            
        },
       function () {
           alert("Error in  VechileDetails");
       });
        }, 2000);
    }

    $scope.PerformAction = function () {
       
        var  Vechilemodel = {};
     
               Vechilemodel ={
               VechileId: $scope.VechileId,
               VechileNumber: $scope.VechileNumber,
               VehcileType: $scope.VehcileType,
                }

        var Promiseget = VechileDetailsService.Save( Vechilemodel);
        Promiseget.then(function (response)
        {
            if (response.data != null || response.data != undefined)
            {
               
                alert(response.data);
                $scope.clearfield();
                window.location.href = "/VechileMst/Index";
            }
            
        })

    }

  




 
    

    $scope.clearfield = function () {
        $scope.VechileType = "",
        $scope.VechileNumber = ""
        }



});