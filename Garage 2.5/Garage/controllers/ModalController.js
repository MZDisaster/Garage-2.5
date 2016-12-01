

Garage.controller('ModalController', ['$scope', 'GetOwnerList', function ($scope, GetOwnerList) {
    console.log('ModalController loaded');
    $scope.ModalTemplate = 'CreateVehicle';

    $scope.Open = function (ModalName) {
        console.log('Modal Should Open:\n' + ModalName);
        $scope.ModalTemplate = ModalName;
        jQuery('.ModalContainer').modal('toggle');
        parseData();
    };

    var parseData = function () {
        switch ($scope.ModalTemplate) {
            case "CreateVehicle": {
                (function () {
                    GetOwnerList.then(function (data) {
                        console.log('Owners Loaded from server:');
                        console.log(data);
                        $scope.OwnersList = data;
                    });
                })()
            }
        }
    }
}])