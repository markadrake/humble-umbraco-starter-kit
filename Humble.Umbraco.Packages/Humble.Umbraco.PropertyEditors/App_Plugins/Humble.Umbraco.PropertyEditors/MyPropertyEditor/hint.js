function controller($scope, validationMessageService) {

	if (!$scope.model.config) {
		$scope.model.config = {};
	}

	console.log($scope);
	console.log($scope.model);
	console.log($scope.model.config);

	$scope.$on("formSubmitting", function () {
	});

	$scope.change = function () {
		if ($scope.model.value) {
		}
	}
	$scope.model.onValueChanged = $scope.change;
	$scope.change();
}
angular.module("umbraco").controller("humble_umbraco_propertyEditors_hint", controller);