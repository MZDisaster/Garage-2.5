
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
        },
        EditVehicle: function (vehicle) {
            return $http.post('/Home/Edit', vehicle).then(function (response) {
                return angular.fromJson(response.data);
            });
        },
        DeleteVehicle: function (vehicle) {
            var id = vehicle.VehicleId;
            console.log("Deleting " + id);
            return $http.post('/Home/Delete', vehicle).then(function (response) {
                return angular.fromJson(response.data);
            });
        }
    }
}]);