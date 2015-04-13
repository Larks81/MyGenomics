angular.module('MyGenomicsApp')
.controller('chaptersController', ['$scope', '$rootScope', '$routeParams', 'Panel', '$location', 'toastr', 'Chapter',
    function ($scope, $rootScope, $routeParams, Panel, $location, toastr, Chapter) {

        $scope.selectedId = $routeParams.param;
        $scope.searchResult = null;
        $scope.detail = null;
        $scope.panels = null;

        $scope.lista1 = { title: 'AngularJS - 3 Me' };
        $scope.lista2 = { title: 'AngularJS - 3 Me' };
        $scope.lista3 = { title: 'AngularJS - 3 Me' };
        $scope.list2 = {};

        $scope.search = function (page) {

            if ($scope.filter == undefined) {
                $scope.filter = "";
            }

            Chapter.get({ filter: $scope.filter, page: page }).$promise
            .then(function (data) {
                $scope.searchResult = data;
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.getDetail = function (id) {

            Chapter.get({ id: id }).$promise
            .then(function (data) {
                $scope.detail = data;
                toastr.info('Capitolo caricato correttamnete', 'Info');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.saveDetail = function () {
            Chapter.save($scope.detail).$promise
            .then(function (data) {
                $scope.selectedId = data.Id;
                $scope.getDetail($scope.selectedId);
                toastr.success("Capitolo salvato correttamente", 'Ok');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.removeDetail = function () {
            Chapter.delete({ id: $scope.selectedId }).$promise
            .then(function (data) {
                $location.path("/capitoli");
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };        

        $scope.getNumber = function (num) {
            return new Array(num);
        };

        //Startup

        //Load Panels todo
        //if ($routeParams.param != undefined) {
        //    Level.get({ filter: "" }).$promise
        //        .then(function (data) {
        //            $scope.levels = data;
        //            $scope.levels.unshift(new Object({ Id: null, Name: 'Nessuno (contenuto sempre presente)' }));
        //        }, function (reason) {
        //            toastr.error('Errore durante il caricamento dei livelli', reason);
        //        });
        //}        

        if ($routeParams.param > 0) {
            $scope.getDetail($scope.selectedId);
        } else if ($routeParams.param == 0) {
            $scope.detail = new Chapter();
            $scope.detail.Panels = new Array();
            $scope.detail.LanguageId = $rootScope.selectedLanguageId;
        }        

        $scope.changeOrderUp = function (panel) {
            var oldPos = panel.OrderPosition;
            var newPos = panel.OrderPosition - 1;
            for (var k = 0; k < $scope.detail.Panels.length; k++) {
                if ($scope.detail.Panels[k].OrderPosition == newPos) {
                    $scope.detail.Panels[k].OrderPosition = oldPos;
                }
            }
            panel.OrderPosition = newPos;
        };

        $scope.changeOrderDown = function (panel) {
            var oldPos = panel.OrderPosition;
            var newPos = panel.OrderPosition + 1;
            for (var k = 0; k < $scope.detail.Panels.length; k++) {
                if ($scope.detail.Panels[k].OrderPosition == newPos) {
                    $scope.detail.Panels[k].OrderPosition = oldPos;
                }
            }
            panel.OrderPosition = newPos;
        };

    }]);