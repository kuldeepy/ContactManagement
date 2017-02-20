'use strict';

/**
 * @ngdoc function
 * @name contactManagementUiApp.controller:NewCtrl
 * @description
 * # NewCtrl
 * Controller of the contactManagementUiApp
 */
angular.module('contactManagementUiApp')
  .controller('NewCtrl', function ($scope,$http,$location) {
    $scope.extractAddress = function(){
    	var address = $scope.address;
    	if(address != undefined && address != null)
    	{
	    	var array = address.split(' ');
	    	if(array[0] != undefined && array[0] != null)
	    	{
	    		$scope.contact.Street = array[0];
	    	}
	    	if(array[1] != undefined && array[1] != null)
	    	{
	    		$scope.contact.Direction = array[1];
	    	}
	    	if(array[2] != undefined && array[2] != null)
	    	{
	    		$scope.contact.StreetName = array[2];
	    	}
	    	if(array[3] != undefined && array[3] != null)
	    	{
	    		$scope.contact.StreetType = array[3];
	    	}
    	}
    },

    $scope.Save = function(){
    	var contact = $scope.contact;
    	if(contact != null && contact != undefined)
    	{
		    	$http.post("http://localhost:61274/api/Contact", contact)
		    	.then(
		    			function(data){
		    				$location.path('/').replace();
		    			},
		    			function(error)
		    			{
		    				alert(error);
		    				$location.path('/').replace();
		    			});
    	}
    }

  });
