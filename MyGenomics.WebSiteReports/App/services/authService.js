angular.module('MyGenomicsApp')
    .factory('AuthService', ['Authorization', '$window', '$location', '$rootScope',
    function(Authorization, $window, $location,$rootScope) {
        var currentUser;
        var isLoggedIn = false;

        var changeRoute = function (url, forceReload) {
            $location.path(url);           
        };

        return {
            login: function(username,password) { 
                var data = "grant_type=password&username=" + username + "&password=" + password;
                data = data + "&client_id=127.0.0.1";

                return Authorization.authenticate(data).$promise;

            },
            logout: function() { 
                $window.sessionStorage.token = "";
                $window.sessionStorage.userLogged = "";
                currentUser = null;
                $rootScope.isLogged = false;
                changeRoute('/login', false);
            },            
            currentUser: function () {
                return currentUser;
            },
            isLoggedIn: isLoggedIn
        
        };
}]);