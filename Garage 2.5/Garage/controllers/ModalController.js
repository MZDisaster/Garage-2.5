

Garage.controller('ModalController', ['$scope', 'GetOwnerList', 'Creator', 'GetVehicleTypes', function ($scope, GetOwnerList, Creator, GetVehicleTypes) {
    console.log('ModalController loaded');

    var VM = this;

    $scope.ModalTemplate = 'CreateVehicle';

    $scope.VehicleTypes = {};
    $scope.OwnersList = {};
    $scope.Vehicles = {};

    $scope.Vehicle = {
        RegNr: '',
        Color: '',
        OwnerPNR: '',
        VehicleTypeId: ''
    };

    $scope.Owner = {
        PNR: '',
        Name: ''
    };


    $scope.Open = function (ModalName) {
        console.log('Modal Should Open:\n' + ModalName);
        $scope.ModalTemplate = ModalName;
        jQuery('.ModalContainer').modal('toggle');
        
    };

    GetVehicleTypes.then(function (data) {
        $scope.VehicleTypes = data;
        $scope.defaultSelectedType = $scope.VehicleTypes[0].Name;
    });

    GetOwnerList.then(function (data) {
        console.log('Owners Loaded from server:');
        console.log(data);
        $scope.OwnersList = data;
        $scope.defaultSelectedOwner = $scope.OwnersList[0].Name;
    });

    $scope.checkData = function () {
        console.log('check:');
        console.log($scope.Vehicle);
    }

    $scope.CreateVehicle = function () {
        if ($scope.CreateVehicleForm.$valid) {
            var response = {};
            Creator.Vehicle(VM.$scope.Vehicle).then(function (data) {
                response = data;
            });
            $console.log(response);
        }
    }

    $scope.CreateOwner = function () {
        if (CreateOwnerForm.$valid) {
            Creator.Owner(Owner);
        }
    };
}])