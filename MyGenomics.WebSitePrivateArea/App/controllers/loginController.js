angular.module('MyGenomicsApp')
.controller('loginController', ['$scope','$rootScope', 'Authorization', '$window','$location','AuthService',
    function ($scope, $rootScope, Authorization, $window, $location, AuthService) {

        $scope.login = function () {
            AuthService.login($scope.UserName,$scope.Password);            
        }                

    }]);