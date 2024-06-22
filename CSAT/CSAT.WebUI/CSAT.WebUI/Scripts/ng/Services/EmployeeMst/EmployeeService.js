appMJEM.service('EmplyoeeDetailsService', function ($http) {



    this.GetAll = function () {
        var requset = $http.get('/api/EmplyoeeUiAPI/GetAll');
        return requset
    }


    this.Save = function (data) {
        var request = $http({
            method: "post",
            url: '/api/EmplyoeeUiAPI/Save',
            data: JSON.stringify(data),
            headers: { 'Content-Type': 'application/json' }

        });
        return request;
    }

    this.Delete = function (Id) {
        var requset = $http.get('/api/EmplyoeeUiAPI/Delete/' + Id);
        return requset

    }



    this.Get = function (Id) {
        var requset = $http.get('/api/EmplyoeeUiAPI/Get/' + Id);
        return requset

    }
});