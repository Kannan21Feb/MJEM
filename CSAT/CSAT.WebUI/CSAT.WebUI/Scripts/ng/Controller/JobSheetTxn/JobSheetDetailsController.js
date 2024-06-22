

appMJEM.controller("JobSheet.JobSheetListController", function ($scope, JobSheetDetailsService) {

    $scope.init = function () {

        var GetAll = JobSheetDetailsService.GetAll();
        GetAll.then(function (response) {
            var dataModel = response.data;

            $scope.JobSheetList = dataModel;


        },
            function () {
                alert("Service Error to receive data");
            })

    }


    $scope.JobSheetDelete = function (Id) {

        var getById = JobSheetDetailsService.Delete((parseInt(Id)));
        getById.then(function (response) {
            alert(" JobSheet Details Deleted");
            $scope.init();


        },
       function () {
           alert("Error in Deletion");
       });
    }



    $scope.JobSheetEdit = function (id) {
        window.location.href = "/JobSheetTxn/Edit/" + id;
    }



});


appMJEM.controller("JobSheet.JobSheetDetailsController", function ($scope, JobSheetDetailsService) {
    var ActionType = $('#ActionType').val();
    $scope.TxnId = $('#ActionId').val();

    $scope.JobSheetTxnDetList = [];
    $scope.LocationIds = 0;

    $scope.init = function () {
        var LoadBasicValues = JobSheetDetailsService.Load();
        LoadBasicValues.then(function (response)
        {
            $scope.JobSheetLoadValues = response.data;

            $scope.CustomersList =  Enumerable.From($scope.JobSheetLoadValues.Customers).OrderBy(x=>x.CustomerId).ToArray();
            $scope.ParentLocationsList = Enumerable.From($scope.JobSheetLoadValues.ParentLocations).OrderBy(x=>x.LocationId).ToArray();

            $scope.EmployeesList = Enumerable.From($scope.JobSheetLoadValues.Employees).OrderBy(x=>x.EmplyoeeId).ToArray();
            $scope.VechilesList = Enumerable.From($scope.JobSheetLoadValues.Vechiles).OrderBy(x=>x.VechileId).ToArray();
            $scope.DiselProviderList = Enumerable.From($scope.JobSheetLoadValues.DiselFrom).OrderBy(x=>x.LovId).ToArray();

            $scope.CustomerId =$scope.CustomersList[0].CustomerId = "";
            $scope.ParentLocationId = $scope.ParentLocationsList[0].LocationId = "";




            $scope.EmplyoeeId = $scope.EmployeesList[0].EmplyoeeId = "";
            $scope.VechileId = $scope.VechilesList[0].VechileId = "";
            $scope.LovId = $scope.DiselProviderList[0].LovId = "";
            


            if (ActionType != "Edit") {
                $scope.addnew();
            }
            

        },
       function () {
           alert("Error in  JobSheetDetails");
       });
    }

    $scope.SubLocation=function()
    {
        var Parentlocation = { ParentLocationId: $scope.ParentLocationId }
        var getById = JobSheetDetailsService.SubLocation(Parentlocation);
        getById.then(function (response)
        {
            var data = response.data;

            $scope.locationsList = data;
            $scope.LocationId = $scope.locationsList[0].LocationId = "";
            if ($scope.LocationIds!=0) {
                $scope.LocationId = $scope.LocationIds;
            }

        },
       function () {
           alert("Error in Site Details Fetch");
       });
    }
    

    //var date = new Date();
    //var day = date.getDate();
    //var month_index = date.getMonth()==0?1:date.getMonth()+1;
    //var year = date.getFullYear();

    //var currentDate = day.toString() + '-' + month_index + '-' + year;


    $scope.OnChangeTotalValues = function (flag, index)
    {
        switch (flag)
        {
            case "RunningHours": {

                $scope.TotalRunningHours = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.RunningHours));
                $scope.JobSheetTxnDetList[index].TotalBill = ($scope.JobSheetTxnDetList[index].RunningHours * $scope.JobSheetTxnDetList[index].Rate)
                $scope.OutstandingAmount = (Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.TotalBill))) - (Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.Advance)))
                $scope.TotalBillRs = (Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.TotalBill)))
                break;
            }
            case "DieselLtr": {
                $scope.TotalDiselUsed = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.DieselLtr));
                break;
            }
            case "DieselRate": {
                $scope.TotalDiselRs = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.DieselRate));
                break;
            }
            case "Advance": {
                $scope.TotalAdvanceAmount = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.Advance))
                $scope.OutstandingAmount = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.TotalBill)) - $scope.TotalAdvanceAmount;
                break;
            }
            case "DriverBeta": {
                $scope.TotalDriverBeta = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.DriverBeta));
                break;
            }
            case "Rate": {
                $scope.OutstandingAmount = (Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.TotalBill))) - (Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.Advance)))
                $scope.JobSheetTxnDetList[index].TotalBill = ($scope.JobSheetTxnDetList[index].RunningHours * $scope.JobSheetTxnDetList[index].Rate)
                $scope.TotalBillRs = (Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.TotalBill)))
                break;
            }

            case "Edit":

               {
                   $scope.TotalRunningHours = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.RunningHours));
                   $scope.OutstandingAmount = (Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.TotalBill))) - (Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.Advance)))
                   $scope.TotalDiselUsed = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.DieselLtr));
                   $scope.TotalDiselRs = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.DieselRate));
                   $scope.TotalAdvanceAmount = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.Advance))
                   $scope.TotalDriverBeta = Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.DriverBeta));
                   $scope.TotalBillRs = (Enumerable.From($scope.JobSheetTxnDetList).Sum(x=>parseInt(x.TotalBill)))
                   break;
            }
            default: {
                break;
            }

        }
    }

    $scope.addnew=function()
    {
        var empty =
            {
                JobTxnSheetDetId: 0,
                JobSheetTxnId: $scope.JobSheetTxnId,
                DateTime: new Date(),
                VechileList: $scope.VechilesList,
                VechileId:"",
                RunningHours:0,
                EmplyoeeList: $scope.EmployeesList,
                EmplyoeeId: "",
                DieselFrom:"",
                DieselLtr:0,
                DieselRate:0.00,
                Advance: 0.00,
                Rate: 0.00,
                DriverBeta: 0.00,
                DieselFromList: $scope.DiselProviderList,
                IsDeleted: false
                

            };

        //$scope.EmployeeId = empty[0].EmployeesList[0].LovId = "";
        //$scope.VehcileId = empty[0].VechilesList[0].LovId = "";
        //$scope.DiselFrom = empty[0].DiselProviderList[0].LovId = "";

        $scope.JobSheetTxnDetList.push(empty);
    }

    if (ActionType == "Edit") {



        var Id = $('#ActionId').val();
        setTimeout(function () {
            var getById = JobSheetDetailsService.Get(parseInt(Id));
            getById.then(function (response) {
                var data = response.data;
                $scope.ParentLocationId = data.ParentLocationId;
                if (data.ParentLocationId!=undefined)
                {
                    $scope.SubLocation();
                }
              
                    $scope.JobSheetTxnId = data.JobSheetTxnId;
                    $scope.CustomerId = data.CustomerId;
                    $scope.LocationIds = data.LocationId;
                    
                    
                    
                    $scope.JobSheetTxnDetList = data.JobSheetTxnDet;
                    angular.forEach($scope.JobSheetTxnDetList, function (data, index) {
                        $scope.JobSheetTxnDetList[index].TotalBill = ($scope.JobSheetTxnDetList[index].RunningHours * $scope.JobSheetTxnDetList[index].Rate);
                        
                        $scope.JobSheetTxnDetList[index].DateTime = new Date($scope.JobSheetTxnDetList[index].Date.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"));
                    });
                    $scope.OnChangeTotalValues("Edit", 0);
               
            },
           function () {
               alert("Error in  JobSheetDetails");
           });
        }, 2000);
    }

    $scope.PerformAction = function () {

        var JobSheetmodel = {};
        var JobSheetTxnDetmodel = {};


        JobSheetmodel = {
            JobSheetTxnId: $scope.JobSheetTxnId,
            CustomerId: $scope.CustomerId,
            LocationId: $scope.LocationId,
            JobSheetTxnDet: $scope.JobSheetTxnDetList
        }

        var Promiseget = JobSheetDetailsService.Save(JobSheetmodel);
        Promiseget.then(function (response) {
            if (response.data != null || response.data != undefined) {

                alert(response.data);
                $scope.clearfield();
                window.location.href = "/JobSheetTxn/Index";
            }

        })

    }

    $scope.clearfield = function ()
    {
        $scope.CustomerId = "",
        $scope.LocationId = ""
    }


       
    $scope.Export = function (Id, exportType) {

        if (exportType == 'Pdf') {
            var $downloadForm = $("<form method='POST'>")
            .attr("action", "/api/JobSheetTxnUiAPI/Export/" + +Id + "/" + exportType)
            $("body").append($downloadForm);
            var status = $downloadForm.submit();
            $downloadForm.remove();
        }
        else {
            var promiseAction = JobSheetDetailsService.ExportExcel(Id, exportType);
                promiseAction.then(function (response) {
                var a = document.createElement('a');
                var data_type = 'data:application/vnd.ms-excel';
                a.href = data_type + ', ' + encodeURIComponent(response.data.m_StringValue);
                a.download = "Magarajothi Earth Movers-Kotagiri" + "(" + DateFormat() + ")" + '.xls';
                a.click();

                },
            function (errorPl) 
            {
                //$scope.errorlist
                //$scope.errordisplay = true;
                //$scope.errorlist.push(errorPl.data.Message);
                alert(errorPl.data.Message);
            });


        }

        DateFormat = function () {
            var month_names = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
            var date = new Date();
            var day = date.getDate();
            var month_index = date.getMonth();
            var year = date.getFullYear();
            return "" + day + "-" + month_names[month_index] + "-" + year;
        }


    }


});