
var Garage = angular.module('Garage', ['ngRoute', 'ngResource']).config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/", {
            title: 'Home',
            templateUrl: "/routes/index",
            controller: 'MainController'
        })
        .when("/CreateVehicle", {
            title: 'Create Vehicle',
            templateUrl: '/routes/createvehicle',
            controller: 'CreateVehicleFormController'
        })
        .when("/CreatePerson", {
            title: 'Create Person',
            templateUrl: '/routes/createperson',
            controller: 'EditController'
        })
        .when("/Edit/:id", {
            title: 'Edit Vehicle',
            templateUrl: '/routes/edit',
            controller: 'EditController'
        })
        .when("/Details/:id", {
            title: 'Details',
            templateUrl: '/routes/details',
            controller: 'DetailsController'
        })
        .when("/Delete/:id", {
            title: 'Delete',
            templateUrl: '/routes/delete',
            controller: 'DeleteController'
        })
        .otherwise({
            redirectTo: '/',
        });

    if (window.history && window.history.pushState) {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: true
        });
    }
}]).run(function () {
    console.log('angular loaded');
});