angular.module('MyGenomicsApp')
    .controller('mainController', function ($scope, $window, AuthService) {
        
    $scope.options = {
        placeholder: 'My Placeholder'
    };

    $scope.froalaAction = function (action) {
        $scope.options.froala(action);
    };

    $scope.onPaste = function(e, editor, html) {
        return 'Hijacked ' + html;
    };

    $scope.onEvent = function(e, editor, a, b) {
        console.log('onEvent', e.namespace, a, b);
    };

    $scope.logout = function () {            
        AuthService.logout();
    };
});