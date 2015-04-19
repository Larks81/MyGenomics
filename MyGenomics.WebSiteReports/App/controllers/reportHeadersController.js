angular.module('MyGenomicsApp')
.controller('reportHeadersController', ['$scope', '$rootScope', '$routeParams', '$location', 'toastr', 'ReportHeader',
    function ($scope, $rootScope, $routeParams, $location, toastr, ReportHeader) {

        $scope.selectedId = $routeParams.param;        
        $scope.searchResult = null;
        $scope.detail = null;        

        $scope.search = function (page) {

            if ($scope.filter == undefined) {
                $scope.filter = "";
            }

            ReportHeader.get({ filter: $scope.filter, page: page }).$promise
            .then(function (data) {                
                $scope.searchResult = data;                
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.getDetail = function (id) {
            
            ReportHeader.get({ id: id }).$promise
            .then(function (data) {
                $scope.detail = data;
                toastr.info('Intestazione caricata correttamnete', 'Info');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.saveDetail = function() {
            ReportHeader.save($scope.detail).$promise
            .then(function (data) {
                $scope.selectedId = data.Id;
                $scope.getDetail($scope.selectedId);
                toastr.success("Intestazione salvata correttamente", 'Ok');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.removeDetail = function () {

            ReportHeader.delete({ id: $scope.selectedId }).$promise
            .then(function (data) {
                $location.path("/intestazioni");
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };
        
        //Startup        
        if ($routeParams.param > 0) {
            $scope.getDetail($scope.selectedId);
        } else if ($routeParams.param == 0) {
            $scope.detail = new ReportHeader();
            $scope.detail.LanguageId = $rootScope.selectedLanguageId;
        }

        $scope.getNumber = function(num) {
            return new Array(num);
        };        

    }]);