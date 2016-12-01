

Garage.controller('ModalController', ['$scope', 'GetOwnerList', 'Creator', 'GetVehicleTypes', function ($scope, GetOwnerList, Creator, GetVehicleTypes) {
    console.log('ModalController loaded');
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
    });

    GetOwnerList.then(function (data) {
        console.log('Owners Loaded from server:');
        console.log(data);
        $scope.OwnersList = data;
    });

    $scope.checkData = function () {
        console.log('check:');
        console.log($scope.OwnersList);
    }

    var CreateVehicle = function () {
        if ($scope.CreateVehicleForm.$valid) {
            Creator.Vehicle($scope.Vehicle);
        }
    }

    var CreateOwner = function () {
        if ($scope.CreateOwnerForm.$valid) {
            Creator.Owner($scope.Owner);
        }
    };
}])