

appMJEM.controller("Customer.CustomerListController", function ($scope, CustomerDetailsService) {

    $scope.init= function ()
    {
        var GetAll = CustomerDetailsService.GetAll();
        GetAll.then(function (response) {
            var dataModel = response.data;
           
            $scope.CustomerList = dataModel;
            
        },
            function () {
                alert("Service Error to receive data");
            })

    }
    

    $scope.CustomerDelete = function (Id) {
        var getById = CustomerDetailsService.Delete((parseInt(Id)));
        getById.then(function (response) {
            alert("Customer Details Deleted");
            $scope.init();

        },
       function () {
           alert("Error in Deletion");
       });
    }



    $scope.CustomerEdit = function (id) {
        window.location.href = "/Customer/Edit/" + id;
    }


});


appMJEM.controller("Customer.CustomerDetailsController", function ($scope, CustomerDetailsService)
{
    var ActionType = $('#ActionType').val();
    
    
    if (ActionType == "Edit")
    {
        var Id = $('#ActionId').val();
        var getById = CustomerDetailsService.Get(parseInt(Id));
        getById.then(function (response)
        {
            var data = response.data;
            $scope.CustomerId = data.CustomerId;
            $scope.CustomerName = data.CustomerName;
            $scope.MobileNumber = data.MobileNumber;
            $scope.CustomerAddress = data.CustomerAddress;
        },
       function () {
           alert("Error in CustomerDetails");
       });
    }

    $scope.PerformAction = function () {
        var customermodel = {};
        

            customermodel ={
           CustomerId: $scope.CustomerId,
           CustomerName: $scope.CustomerName,
           MobileNumber: $scope.MobileNumber,
           CustomerAddress: $scope.CustomerAddress
            }

        var Promiseget = CustomerDetailsService.Save(customermodel);
        Promiseget.then(function (response)
        {
            if (response.data != null || response.data != undefined) {
                alert(response.data);
                $scope.clearfield();
                window.location.href = "/Customer/Index";
            }
            
        })

    }

  




 
    

    $scope.clearfield = function () {
        $scope.CustomerName = "",
        $scope.MobileNumber= "",
        $scope.CustomerAddress = ""
            }



});