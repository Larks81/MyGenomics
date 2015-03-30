var appServices = angular.module('appServices', ['ngResource']);

appServices.factory('Contact', [
    '$resource', 'configs',
    function ($resource, configs) {
        return $resource(configs.baseWebApiUrl + 'api/contacts', {}, {
            login: { method: 'GET', 
                transformResponse: function (data) { 
                    data = angular.fromJson(data); 
                    data.BirthDate = new Date(data.BirthDate); 
                    return data; },
                isArray: false }
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
