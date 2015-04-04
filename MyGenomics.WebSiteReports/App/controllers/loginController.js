angular.module('MyGenomicsApp')
.controller('loginController', ['$scope','$rootScope', 'Authorization', '$window','$location','AuthService',
    function ($scope, $rootScope, Authorization, $window, $location, AuthService) {
        $scope.LoginErrorMessage = "";

        $scope.login = function() {
            AuthService.login($scope.UserName, $scope.Password)
            .then(function (data) {
                $window.sessionStorage.token = data.access_token;
                $window.sessionStorage.userLogged = $scope.UserName;                
                var returnUrl = $location.search().returnTo;
                if (returnUrl == undefined) {
                    returnUrl = "/dashboard";
                }
                $scope.LoginErrorMessage = "";
                AuthService.isLoggedIn = true;
                $location.path(returnUrl);
            }, function (reason) {
                $scope.LoginErrorMessage = reason.data.error_description;
                AuthService.isLogged = false;
            });
        };

    }]);