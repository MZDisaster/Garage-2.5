
Garage.controller('IndexController', ['$scope', 'GetVehicleList', function ($scope, GetVehicleList) {
    console.log('index controller loaded');

    $scope.Vehicles = {};

    GetVehicleList.then(function (data) {
        $scope.Vehicles = data;
    });
    

}]);