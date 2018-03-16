(function () {
    'use strict';

    var app = angular.module('shared.core', []);
    app.factory('apiService', apiService);

    apiService.$inject = ['$http', '$location', 'notificationService', '$rootScope'];

    function apiService() {

    }

})();