

Garage.factory('GetVehicleTypes', ['$http', function ($http) {
    return $http.get('/Home/GetVehicleTypes').then(function (response) {
        return angular.fromJson(response.data);
    });
}]);