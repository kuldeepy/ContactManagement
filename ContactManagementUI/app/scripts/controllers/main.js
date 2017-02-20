'use strict';

/**
 * @ngdoc function
 * @name contactManagementUiApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the contactManagementUiApp
 */
angular.module('contactManagementUiApp')
  .controller('MainCtrl', function ($scope,$http) {
    $http.get("http://localhost:61274/api/Contact")
    .then(function (response) {$scope.contacts = response.data; 
});
  });
