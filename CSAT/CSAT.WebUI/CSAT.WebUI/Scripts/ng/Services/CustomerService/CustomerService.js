appMJEM.service('CustomerDetailsService', function ($http) {



    this.GetAll = function ()
    {
        var requset = $http.get('/api/CustomerUiAPI/GetAll');
        return requset
    }


    this.Save=function(data)
    {
        var request = $http({
            method: "post",
            url: '/api/CustomerUiAPI/Save',
            data: JSON.stringify(data),
            headers: { 'Content-Type': 'application/json' }

        });
        return request;
    }

    this.Delete = function (Id) {
        var requset = $http.get('/api/CustomerUiAPI/Delete/' + Id);
        return requset

    }



    this.Get = function (Id) {
        var requset = $http.get('/api/CustomerUiAPI/Get/'+Id);
        return requset
        
    }
});