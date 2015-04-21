angular.module('MyGenomicsApp')
.controller('panelsController', ['$scope', '$rootScope', '$routeParams', 'Panel', '$location', 'toastr', 'Level', 'Csv',
    function ($scope, $rootScope, $routeParams, Panel, $location, toastr, Level, Csv) {

        $scope.selectedId = $routeParams.param;        
        $scope.searchResult = null;
        $scope.detail = null;
        $scope.levels = null;

        $scope.search = function (page) {

            if ($scope.filter == undefined) {
                $scope.filter = "";
            }

            Panel.get({ filter: $scope.filter, page: page }).$promise
            .then(function (data) {                
                $scope.searchResult = data;                
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.getDetail = function (id) {
            
            Panel.get({ id: id }).$promise
            .then(function (data) {
                $scope.detail = data;
                toastr.info('Pannello caricato correttamnete', 'Info');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.saveDetail = function() {
            Panel.save($scope.detail).$promise
            .then(function (data) {
                $scope.selectedId = data.Id;
                $scope.getDetail($scope.selectedId);
                toastr.success("Pannello salvato correttamnete", 'Ok');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.removeDetail = function () {
            Panel.delete({id: $scope.selectedId}).$promise
            .then(function (data) {
                $location.path("/pannelli");
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.addNewPanelContent = function () {
            var newContent = new Object();
            newContent.PanelId = $scope.selectedId;
            newContent.LanguageId = $rootScope.selectedLanguageId;
            newContent.OrderPosition = $scope.detail.PanelContents.length + 1;
            $scope.detail.PanelContents.push(newContent);
        };

        $scope.removePanelContent = function (contents, index) {
            if(confirm("Vuoi realmente eliminare questo contenuto?"))
            contents.splice(index, 1);
        };

        $scope.importSnps = function () {            
            Csv.importSnps($scope.snpFileToImport, $scope.selectedId)
            .then(function (data) {                
                toastr.success("Import Snps effettuato correttamente", 'Ok');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        //Startup

        //Load Levels
        if ($routeParams.param != undefined) {
            Level.get({ filter: "" }).$promise
                .then(function(data) {
                    $scope.levels = data.Results;
                    $scope.levels.unshift(new Object({Id : null,Name : 'Nessuno (contenuto sempre presente)'}));
                }, function(reason) {
                    toastr.error('Errore durante il caricamento dei livelli', reason);
                });
        }

        if ($routeParams.param > 0) {
            $scope.getDetail($scope.selectedId);
        } else if ($routeParams.param == 0) {
            $scope.detail = new Panel();
            $scope.detail.PanelContents = new Array();
            $scope.detail.LanguageId = $rootScope.selectedLanguageId;
        }

        $scope.getNumber = function(num) {
            return new Array(num);
        };

        $scope.changeOrderUp = function(content) {
            var oldPos = content.OrderPosition;            
            var newPos = content.OrderPosition - 1;
            for (var k = 0; k < $scope.detail.PanelContents.length; k++) {
                if ($scope.detail.PanelContents[k].OrderPosition == newPos) {
                    $scope.detail.PanelContents[k].OrderPosition = oldPos;
                }
            }                
            content.OrderPosition=newPos;
        };

        $scope.changeOrderDown = function (content) {
            var oldPos = content.OrderPosition;
            var newPos = content.OrderPosition + 1;
            for (var k = 0; k < $scope.detail.PanelContents.length; k++) {
                if ($scope.detail.PanelContents[k].OrderPosition == newPos) {
                    $scope.detail.PanelContents[k].OrderPosition = oldPos;
                }
            }
            content.OrderPosition = newPos;
        };

    }]);