var app = angular.module('MyGenomicsApp', ['ngResource', 'appServices', 'ngRoute', 'ui.bootstrap', 'toastr', 'ngDragDrop', 'ngSanitize', 'froala']).
    factory('froalaConfig', function(configs) {
        return {
            inlineMode: false,
            imageUploadURL: configs.baseWebApiUrl + 'api/Images',
            imageParams: { postId: "123" },
            events: {
                align: function(e, editor, alignment) {
                    console.log(alignment + ' aligned');
                }
            }
        };
    });		

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
        .when('/pannelli/:param', {
            templateUrl: '/App/views/panelDetail.html',
            controller: 'panelsController',
            title: 'Pannelli'
        })
        .when('/pannelli', {
            templateUrl: '/App/views/panelsList.html',
            controller: 'panelsController',
            title: 'Pannelli'
        })
        .when('/capitoli', {
            templateUrl: '/App/views/chaptersList.html',
            controller: 'chaptersController',
            title: 'Capitoli'
        })
        .when('/capitoli/:param', {
            templateUrl: '/App/views/chapterDetail.html',
            controller: 'chaptersController',
            title: 'Capitoli'
        })
        .when('/genotests/:param', {
            templateUrl: '/App/views/reportDetail.html',
            controller: 'reportsController',
            title: 'Genotests'
        })
        .when('/genotests', {
            templateUrl: '/App/views/reportsList.html',
            controller: 'reportsController',
            title: 'Genotests'
        })
        .when('/livelli/:param', {
            templateUrl: '/App/views/levelDetail.html',
            controller: 'levelsController',
            title: 'Livelli'
        })
        .when('/livelli', {
            templateUrl: '/App/views/levelsList.html',
            controller: 'levelsController',
            title: 'Livelli'
        })
        .otherwise({
            redirectTo: '/login'
        })
        ;

        // Specify HTML5 mode (using the History APIs) or HashBang syntax.
    $locationProvider.html5Mode(true).hashPrefix('!');

    }]);
app.run(function ($rootScope, $route, $window, $location, configs) {

    $rootScope.languages = configs.languages;
    $rootScope.selectedLanguageId = 1;       

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
                    if (config.url.indexOf("/api/") > -1) {
                        config.url = config.url + '?languageId=' + $rootScope.selectedLanguageId;
                    }                        
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