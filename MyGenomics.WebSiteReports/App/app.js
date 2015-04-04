var app = angular.module('MyGenomicsApp', ['ngResource', 'appServices', 'ngRoute', 'ui.bootstrap']);

app.config([
    '$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        $routeProvider.when('/login', {
            templateUrl: '/App/views/login.html',
            controller: 'loginController',
            title: 'Login'
        })
        .when('/dashboard', {
            templateUrl: '/App/views/dashboard.html',
            controller: 'mainController',
            title: 'Dashboard'
        })
        .when('/pannelli', {
            templateUrl: '/App/views/pannelli.html',
            controller: 'mainController',
            title: 'Pannelli'
        })
        .when('/capitoli', {
            templateUrl: '/App/views/capitoli.html',
            controller: 'mainController',
            title: 'Capitoli'
        })
        .when('/genotests', {
            templateUrl: '/App/views/genotests.html',
            controller: 'mainController',
            title: 'Genotests'
        })
        .when('/livelli', {
            templateUrl: '/App/views/livelli.html',
            controller: 'mainController',
            title: 'Livelli'
        })
        .otherwise({
            redirectTo: '/login'
        });

        // Specify HTML5 mode (using the History APIs) or HashBang syntax.
    $locationProvider.html5Mode(true).hashPrefix('!');

    }]);
app.run(function ($rootScope, $route, $window, $location) {

    $rootScope.$on("$locationChangeStart", function (event, next, current) {        
        var nextPath = $location.path();
        if ($window.sessionStorage.token == undefined || $window.sessionStorage.token=="") {
            // no logged user, we should be going to #login
            if (nextPath != "/login") {
                //event.preventDefault();
                $location.path("/login");
            }
            $rootScope.isLogged = false;            
        } else {
            if (nextPath == "/login" || nextPath == undefined) {
                //event.preventDefault();
                $location.path("/dashboard");
            }
            $rootScope.isLogged = true;
            $rootScope.userLogged = $window.sessionStorage.userLogged;
        } 
    });

    $rootScope.$on("$routeChangeSuccess", function (currentRoute, previousRoute) {
        //Change page title, based on Route information
        $rootScope.title = $route.current.title;
    });

});

app.factory('authHttpResponseInterceptor', ['$rootScope', '$window', '$q', '$location',
    function ($rootScope, $window, $q, $location) {
        return {
            request: function(config) {
                $rootScope.isLoading = true;
                config.headers = config.headers || {};
                if ($window.sessionStorage.token && $window.sessionStorage.token != "") {
                    config.headers.Authorization = 'Bearer ' + $window.sessionStorage.token;
                }
                return config;
            },
            response: function (response) {
                $rootScope.isLoading = false;
                if (response.status === 401) {
                    var returnPath = $location.$$url;
                    $location.path('/login').search('returnTo', returnPath);
                }
                return response || $q.when(response);
            },
            responseError: function (rejection) {
                $rootScope.isLoading = false;
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