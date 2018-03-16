(function () {
    'use strict';

    var app = angular.module('shared.core', []);
    app.factory('userService', userService);

    userService.$inject = ['$http', '$location'];
    function userService($http, $location) {

        var service = {
            userRoles: loadRoles
        }



        function loadRoles() {
            $http.get('/api/roleapi/getuserroles').success(function (data) {
                return data;
            });
        }
        return service;
    }

})();
