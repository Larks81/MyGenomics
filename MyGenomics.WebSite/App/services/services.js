var appServices = angular.module('appServices', ['ngResource']);

appServices.factory('Contact', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/contact', {}, {
            login: { method: 'GET', isArray: false }
        });
    }
]);

appServices.factory('Questionnaire', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/questionnaire/:id', {}, {
            query: { method: 'GET', isArray: true }            
        });
    }
]);

appServices.factory('ContactQuestionnaire', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/ContactQuestionnaires/:id', {}, {
            get: { method: 'GET', params: { id: '@id' }, isArray: false }
        });
    }
]);
