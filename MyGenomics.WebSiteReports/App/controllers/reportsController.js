angular.module('MyGenomicsApp')
.controller('reportsController', ['$scope', '$rootScope', '$routeParams', 'Report', '$location', 'toastr', 'Chapter', 'Product', 'ReportHeader',
    function ($scope, $rootScope, $routeParams, Report, $location, toastr, Chapter, Product, ReportHeader) {

        $scope.selectedId = $routeParams.param;
        $scope.searchResult = null;
        $scope.detail = null;
        $scope.chapters = null;
        $scope.allChapters = null;
        $scope.allProducts = null;
        $scope.allReportHeaders = null;

        $scope.search = function (page) {

            if ($scope.filter == undefined) {
                $scope.filter = "";
            }

            Report.get({ filter: $scope.filter, page: page }).$promise
            .then(function (data) {
                $scope.searchResult = data;
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.getDetail = function (id) {

            Report.get({ id: id }).$promise
            .then(function (data) {
                $scope.detail = data;
                $scope.loadAllChaptersAndRemoveAlreadyPresents(data.Chapters);
                toastr.info('Genotest caricato correttamente', 'Info');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.saveDetail = function () {
            $scope.changeChaptersPosition();
            Report.save($scope.detail).$promise
            .then(function (data) {
                $scope.selectedId = data.Id;
                $scope.getDetail($scope.selectedId);
                toastr.success("Genotest salvato correttamente", 'Ok');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.removeDetail = function () {
            Report.delete({ id: $scope.selectedId }).$promise
            .then(function (data) {
                $location.path("/genotests");
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.getProducts = function () {
            Product.get({ filter: "", page : 1 }).$promise
            .then(function (data) {
                $scope.allProducts = data.Results;
                toastr.info('Prodotti caricati correttamente', 'Info');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.getReportHeaders = function () {
            ReportHeader.get({ filter: "", page: 1 }).$promise
            .then(function (data) {
                $scope.allReportHeaders = data.Results;
                toastr.info('Intestazioni caricate correttamente', 'Info');
            }, function (reason) {
                toastr.error('Errore', reason);
            });
        };

        $scope.getNumber = function (num) {
            return new Array(num);
        };

        $scope.changeChaptersPosition = function () {
            for (var j = 0; j < $scope.detail.Chapters.length; j++) {
                $scope.detail.Chapters[j].OrderPosition = j + 1;
            }
        };

        //Startup

        //Load Chapters
        $scope.loadAllChaptersAndRemoveAlreadyPresents = function(chaptersPresent) {
            Chapter.get({ filter: "" }).$promise
                .then(function(data) {
                    $scope.allChapters = new Array();

                    for (var k = 0; k < data.Results.length; k++) {
                        var id = data.Results[k].Id;
                        var existId = false;
                        for (var j = 0; j < chaptersPresent.length; j++) {
                            if (chaptersPresent[j].Id == id) {
                                existId = true;
                                break;
                            }
                        }

                        if (!existId) {
                            $scope.allChapters.push(data.Results[k]);
                        }
                    }

                }, function(reason) {
                    toastr.error('Errore durante il caricamento dei Capitoli', reason);
                });
        };
        
        $scope.changeChaptersPosition = function() {
            for (var j = 0; j < $scope.detail.Chapters.length; j++) {
                $scope.detail.Chapters[j].OrderPosition = j + 1;
            }
        };



        if ($routeParams.param > 0) {
            $scope.getProducts();
            $scope.getReportHeaders();
            $scope.getDetail($scope.selectedId);
        } else if ($routeParams.param == 0) {
            $scope.getProducts();
            $scope.getReportHeaders();
            $scope.detail = new Report();
            $scope.detail.Chapters = new Array();
            $scope.detail.LanguageId = $rootScope.selectedLanguageId;
        }        

        //$scope.changeOrderUp = function (panel) {
        //    var oldPos = panel.OrderPosition;
        //    var newPos = panel.OrderPosition - 1;
        //    for (var k = 0; k < $scope.detail.Panels.length; k++) {
        //        if ($scope.detail.Panels[k].OrderPosition == newPos) {
        //            $scope.detail.Panels[k].OrderPosition = oldPos;
        //        }
        //    }
        //    panel.OrderPosition = newPos;
        //};

        //$scope.changeOrderDown = function (panel) {
        //    var oldPos = panel.OrderPosition;
        //    var newPos = panel.OrderPosition + 1;
        //    for (var k = 0; k < $scope.detail.Panels.length; k++) {
        //        if ($scope.detail.Panels[k].OrderPosition == newPos) {
        //            $scope.detail.Panels[k].OrderPosition = oldPos;
        //        }
        //    }
        //    panel.OrderPosition = newPos;
        //};

    }]);