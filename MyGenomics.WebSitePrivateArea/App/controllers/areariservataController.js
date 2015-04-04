angular.module('MyGenomicsApp')
.controller('areariservataController', ['$scope', 'KitResult',
    function ($scope, KitResult) {

        $scope.ResultKits;

        $scope.getResultKits = function (userId) {
            userId = 1;
            KitResult.get({ id: userId }, function (data) {                
                $scope.ResultKits = data;
            });
        };


    }]);