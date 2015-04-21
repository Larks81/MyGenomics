﻿var appServices = angular.module('appServices', ['ngResource']);

appServices.factory('Authorization', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'token', {}, {
            authenticate: {
                method: 'POST',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                isArray: false
            }
        });
    }
]);

appServices.factory('Panel', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/Panels', {}, {
            get: { method: 'GET', isArray: false },
            save: { method: 'POST', isArray: false},
        });
    }
]);

appServices.factory('Chapter', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/Chapters', {}, {
            get: { method: 'GET', isArray: false },
            save: { method: 'POST', isArray: false },
        });
    }
]);

appServices.factory('Report', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/Reports', {}, {
            get: { method: 'GET', isArray: false },
            save: { method: 'POST', isArray: false },
        });
    }
]);

appServices.factory('ReportHeader', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/ReportHeaders', {}, {
            get: { method: 'GET', isArray: false },
            save: { method: 'POST', isArray: false },
        });
    }
]);

appServices.factory('Product', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/Products', {}, {
            get: { method: 'GET', isArray: false },            
        });
    }
]);

appServices.factory('Level', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/Levels', {}, {
            get: { method: 'GET', isArray: false },
            save: { method: 'POST', isArray: false},
        });
    }
]);

appServices.factory('KitResult', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/KitResults/:id', {}, {
            get: { method: 'GET', params: { id: '@id' }, isArray: true },
        });
    }
]);

appServices.factory('Csv', [
    '$resource', 'configs', '$http',
    function ($resource, configs, $http) {
        var importSnps = function(file,panelId) {
            var fd = new FormData();
            fd.append('file', file);
            return $http.post(configs.baseWebApiUrl + 'api/Csv?panelId=' + panelId, fd, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            });
        };
        return{
            importSnps: importSnps
        };
    }    
]);
