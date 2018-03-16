(function () {
    'use strict';

    var app = angular.module("dashboard", []);


    app.controller("dashboardCtrl", function ($scope, $http, $window) {

        $http.get("api/staffapi/index").success(function (data) {
            $scope.userId = data;
        }).then(function () {
            getUserInfo($scope.userId);
            getAppraisalInfo($scope.userId);
        });

        $http.get("api/notificationapi/getnotifications").success(function (data) {
            $scope.notifications = data;
        });


        function getAppraisalInfo(userId) {

            $http.get("api/staffapi/getappraisalcycle").success(function (data) {
                $scope.appraisalInfo = data;
            }).then(function () {
                getUserTaskCount(userId, $scope.appraisalInfo.Id)
                getAppraisalPeriods($scope.appraisalInfo.Id)
            });
        };

        function getUserInfo(userId) {
            $http.get("api/userapi/getuserinfo?userId=" + userId).success(function (data) {
                $scope.userInfo = data;
            }).then(function () {
                $http.get("api/departmentapi/getdepartmentinfo?departmentId=" + $scope.userInfo.DepartmentId).success(function (data) {
                    $scope.departmentInfo = data;
                });
            });
        };
        function getUserTaskCount(userId, appraisalCycleId) {
            $http.get("api/usertaskapi/getusertaskscount?userId=" + userId + "&appraisalCycleId=" + appraisalCycleId)
                .success(function (data) {
                    $scope.tasksCount = data;
                });
        };

        function getAppraisalPeriods(appraisalCycleId) {
            $http.get("api/appraisalapi/getappraisalperiods?cycleId=" + appraisalCycleId)
                .success(function (data) {
                    $scope.periods = data;
                    $scope.periodCount = data.length;
                });
        }

        $scope.isValidAppraisalPeriod = function () {
            return $scope.appraisalInfo != null ? true : false;
        }

        $scope.hasSupervisor = function () {
            return $scope.userInfo.SupervisorId != null ? true : false;
        }

        //For the Notifications...


        $scope.readNotification = function (notification) {
            $http.put("api/notificationapi/markasread?notificationid=" + notification.NotificationId).success(function (data) {
                if(data == '#' || data == ''){
                    notification.IsRead = true;
                }
                else {
                    $window.location.href = '/' + data;
                }
            });
        };

        $scope.markAllAsRead = function () {
            $http.post("api/notificationapi/markallasread").success(function (data) {
                for (var i = 0; i < $scope.notifications.length; i++) {
                    if (!$scope.notifications[i].IsRead) {
                        $scope.notifications[i].IsRead = true;
                    }
                }
            });
        };

        $scope.seeNotifications = function () {

        }

        function loadNotifications() {

        }

    });

})();