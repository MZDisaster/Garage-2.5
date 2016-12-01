

Garage.controller('ModalController', ['$scope', 'GetOwnerList', function ($scope, GetOwnerList) {

    $scope.ModalTemplate = 'CreateVehicle';

    $scope.Open = function (ModalName) {
        console.log('Modal Should Open:');
        console.log(ModalName);
        $scope.ModalTemplate = ModalName;
        jQuery('.ModalContainer').modal('toggle');
        parseData();
    };

    var parseData = function () {
        switch ($scope.ModalTemplate) {
            case "CreateVehicle": {
                (function () {
                    GetOwnerList.then(function (data) {
                        console.log('data should be set to OwnersList');
                        $scope.OwnersList = data;
                    });
                })()
            }
        }
    }
}])