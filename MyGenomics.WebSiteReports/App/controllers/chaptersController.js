angular.module('MyGenomicsApp')
.controller('chaptersController', ['$scope', '$rootScope', '$routeParams', 'Panel', '$location', 'toastr', 'Chapter',
    function ($scope, $rootScope, $routeParams, Panel, $location, toastr, Chapter) {

        $scope.selectedId = $routeParams.param;
        $scope.searchResult = null;
        $scope.detail = null;
        $scope.panels = null;
        $scope.allPanels = null;
        

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
                $scope.loadAllPanelAndRemoveAlreadyPresents(data.Panels);
                toastr.info('Capitolo caricato correttamnete', 'Info');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.saveDetail = function () {
            $scope.changePanelsPosition();
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

        //Load Panels
        $scope.loadAllPanelAndRemoveAlreadyPresents = function(panelsPresent) {
            Panel.get({ filter: "" }).$promise
                .then(function(data) {
                    $scope.allPanels = new Array();

                    for (var k = 0; k < data.Results.length; k++) {
                        var id = data.Results[k].Id;
                        var existId = false;
                        for (var j = 0; j < panelsPresent.length; j++) {
                            if (panelsPresent[j].Id == id) {
                                existId = true;
                                break;
                            }
                        }

                        if (!existId) {
                            $scope.allPanels.push(data.Results[k]);
                        }
                    }

                }, function(reason) {
                    toastr.error('Errore durante il caricamento dei livelli', reason);
                });
        };
        
        $scope.changePanelsPosition = function() {
            for (var j = 0; j < $scope.detail.Panels.length; j++) {
                $scope.detail.Panels[j].OrderPosition = j+1;
            }
        };



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