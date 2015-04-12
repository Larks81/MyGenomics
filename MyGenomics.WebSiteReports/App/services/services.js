var appServices = angular.module('appServices', ['ngResource']);

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


