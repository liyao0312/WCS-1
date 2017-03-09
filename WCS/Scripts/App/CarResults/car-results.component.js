var CarResultsController = function ($http, $scope, $attrs, notificationService, dataService)
{
    var current = this;
    current.carlist = [];

    $scope.buttonName = $attrs.actionName;
    
    $scope.DoAction = function (carId)
    {
        return dataService.AddToSavedCars(carId)
            .then(function successCallback(response) {
                //update the savedCars list
                notificationService.prepForBroadcast(response.data.SavedCars);
            }, function errorCallback(response) {
                console.log(response);
            });
    }

    dataService.getJSONData()
        .then(function successCallback(response) {
            current.carlist = response.data.Results;
        }, function errorCallback(response) {
            console.log(response);
        });
}

CarResultsController.$inject = ['$http', '$scope', '$attrs', 'notificationService', 'dataService'];

angular.
  module('CarResultsApp').
  component('carResults', {
      templateUrl: '../Scripts/App/Shared/car-list.template.html',
      controller: CarResultsController
  });