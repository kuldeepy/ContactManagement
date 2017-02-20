'use strict';

/**
 * @ngdoc overview
 * @name contactManagementUiApp
 * @description
 * # contactManagementUiApp
 *
 * Main module of the application.
 */
angular
  .module('contactManagementUiApp', [
    'ngAnimate',
    'ngAria',
    'ngCookies',
    'ngMessages',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch'
  ])
  .config(function ($routeProvider,$locationProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl',
        controllerAs: 'main'
      })
      .when('/new', {
        templateUrl: 'views/new.html',
        controller: 'NewCtrl',
        controllerAs: 'new'
      })
      .otherwise({
        redirectTo: '/'
      });
      $locationProvider.html5Mode({
          enabled: true,
          requireBase: false
      });
  });
