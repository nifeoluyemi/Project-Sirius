
var app = angular.module('tasksPage', []);


app.controller('taskCtrl', [
    '$scope',
    function ($scope, $http, TaskService) {
        $scope.test = 'Hello world!';

    }
]);

app.factory('TaskService', function ($http) {
    var fac = {};
    fac.GetAllTasks = function () {
        return $http.get('api/UserTaskApi/GetAllUserTasks');
    }
    return fac;
});