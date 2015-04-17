angular.module('MyGenomicsApp')
.controller('reportHeadersController', ['$scope', '$rootScope', '$routeParams', '$location', 'toastr', 'Level',
    function ($scope, $rootScope, $routeParams, $location, toastr, Level) {

        $scope.selectedId = $routeParams.param;        
        $scope.searchResult = null;
        $scope.detail = null;        

        $scope.search = function (page) {

            if ($scope.filter == undefined) {
                $scope.filter = "";
            }

            Level.get({ filter: $scope.filter, page: page }).$promise
            .then(function (data) {                
                $scope.searchResult = data;                
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.getDetail = function (id) {
            
            Level.get({ id: id }).$promise
            .then(function (data) {
                $scope.detail = data;
                toastr.info('Livello caricato correttamnete', 'Info');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.saveDetail = function() {
            Level.save($scope.detail).$promise
            .then(function (data) {
                $scope.selectedId = data.Id;
                $scope.getDetail($scope.selectedId);
                toastr.success("Livello salvato correttamnete", 'Ok');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.removeDetail = function () {

            Level.delete({ id: $scope.selectedId }).$promise
            .then(function (data) {
                $location.path("/livelli");
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };
        
        //Startup        
        if ($routeParams.param > 0) {
            $scope.getDetail($scope.selectedId);
        } else if ($routeParams.param == 0) {
            $scope.detail = new Level();            
            $scope.detail.LanguageId = $rootScope.selectedLanguageId;
        }

        $scope.getNumber = function(num) {
            return new Array(num);
        };        

    }]);