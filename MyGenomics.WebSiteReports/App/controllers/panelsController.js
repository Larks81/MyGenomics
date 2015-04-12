angular.module('MyGenomicsApp')
.controller('panelsController', ['$scope', '$rootScope', '$routeParams','Panel',
    function ($scope, $rootScope, $routeParams, Panel) {

        $scope.selectedId = $routeParams.param;        
        $scope.searchResult = null;
        $scope.detail = null;        

        $scope.search = function (page) {

            if ($scope.filter == undefined) {
                $scope.filter = "";
            }

            Panel.get({ filter: $scope.filter, page: page }).$promise
            .then(function (data) {
                $scope.searchResult = data;
            }, function (reason) {
                alert("error");
            });
        };

        $scope.getDetail = function (id) {
            
            Panel.get({ id: id }).$promise
            .then(function (data) {
                $scope.detail = data;
            }, function (reason) {
                alert("error");
            });
        };

        $scope.saveDetail = function() {
            Panel.save($scope.detail).$promise
            .then(function (data) {
                $scope.getDetail($scope.selectedId);
            }, function (reason) {
                alert("error");
            });
        };

        $scope.removeDetail = function () {
            Panel.delete({id: $scope.selectedId}).$promise
            .then(function (data) {
                $location.path("/pannelli");
            }, function (reason) {
                alert("error");
            });
        };

        if ($routeParams.param > 0) {
            $scope.getDetail($scope.selectedId);
        } else if ($routeParams.param == 0) {
            $scope.detail = new Panel();
            $scope.detail.LanguageId = $rootScope.selectedLanguageId;
        }



        $scope.getNumber = function(num) {
            return new Array(num);
        };

    }]);