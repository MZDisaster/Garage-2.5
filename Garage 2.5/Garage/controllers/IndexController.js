
Garage.controller('IndexController', ['$http', '$scope', 'GetVehicleList', 'GetVehicleTypes', function ($http, $scope, GetVehicleList, GetVehicleTypes) {
    console.log('IndexController loaded');
    $scope.DeletedId = 0;
    $scope.Vehicles = [];

    $scope.VehicleTypes = [];

    GetVehicleTypes.then(function (data) {
        console.log('VehicleTypes loaded from server');
        console.log(data);
        $scope.VehicleTypes = data;
    });
    $scope.ReGetAllVehicles = function() {
        $http.get('/Home/getIndex').then(function (response) {
            $scope.Vehicles = angular.fromJson(response.data);
        })
    }
    
    GetVehicleList.then(function (data) {
        console.log('Vehicles Loaded from server:');
        console.log(data);
        $scope.Vehicles = data;
    });
    $scope.GetEditVehicle = function (id) {
        
        for (var i = 0; i < $scope.Vehicles.length; i++) {
            if ($scope.Vehicles[i].Id === id) {
            console.log("found vehicle " + $scope.Vehicles[i].Id);
                return $scope.Vehicles[i];
            }
        }
        return null;
    }
    $scope.GetDeleteVehicle = function (id) {
        $scope.DeletedId = id;
        console.log(id);
        for (var i = 0; i < $scope.Vehicles.length; i++)
        {
            if ($scope.Vehicles[i].Id == id)
            {
                return $scope.Vehicles[i];
            }
        }
        return null;
    }
    $scope.$on('VehiclesChanged', function (evt, data) {
        console.log('event recieved');
        jQuery('.ModalContainer').modal('toggle');
        $scope.ReGetAllVehicles();
    });
    $scope.$on('VehicleDeleted', function (evt, data) {
        console.log('Delete event received');
        jQuery('.ModalContainer').modal('toggle');
        $scope.ReGetAllVehicles();
    })

}]);