(function () {
    'use strict';
    var app = angular.module('app', []);

    app.controller('taskDetailCtrl', ['$scope', '$http',
        function ($scope, $http) {
            var userTaskId = angular.element('#userTaskId').val();
            $scope.currentUserId = null;
            $scope.Task = {};
            $scope.TaskExpectations = [];
            $scope.Comments = [];
            $scope.commentCount = 0;
            $scope.Ratings = [];
            $scope.ratingCount = 0;

            $http.get("/api/staffapi/index").success(function (data) {
                $scope.currentUserId = data;
            });

            $http.get("/api/usertaskapi/getusertaskinfo?userTaskId=" + userTaskId).success(function (data) {
                $scope.Task = data;
            }).then(function () { initSlider(); });

            $http.get("/api/usertaskapi/gettaskexpectation?userTaskId=" + userTaskId).success(function (data) {
                $scope.TaskExpectations = data;
            });

            $http.get("/api/usertaskapi/usertaskcomment?userTaskId=" + userTaskId).success(function (data) {
                $scope.Comments = data;
                $scope.commentCount = data.length;
            });

            $http.get("/api/usertaskapi/usertaskevaluation?userTaskId=" + userTaskId).success(function (data) {
                $scope.Ratings = data;
                $scope.ratingCount = data.length;
            });

            $scope.editTask = function () {

            }

            $scope.Comment = {
                UserTaskId: null,
                UserId: '',
                CommentBody: ''
            }

            $scope.addComment = function () {
                $scope.Comment.UserTaskId = $scope.Task.UserTaskId;
                $scope.Comment.UserId = $scope.Task.AssignedToId;

                var postCommentUrl = '/api/usertaskapi/addcomment';
                $http({
                    method: 'POST',
                    url: postCommentUrl,
                    data: $scope.Comment
                }).then(function successCallback(response) {
                    $scope.Comments.push(response.data);
                    $scope.Comment.CommentBody = '';
                    toastr.success("Your comment has been added to this task.");
                    $scope.commentCount += 1;
                }, function errorCallback(response) {
                    toastr.error("Error: " + response.data.Message);
                });
            }

            $scope.deleteComment = function (comment) {
                var deleteCommentUrl = '/api/usertaskapi/deletecomment?commentId=';

                swal({
                    title: "Delete comment",
                    text: "Are you sure you want to delete your comment?",
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
                            url: deleteCommentUrl + comment.UserTaskCommentId,
                        }).then(function successCallback(response) {
                            var index = $scope.Comments.indexOf(comment);
                            $scope.Comments.splice(index, 1);
                            $scope.commentCount -= 1;
                            swal("Deleted", "Your comment has been deleted", "success");
                        }, function errorCallback(response) {
                            swal("Error", "Error deleting this comment, please try again", "error")
                        });
                    }
                });
            }
            

            $scope.Rating = {
                UserTaskId: null,
                UserId: '',
                Score: 0,
                MaxScore: 0
            }

            $scope.addRating = function () {
                if ($scope.Rating.Score == 0 || $scope.Rating.Score == '0') {
                    toastr.error("Your rating has to be greater than zero (0)");
                }
                else {
                    $scope.Rating.UserTaskId = $scope.Task.UserTaskId;
                    $scope.Rating.UserId = $scope.Task.AssignedToId;
                    $scope.Rating.MaxScore = $scope.Task.MaxScore;

                    var postRatingUrl = '/api/usertaskapi/addevaluation';
                    $http({
                        method: 'POST',
                        url: postRatingUrl,
                        data: $scope.Rating
                    }).then(function successCallback(response) {
                        $scope.Ratings.push(response.data);
                        $scope.Rating.Score = 0;
                        toastr.success("Your rating has been added to this task.");
                        $scope.ratingCount += 1;
                        $('#evaluateTask').modal('hide');
                        var slider = $rangeSlider.data("ionRangeSlider");
                        slider.reset();
                    }, function errorCallback(response) {
                        toastr.error("Error: " + response.data.Message);
                    });
                }
            }

            $scope.deleteRating = function (rating) {
                var deleteRatingUrl = '/api/usertaskapi/deleteEvaluation?evaluationId=';

                swal({
                    title: "Delete rating",
                    text: "Are you sure you want to delete this rating?",
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
                            url: deleteRatingUrl + rating.UserTaskEvaluationId,
                        }).then(function successCallback(response) {
                            var index = $scope.Ratings.indexOf(rating);
                            $scope.Ratings.splice(index, 1);
                            $scope.ratingCount -= 1;
                            swal("Deleted", "Your rating has been deleted", "success");
                        }, function errorCallback(response) {
                            swal("Error", "Error deleting this rating, please try again", "error")
                        });
                    }
                });
            }

            function initSlider() {
                var $range = $("input#rating_range"),
                        $inputFrom = $("input#rangeValue");

                $range.ionRangeSlider({
                    min: 0,
                    max: $scope.Task.MaxScore,
                    from: 0,
                    type: 'single',
                    step: 0.1,
                    postfix: "",
                    prettify: true,
                    hasGrid: true,
                    onStart: updateInputs,
                    onChange: updateInputs,
                    onFinish: updateInputs
                });

                function updateInputs(data) {
                    $inputFrom.prop("value", data.from);
                }
            }
        }

    ]);
})();