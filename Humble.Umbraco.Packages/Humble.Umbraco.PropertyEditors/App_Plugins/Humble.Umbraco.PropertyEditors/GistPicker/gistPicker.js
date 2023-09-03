// AngularJS code
angular.module('umbraco').controller('GistPickerController', function ($scope, $http) {
    $scope.gistUrl = "";
    $scope.gistMetaData = null;
    $scope.numFiles = 0;
    $scope.selectedFile = null;

    $scope.fetchGistMetaData = function() {
        const gistId = $scope.extractGistId($scope.gistUrl);

        if (!gistId) {
            alert("Invalid Gist URL or ID");
            return;
        }

        const gistMetaDataUrl = `https://api.github.com/gists/${gistId}`;

        $http.get(gistMetaDataUrl).then(function(response) {
            $scope.gistMetaData = response.data;
            $scope.numFiles = Object.keys(response.data.files).length;
        }).catch(function(error) {
            console.error("Error fetching Gist metadata: ", error);
            alert("Error fetching Gist metadata");
        });
    };

    $scope.extractGistId = function(input) {
        const gistIdPattern = /[a-f0-9]{32}/;
        const match = input.match(gistIdPattern);
        return match ? match[0] : null;
    };
});