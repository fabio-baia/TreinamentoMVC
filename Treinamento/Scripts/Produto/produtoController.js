var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider.when('/list', {
        templateUrl: '/Produto/List',
        controller: 'ListController'
    }).when('/create', {
        templateUrl: '/Produto/Edit',
        controller: 'EditController'
    }).when('/edit/:id', {
        templateUrl: '/Produto/Edit',
        controller: 'EditController'
    }).when('/delete/:id', {
        templateUrl: '/Produto/Delete',
        controller: 'DeleteController'
    }).otherwise({
        redirectTo: '/list'
    });
});

