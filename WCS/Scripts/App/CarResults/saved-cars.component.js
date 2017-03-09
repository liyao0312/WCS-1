var SavedCarsController = function ($http, $scope, $attrs, notificationService, dataService)
{
    var current = this;
    current.carlist = [];

    $scope.buttonName = $attrs.actionName;
    $scope.$on('handleBroadcast', function () {
        
        current.carlist = notificationService.savedCars;
    });
    $scope.DoAction = function (carId)
    {
        return dataService.RemovedFromSavedCars(carId)
            .then(function successCallback(response) {
                current.carlist = response.data.SavedCars;
            }, function errorCallback(response) {
                console.log(response);
            });
    }

    dataService.getJSONData()
        .then(function successCallback(response) {
            current.carlist = response.data.SavedCars;
        }, function errorCallback(response) {
            console.log(response);
        });    
}

SavedCarsController.$inject = ['$http', '$scope', '$attrs', 'notificationService', 'dataService'];

angular.
  module('CarResultsApp').
  component('savedCars', {
      templateUrl: '../Scripts/App/Shared/car-list.template.html',
      controller: SavedCarsController
  });