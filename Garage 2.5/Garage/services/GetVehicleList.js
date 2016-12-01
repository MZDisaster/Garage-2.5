
Garage.factory('GetVehicleList', ['$http', function ($http) {
    return $http.get('/Home/getIndex').then(function (response) {
        return angular.fromJson(response.data);
    });
}]);