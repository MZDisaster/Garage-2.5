
Garage.factory('Creator', ['$http', function ($http) {
    return {
        Owner: function (owner) {
            return $http.post('/Home/CreateOwner', owner).then(function (response) {
                return angular.fromJson(response.data);
            });
        },
        Vehicle: function (vehicle) {
            return $http.post('/Home/CreateVehicle', vehicle).then(function (response) {
                return angular.fromJson(response.data);
            });
        }
    }
}]);