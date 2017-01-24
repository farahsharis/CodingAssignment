angular.module('AngularGit', [])
.controller('Home', function($scope, $http) {
var days =7;
var date = new Date(new Date().getTime() - (1000*60*60*24*days));
var since = date.getFullYear()+"-"+(date.getMonth()+1)+"-"+date.getDay();

    $http.get('https://api.github.com/repos/angular/angular/issues?since='+since).
        then(function(response) {
            $scope.issues = response.data;
        });
});
