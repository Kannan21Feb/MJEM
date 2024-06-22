appMJEM.service('VechileDetailsService', function ($http) {



    this.GetAll = function ()
    {
        var requset = $http.get('/api/VechileUiAPI/GetAll');
        return requset
    }

    this.Load = function () {
        var requset = $http.get('/api/VechileUiAPI/Load');
        return requset
    }

    this.Save=function(data)
    {
        var request = $http({
            method: "post",
            url: '/api/VechileUiAPI/Save',
            data: JSON.stringify(data),
            headers: { 'Content-Type': 'application/json' }

        });
        return request;
    }

    this.Delete = function (Id) {
        var requset = $http.get('/api/VechileUiAPI/Delete/' + Id);
        return requset

    }



    this.Get = function (Id) {
        var requset = $http.get('/api/VechileUiAPI/Get/'+Id);
        return requset
        
    }

});