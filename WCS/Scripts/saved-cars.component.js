var SavedCarsController = function ($http,$scope,$attrs,sharedService)
{
    var current = this;
    current.carlist = [];

    $scope.buttonName = $attrs.actionName;
    var actionPath = $attrs.actionPath;
    $scope.$on('handleBroadcast', function () {
        debugger;
        current.carlist = sharedService.savedCars;
    });
    $scope.SaveCar = function (carId)
    {
        return $http({
            method: 'GET',
            url: '/Home/' + actionPath + '/' + carId
        }).then(function successCallback(response) {

            current.carlist = response.data.SavedCars;
        }, function errorCallback(response) {
        });
    }

    $http({
        method: 'GET',
        url: '/Home/GetJsonData'
    }).then(function successCallback(response) {
        current.carlist = response.data.SavedCars;
    }, function errorCallback(response) {
    });    
}

SavedCarsController.$inject = ['$http', '$scope', '$attrs', 'mySharedService'];

angular.
  module('CarResultsApp').
  component('savedCars', {
      templateUrl: '../Scripts/car-list.template.html',
      controller: SavedCarsController
  });