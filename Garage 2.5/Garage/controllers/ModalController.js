

Garage.controller('ModalController', ['$scope', '$rootScope', 'GetOwnerList', 'Creator', 'GetVehicleTypes', function ($scope, $rootScope, GetOwnerList, Creator, GetVehicleTypes) {
    console.log('ModalController loaded');
    $scope.ModalTemplate = '1';

    $scope.VehicleTypes = [];
    $scope.OwnersList = [];
    $scope.Vehicles = [];

    $scope.Vehicle = {
        RegNr: '',
        Color: '',
        OwnerPNR: '',
        VehicleTypeId: '',
        
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
        console.log($scope.ModalTemplate);
    };

    $scope.CreateVehicle = function () {
        //if ($scope.CreateVehicleForm.$valid) {
        Creator.Vehicle($scope.Vehicle).then(function (data) {
            if (data.Status == "success")
            {
                $rootScope.$emit('VehiclesChanged');
                console.log('Should broadcast');
            }
                
            console.log(data);
        });
        //}
    };

    $scope.CreateOwner = function () {
        //if ($scope.CreateOwnerForm.$valid) {

        Creator.Owner($scope.Owner).then(function (data) {
            console.log(data);
        });
        //}
    };
    //$scope.CreateVehicle = CreateVehicle;

}])