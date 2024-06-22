appMJEM.service('LocationDetailsService', function ($http) {



    this.GetAll = function () {
        var requset = $http.get('/api/LocationUiAPI/GetAll');
        return requset
    }

    this.Load = function () {
        var requset = $http.get('/api/LocationUiAPI/Load');
        return requset
    }

    this.Save = function (data) {
        var request = $http({
            method: "post",
            url: '/api/LocationUiAPI/Save',
            data: JSON.stringify(data),
            headers: { 'Content-Type': 'application/json' }

        });
        return request;
    }

    this.Delete = function (Id) {
        var requset = $http.get('/api/LocationUiAPI/Delete/' + Id);
        return requset

    }



    this.Get = function (Id) {
        var requset = $http.get('/api/LocationUiAPI/Get/' + Id);
        return requset

    }

});