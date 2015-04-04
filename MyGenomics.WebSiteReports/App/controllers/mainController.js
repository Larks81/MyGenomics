angular.module('MyGenomicsApp')
    .controller('mainController', function ($scope, $window, AuthService) {
        //$scope.isLoggedIn = false;

        //$scope.$watch($window.sessionStorage.token, function (isLoggedIn) {
        //    alert($window.sessionStorage.token);
        //    if ($window.sessionStorage.token != undefined) {
        //        $scope.isLoggedIn = true;
        //    } else {
        //        $scope.isLoggedIn = false;
        //    }
            
        //    //$scope.currentUser = AuthService.currentUser();
        //});        

        $scope.logout = function () {            
            AuthService.logout();
        };
});