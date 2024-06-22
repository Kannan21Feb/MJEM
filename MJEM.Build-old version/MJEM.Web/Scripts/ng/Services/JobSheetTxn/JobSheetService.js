appMJEM.service('JobSheetDetailsService', function ($http) {



    this.GetAll = function () {
        var requset = $http.get('/api/JobSheetTxnUiAPI/GetAll');
        return requset
    }

    this.Load = function () {
        var requset = $http.get('/api/JobSheetTxnUiAPI/Load');
        return requset
    }

    this.Save = function (data) {
        var request = $http({
            method: "post",
            url: '/api/JobSheetTxnUiAPI/Save',
            data: JSON.stringify(data),
            headers: { 'Content-Type': 'application/json' }

        });
        return request;
    }

    this.Delete = function (Id) {
        var requset = $http.get('/api/JobSheetTxnUiAPI/Delete/' + Id);
        return requset
    }



    this.Get = function (Id) {
        var requset = $http.get('/api/JobSheetTxnUiAPI/Get/' + Id);
        return requset

    }

    this.ExportExcel = function (Id, ExportType) {
        var requset = $http.get('/api/JobSheetTxnUiAPI/Export/' + Id + '/' + ExportType);
        return requset
    }


    this.SubLocation = function (data) {
        var request = $http({
            method: "post",
            url: '/api/JobSheetTxnUiAPI/SubLocation',
            data: JSON.stringify(data),
            headers: { 'Content-Type': 'application/json' }

        });
        return request;
    }



});