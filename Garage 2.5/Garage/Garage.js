
var Garage = angular.module('Garage', ['ngRoute', 'ngResource']).config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/", {
            title: 'Home',
            templateUrl: "/routes/index",
            controller: 'MainController'
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