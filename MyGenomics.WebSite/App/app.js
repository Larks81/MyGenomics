var app = angular.module('MyGenomicsApp', ['ngResource', 'appServices', 'ngRoute', 'mgo-angular-wizard', 'ui.bootstrap']);

app.config([
    '$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        $routeProvider.when('/questionario', {
            templateUrl: '/App/views/questionario.html',
            controller: 'questionarioController'
        });        
        $routeProvider.otherwise({
            redirectTo: '/questionario'
        });

        // Specify HTML5 mode (using the History APIs) or HashBang syntax.
    $locationProvider.html5Mode(true).hashPrefix('!');

}]);
