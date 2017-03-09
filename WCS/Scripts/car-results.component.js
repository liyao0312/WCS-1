var CarResultsController = function ($http,$scope,$attrs,sharedService)
{
    var current = this;
    current.carlist = [];

    $scope.buttonName = $attrs.actionName;
    var actionPath = $attrs.actionPath;
    
    $scope.SaveCar = function (carId)
    {
        return $http({
            method: 'GET',
            url: '/Home/' + actionPath + '/' + carId
        }).then(function successCallback(response) {

            //current.carlist = response.data.Results;
            sharedService.prepForBroadcast(response.data.SavedCars);
        }, function errorCallback(response) {
        });
    }

    $http({
        method: 'GET',
        url: '/Home/GetJsonData'
    }).then(function successCallback(response) {
       
        current.carlist = response.data.Results;
    }, function errorCallback(response) {
    });    
}

CarResultsController.$inject = ['$http','$scope','$attrs', 'mySharedService'];

angular.
  module('CarResultsApp').
  component('carResults', {
      templateUrl: '../Scripts/car-list.template.html',
      controller: CarResultsController
  });