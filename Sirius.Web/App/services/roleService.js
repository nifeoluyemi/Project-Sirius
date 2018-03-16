(function () {
    'use strict';

    var app = angular.module('shared.core', []);
    app.factory('roleService', roleService);

    roleService.$inject = ['$http', '$location'];
    function roleService($http, $location) {

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
