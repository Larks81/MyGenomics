var app = angular.module('MyGenomicsApp', ['ngResource', 'appServices', 'ngRoute', 'ui.bootstrap']);

app.config([
    '$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        $routeProvider.when('/areariservata', {
            templateUrl: '/App/views/areariservata.html',
            controller: 'areariservataController'
        })
        .when('/login', {
            templateUrl: '/App/views/login.html',
            controller: 'loginController'
        })
        .otherwise({
            redirectTo: '/areariservata'
        });

        // Specify HTML5 mode (using the History APIs) or HashBang syntax.
    $locationProvider.html5Mode(true).hashPrefix('!');

}]);

app.factory('authHttpResponseInterceptor', ['$rootScope', '$window', '$q', '$location',
    function ($rootScope, $window, $q, $location) {
        return {
            request: function(config) {

                config.headers = config.headers || {};
                if ($window.sessionStorage.token && $window.sessionStorage.token != "") {
                    config.headers.Authorization = 'Bearer ' + $window.sessionStorage.token;
                }
                return config;
            },
            response: function(response) {
                if (response.status === 401) {
                    var returnPath = $location.$$url;
                    $location.path('/login').search('returnTo', returnPath);
                }
                return response || $q.when(response);
            },
            responseError: function(rejection) {
                if (rejection.status === 401) {
                    var returnPath = $location.$$url;
                    $location.path('/login').search('returnTo', returnPath);
                }
                return $q.reject(rejection);
            }
        };
    }])
.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push('authHttpResponseInterceptor');
}]);