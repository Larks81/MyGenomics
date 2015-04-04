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
        .otherwise({
            redirectTo: '/login'
        });

        // Specify HTML5 mode (using the History APIs) or HashBang syntax.
    $locationProvider.html5Mode(true).hashPrefix('!');

    }]);
app.run(function ($rootScope, $route, $window, $location) {

    $rootScope.$on("$locationChangeStart", function (event, next, current) {
        if ($window.sessionStorage.token == undefined) {
            // no logged user, we should be going to #login
            if (next.templateUrl != "html/Login.html") {
                //event.preventDefault();
                $location.path("/login");
            }
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