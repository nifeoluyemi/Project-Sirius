(function () {

    angular.module('sirius').controller('sidebarCtrl', [
        '$scope', '$http', '$rootScope', 'roleService',
        function ($scope, $http, $rootScope, roleService) {

            $scope.role = roleService.userRoles();

            //userfullname
            //organization name
            //active link
        }
    ]);
})();