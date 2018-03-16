(function () {
    'use strict';

    var app = angular.module('sirius', [
        'shared.core',
        'shared.ui'
    ]);

    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('dashboard', {
                    url: '/',
                    templateUrl: '/App/views/dashboard.cshtml',
                    controller: 'dashboardCtrl'
                });
        }
    ]);
})();