var CarResultsModule = angular.module('CarResultsApp', []);
CarResultsModule.factory('mySharedService', function ($rootScope) {
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