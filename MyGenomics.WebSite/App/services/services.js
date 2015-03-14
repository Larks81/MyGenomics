var appServices = angular.module('appServices', ['ngResource']);

appServices.factory('Questionnaire', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/questionnaire/:id', {}, {
            query: { method: 'GET', isArray: true }            
        });
    }
]);

appServices.factory('PersonQuestionnaire', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/PersonQuestionnaires/:id', {}, {
            get: { method: 'GET', params: { id: '@id' }, isArray: false }
        });
    }
]);
