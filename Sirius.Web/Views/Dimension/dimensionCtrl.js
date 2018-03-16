(function () {
    'use strict';

    var app = angular.module('app', []);

    app.controller('mainCtrl', ['$scope', '$http', 'dimensionService',
        function ($scope, $http, dimensionService) {
            $scope.currentUser = {};
            $scope.user = {};
            $scope.competencies = [];
            $scope.current = {};
            $scope.current.comment = '';
            $scope.current.comments = [];
            $scope.current.commentCount = 0;
            $scope.current.rating = 0;
            $scope.current.ratings = [];
            $scope.current.ratingsCount = 0;
            $scope.current.showRatingBody = false;
            $scope.cycle = {};
            $scope.showButton = false;

            $http.get('/api/staffapi/getappraisalcycle').success(function (data) {
                $scope.cycle = data;
            });

            var currentUserId = angular.element('#currentUserId').val();
            $http.get('/api/userapi/getuserinfo?userId=' + currentUserId).success(function (data) {
                $scope.currentUser = data;
            });

            var userId = angular.element('#userId').val();
            $http.get('/api/userapi/getuserinfo?userId=' + userId).success(function (data) {
                $scope.user = data;
            }).then(function () { getDimensions(); });

            function getDimensions() {
                var orgId = angular.element('#orgId').val();
                $http.get('/api/organizationapi/dimensions?organizationId=' + orgId).success(function (data) {
                    $scope.competencies = data;
                    $scope.current = $scope.competencies[0];
                }).then(function () { getDepartmentDimensions($scope.user.DepartmentId); getComments($scope.current); });
            }

            function getDepartmentDimensions(deptId) {
                $http.get('/api/departmentapi/dimensions?departmentId=' + deptId).success(function (data) {
                    for (var i = 0; i < data.length; i++) {
                        $scope.competencies.push(data[i]);
                    }
                });
            }

            //getCompetencies();

            //function getCompetencies() {
            //    $scope.competencies = dimensionService.competencyList();
            //}

            $scope.toggleRatingBody = function (current) {
                current.showRatingBody = !current.showRatingBody;

                for (var i = 0; i < $scope.competencies.length; i++) {
                    var $range = $("input#rating_range" + $scope.competencies[i].HtmlId),
                        $inputFrom = $("input#rangeValue" + $scope.competencies[i].HtmlId);

                    $range.ionRangeSlider({
                        min: 0,
                        max: $scope.competencies[i].MaxScore,
                        from: $inputFrom.prop("value"),
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
                    

            $scope.nextCompetency = function(){
                var i = $scope.competencies.indexOf($scope.current) + 1;
                var j = i >= $scope.competencies.length ? 0 : i;
                $scope.current = $scope.competencies[j];
                getComments($scope.current);
                //$scope.current.showRatingBody = false;
            },
            $scope.previousCompetency = function () {
                var i = $scope.competencies.indexOf($scope.current) - 1;
                var j = i < 0 ? $scope.competencies.length - 1 : i;
                $scope.current = $scope.competencies[j];
                getComments($scope.current);
                //$scope.current.showRatingBody = false;
            }


            $scope.selectCompetency = function (index) {
                $scope.current = $scope.competencies[index];
                getComments($scope.current);
                //$scope.current.showRatingBody = false;
            }

                    
            function getComments(currentDimension) {
                //currentDimension.rating = 0;
                if (currentDimension.IsDepartment) {
                    $http.get('/api/dimensionapi/getuserdepartmentdimensioncomments?userId=' + $scope.user.UserId + '&dimensionId=' + currentDimension.DimensionId + '&cycleId=' + $scope.cycle.Id)
                    .success(function (data) {
                        $scope.current.comments = data;
                        $scope.current.commentCount = data.length;
                    });

                    $http.get('/api/dimensionapi/getuserdepartmentdimensionratings?userId=' + $scope.user.UserId + '&dimensionId=' + currentDimension.DimensionId + '&cycleId=' + $scope.cycle.Id)
                    .success(function (data) {
                        $scope.current.ratings = data;
                        $scope.current.ratingsCount = data.length;
                    });
                }
                else {
                    $http.get('/api/dimensionapi/getuserdimensioncomments?userId=' + $scope.user.UserId + '&dimensionId=' + currentDimension.DimensionId + '&cycleId=' + $scope.cycle.Id)
                    .success(function (data) {
                        $scope.current.comments = data;
                        $scope.current.commentCount = data.length;
                    });

                    $http.get('/api/dimensionapi/getuserdimensionratings?userId=' + $scope.user.UserId + '&dimensionId=' + currentDimension.DimensionId + '&cycleId=' + $scope.cycle.Id)
                    .success(function (data) {
                        $scope.current.ratings = data;
                        $scope.current.ratingsCount = data.length;
                    });
                }
            }

            // func init
            $scope.Comment = {
                UserId: null,
                DimensionId: null,
                AppraisalCycleId: null,
                CommentBody: null
            };

            $scope.addComment = function (isDepartment) {
                $scope.Comment.UserId = $scope.user.UserId;
                $scope.Comment.DimensionId = $scope.current.DimensionId;
                $scope.Comment.AppraisalCycleId = $scope.cycle.Id;
                $scope.Comment.CommentBody = $scope.current.comment;

                var postCommentUrl = isDepartment ? '/api/DimensionApi/AddDepartmentComment/' : '/api/DimensionApi/AddComment/';

                $http({
                    method: 'POST',
                    url: postCommentUrl,
                    data: $scope.Comment
                }).then(function successCallback(response) {
                    // this callback will be called asynchronously
                    // when the response is available
                    $scope.current.comments.push(response.data);
                    $scope.Comment.CommentBody = '';
                    toastr.success("Your comment has been added");
                    $scope.current.commentCount += 1;
                    $scope.current.comment = '';
                }, function errorCallback(response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                    toastr.error("Error: " + response.data.Message);
                });
                        
            }

            $scope.deleteComment = function (comment, isDepartment) {
                var deleteCommentUrl = isDepartment ? '/api/DimensionApi/DeleteDepartmentComment?commentId=' : '/api/DimensionApi/DeleteComment?commentId=';

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
                            url: deleteCommentUrl + comment.UserDimensionCommentId,
                        }).then(function successCallback(response) {
                            var index = $scope.current.comments.indexOf(comment);
                            $scope.current.comments.splice(index, 1);
                            $scope.current.commentCount -= 1;
                            swal("Deleted", "Your comment has been deleted", "success");
                        }, function errorCallback(response) {
                            swal("Error", "Error deleting this comment, please try again", "error")
                        });
                    }
                });
            }

            $scope.Rating = {
                UserId: null,
                DimensionId: null,
                AppraisalCycleId: null,
                DimensionMaxScore: 0,
                Score: 0
            };

            $scope.addRating = function (isDepartment) {
                if ($scope.current.rating === 0 || $scope.current.rating === '0') {
                    toastr.error("Your rating has to be greater than zero (0)");
                }
                else {
                    $scope.Rating.UserId = $scope.user.UserId;
                    $scope.Rating.DimensionId = $scope.current.DimensionId;
                    $scope.Rating.AppraisalCycleId = $scope.cycle.Id;
                    $scope.Rating.DimensionMaxScore = $scope.current.MaxScore;
                    $scope.Rating.Score = $scope.current.rating;

                    var postRatingUrl = isDepartment ? '/api/DimensionApi/AddDepartmentRating/' : '/api/DimensionApi/AddRating/';

                    $http({
                        method: 'POST',
                        url: postRatingUrl,
                        data: $scope.Rating
                    }).then(function successCallback(response) {
                        $scope.current.ratings.push(response.data);
                        $scope.Rating.Score = 0;
                        toastr.success("Your rating has been added");
                        $scope.current.ratingsCount += 1;
                        $scope.current.rating = 0;
                    }, function errorCallback(response) {
                        toastr.error("Error: " + response.data.Message);
                    });
                }
            }

            $scope.deleteRating = function (rating, isDepartment) {
                var deleteRatingUrl = isDepartment ? '/api/DimensionApi/DeleteDepartmentRating?evaluationId=' : '/api/DimensionApi/DeleteRating?evaluationId=';

                swal({
                    title: "Delete rating",
                    text: "Are you sure you want to delete your rating?",
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
                            url: deleteRatingUrl + rating.UserDimensionEvaluationId,
                        }).then(function successCallback(response) {
                            var index = $scope.current.ratings.indexOf(rating);
                            $scope.current.ratings.splice(index, 1);
                            $scope.current.ratingsCount -= 1;
                            swal("Deleted", "Your rating has been deleted", "success");
                        }, function errorCallback(response) {
                            swal("Error", "Error deleting this rating, please try again", "error")
                        });
                    }
                });
            }

        }]);


    app.factory('dimensionService', dimensionService);
    dimensionService.$inject = ['$http'];
    function dimensionService($http) {
                
        return {
            competencyList: function () {
                var orgId = angular.element('#orgId').val();
                $http.get('/api/organizationapi/dimensions?organizationId=' + orgId).success(function (data) {
                    return data;
                });
            }
        }
                
    }

})();