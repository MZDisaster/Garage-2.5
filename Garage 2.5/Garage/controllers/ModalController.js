

Garage.controller('ModalController', ['$scope', '$rootScope', 'GetOwnerList', 'Creator', 'GetVehicleTypes', function ($scope, $rootScope, GetOwnerList, Creator, GetVehicleTypes) {
    console.log('ModalController loaded');
    $scope.ModalTemplate = '1';

    $scope.OwnersList = [];
    $scope.VehicleTypes = [];
    

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

    $scope.EditVehicle = {
        VehicleId: '',
        RegNr: '',
        Color: '',
        PNR: '',
        TypeId: 1,
        Owner: {},
        VehicleType: {}
    }
    $scope.DeleteVehicle = {
        VehicleId: '',
        RegNr: '',
        Color: '',
        PNR: '',
        TypeId: '',
        Owner: {},
        VehicleType: {}
    }
    $scope.GetDeleteOwnerName = function(id)
    {
        return $scope.OwnersList.sort(function (a, b) { if (a.PNR === id) { return -1 } if (b.PNR === id) { return 1 } return 0 })[0].Name;
    }
    $scope.GetDeleteTypeName = function(id)
    {
        return $scope.VehicleTypes.sort(function (a, b) { if (a.TypeId === id) { return -1 } if (b.TypeId === id) { return 1 } return 0 })[0].Name;
    }

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
                console.log('Should broadcast');
                $rootScope.$broadcast('VehiclesChanged', null);
                $scope.Vehicle = {
                    RegNr: '',
                    Color: '',
                    OwnerPNR: '',
                    VehicleTypeId: '',

                };
            }           
            console.log(data);
        });
        
        //}
    };
    $scope.SetEditVehicle = function(editv)
    {
        if (editv != null)
        {
            $scope.EditVehicle.TypeId = (editv.VehicleType == "Car" ? 1 : (editv.VehicleType == "Boat" ? 2 : (editv.VehicleType == "Truck" ? 3 : 4)));
            console.log(editv.VehicleType);
            $scope.EditVehicle.VehicleId = editv.Id;
            $scope.EditVehicle.Color = editv.Color;
            $scope.EditVehicle.RegNr = editv.RegNr;
            $scope.EditVehicle.PNR = editv.PNR;
            
        }
        
    }
    $scope.SetDeleteVehicle = function(delv)
    {
        if (delv != null)
        {
            $scope.DeleteVehicle.VehicleId = delv.Id;
            $scope.DeleteVehicle.Color =     delv.Color;
            $scope.DeleteVehicle.RegNr =     delv.RegNr;
            $scope.DeleteVehicle.PNR =       delv.PNR;
            $scope.DeleteVehicle.TypeId =   (delv.VehicleType == "Car") ? 1 : (delv.VehicleType == "Boat") ? 2 : (delv.VehicleType == "Truck") ? 3 : 4;
        }
    }
    $scope.EditTheVehicle = function () {
        Creator.EditVehicle($scope.EditVehicle).then(function (data) {
            if (data.Status == "success")
            {
                $rootScope.$broadcast('VehiclesChanged',null);
                console.log('Edited vehicle');
            }
            console.log(data);
        })
    }
    $scope.DeleteTheVehicle = function () {
        Creator.DeleteVehicle($scope.DeleteVehicle).then(function (data) {
            if (data.Status == "success")
            {
                console.log('Deleted Vehicle');
                $rootScope.$broadcast('VehicleDeleted',null);
            }
            console.log(data);
        })
    }

    $scope.CreateOwner = function () {
        //if ($scope.CreateOwnerForm.$valid) {

        Creator.Owner($scope.Owner).then(function (data) {
            console.log(data);
        });
        //}
    };
    //$scope.CreateVehicle = CreateVehicle;

}])