angular.module('MyGenomicsApp')
    .controller('mainController', function ($scope, AuthService) {
        $scope.$watch(AuthService.isLoggedIn, function (isLoggedIn) {            
            $scope.isLoggedIn = isLoggedIn;
            $scope.currentUser = AuthService.currentUser();
        });        

        $scope.logout = function () {            
            AuthService.logout();
        };
});