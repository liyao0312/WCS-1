var CarResultsApp = angular.module('CarResultsApp', []);
CarResultsApp.factory('notificationService', function ($rootScope) {
    var sharedService = {};

    sharedService.savedCars = [];

    sharedService.prepForBroadcast = function (msg) {
        this.savedCars = msg;
        this.broadcastItem();
    };

    sharedService.broadcastItem = function () {
        $rootScope.$broadcast('handleBroadcast');
    };

    return sharedService;
});
CarResultsApp.service('dataService', function ($http) {

    this.getJSONData = function () {
        return $http({
            method: 'GET',
            url: '/Home/GetJsonData'
        });
    }
    this.AddToSavedCars = function (carId) {
        return $http({
            method: 'GET',
            url: '/Home/AddAndGetJsonResult/' + carId
        });
    }
    this.RemovedFromSavedCars = function (carId) {
        return $http({
            method: 'GET',
            url: '/Home/RemoveAndGetJsonResult/' + carId
        });
    }
});