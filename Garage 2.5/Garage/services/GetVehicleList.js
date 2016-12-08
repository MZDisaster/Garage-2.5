
Garage.factory('GetVehicleList', ['$http', function ($http) {
    return $http.get('/Home/getIndex').then(function (response) {
        console.log("Här smällere");
        console.log(response);
        return angular.fromJson(response.data);
    });
}]);