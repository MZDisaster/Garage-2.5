
Garage.controller('IndexController', ['$scope', 'GetVehicleList', 'GetVehicleTypes', function ($scope, GetVehicleList, GetVehicleTypes) {
    console.log('IndexController loaded');

    $scope.Vehicles = {};

    $scope.VehicleTypes = {};

    GetVehicleTypes.then(function (data) {
        Console.log('VehicleTypes loaded from server');
        console.log(data);
        $scope.VehicleTypes = data;
    });

    GetVehicleList.then(function (data) {
        console.log('Data Loaded from server:');
        console.log(data);
        $scope.Vehicles = data;
    });
    

}]);