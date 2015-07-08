var app = angular.module('app', []);

app.controller('CidadeController', function($scope, $http, params) {
    
    function clear() {
        $scope.cidade = {};
        $scope.editing = false;
        $scope.cidadeEditing = null;
    }

    $http.get(params.urlList).success(function(response) {
        $scope.cidades = response;
        clear();
    });

    $scope.add = function() {
        $http.post(params.urlAdd, $scope.cidade).success(function(response) {
            if (response.Status) {
                $scope.cidades.push(response.Model);
            }
        });
    }

    $scope.edit = function (cidade) {
        if ($scope.editing)
            cancel();

        $scope.cidade = cidade;
        $scope.cidades.splice($scope.cidades.indexOf(cidade), 1);
        $scope.editing = true;
        $scope.cidadeEditing = cidade;
    }

    $scope.cancel = function () {
        $scope.cidades.push($scope.cidadeEditing);
        clear();
    }

    $scope.remove = function (cidade) {
        $http.post(params.urlRemove, { Id: cidade.id}).success(function (response) {
            if (response.Status) {
                $scope.cidades.splice($scope.cidades.indexOf(cidade), 1);
            }
        });
    }

});