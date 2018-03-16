(function () {

    'use strict';

var TaskPage = angular.module('Task', []);

TaskPage.controller('TaskCtrl', function ($scope, $http) {

    $scope.TaskTitle = '';
    $scope.TaskDesc = '';

    var userID = angular.element('#userID').val();
    $http.get("/api/usertaskapi/index?userid=" + userID).success(function (data) {
        $scope.User = data;
    }).then(function () {
        getUserInfo(userID);
        getAppraisalInfo(userID);
    });


    function getAppraisalInfo(userId) {

        $http.get("/api/staffapi/getappraisalcycle").success(function (data) {
            $scope.appraisalInfo = data;
        }).then(function () {
            getUserTasks(userId, $scope.appraisalInfo.Id);
        });
    };
    function getUserInfo(userId) {
        $http.get("/api/userapi/getuserinfo?userId=" + userId).success(function (data) {
            $scope.userInfo = data;
        })
    };
    function getUserTasks(userId, appraisalId) {
        $http.get("/api/usertaskapi/getusertasks?userId=" + userId + "&appraisalCycleId=" + appraisalId)
            .success(function (data) {
                $scope.tasks = data;
                $scope.tasksCount = data.length;
            });
    };

    $scope.isValidAppraisalPeriod = function () {
        return $scope.appraisalInfo != null ? true : false;
    }


    $scope.newTask = {
        Title: '',
        Description: '',
        MaxScore: 0,
        Expectation: ''
    };

    $scope.addTask = function (TaskTitle, TaskDesc) {
        $scope.newTask.Title = TaskTitle;
        $scope.newTask.Description = TaskDesc;
        $scope.newTask.MaxScore = $scope.User.MaxScore;

        var addTaskUrl = "/api/usertaskapi/addtask/";

        $http({
            method: 'POST',
            url: addTaskUrl,
            data: $scope.newTask
        }).then(function successCallback(response) {
            $scope.tasks.push(response.data);
            $scope.TaskTitle = '';
            $scope.TaskDesc = '';
            $scope.tasksCount += 1;
            $('#addTask').modal('hide');
            toastr.success("Task Successfully Added!");
        }, function errorCallback(response) {
            toastr.error("Error: " + response.data.Message);
        });
    };

    $scope.deleteTask = function (taskId) {
        var deleteTaskUrl = '/api/usertaskapi/deletetask?usertaskid=' + taskId;

        swal({
            title: "Delete Task",
            text: "Are you sure you want to delete this Task?",
            animation: false,
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Delete",
            cancelButtonText: "Cancel",
            closeOnConfirm: false,
            closeOnCancel: true,
            showLoaderOnConfirm: true
        },
        function (isConfirm) {
            if (isConfirm) {
                $http({
                    method: 'POST',
                    url: deleteTaskUrl
                }).then(function successCallback(response) {
                    var index = $scope.tasks.indexOf(taskId);
                    $scope.tasks.splice(index, 1);
                    $scope.tasksCount -= 1;
                    swal("Deleted", "This task has been deleted", "success");
                }, function errorCallback(response) {
                    swal("Error", "Error deleting this task, please try again", "error")
                });
            }
        });
    }

});

})();