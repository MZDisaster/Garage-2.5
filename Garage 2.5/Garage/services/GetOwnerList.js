

Garage.factory('GetOwnerList', ['$http', function ($http) {
    return $http.get('/Home/GetOwners').then(function (response) {
        return angular.fromJson(response.data);
    });
}]);