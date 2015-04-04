angular.module('MyGenomicsApp')
    .factory('AuthService',['Authorization', '$window', '$location',
    function(Authorization, $window, $location) {
        var currentUser;
        var isLogged = false;

        var changeRoute = function (url, forceReload) {
            $location.path(url);           
        };

        return {
            login: function(username,password) { 
                var data = "grant_type=password&username=" + username + "demo&password=" + password;
                data = data + "&client_id=127.0.0.1";

                Authorization.authenticate(data).$promise
                .then(function (data) {
                    $window.sessionStorage.token = data.access_token;
                    currentUser = username;
                    var returnUrl = $location.search().returnTo;
                    if (returnUrl == undefined) {
                        returnUrl = "/dashboard";
                    }

                    isLogged = true;
                    $location.path(returnUrl);
                });
            },
            logout: function() { 
                $window.sessionStorage.token = "";
                currentUser = null;
                isLogged = false;
                changeRoute('/login', false);
            },
            isLoggedIn: function() { 
                return isLogged;
            },
            currentUser: function () {
                return currentUser;
            }
        
        };
}]);