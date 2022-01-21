/*
	Web Framework Padding Picker

	This property editor allows us to show a Padding Picker
	with values coming directly from our branding & design
	choices in the UI project.
*/
/* global angular */
angular.module("umbraco").controller("humble_umbraco_propertyEditors_paddingPicker", function ($scope) {

	/*
		This list provides options to pick from for
		padding classes.
	*/
	$scope.paddings = {
		"1 rem": "-pad:xs",
		"2 rem": "-pad:s",
		"4 rem": "-pad:m",
		"6 rem": "-pad:l"
	};
	console.log($scope);
	console.log($scope.paddings);

	if ($scope.model.value === undefined)
		$scope.model.value = "";

	/*
		We call setValue() when a click event occurs from
		a padding option.
	*/
	$scope.setValue = function (value) {

		// A value should have been provided.
		if (value === undefined) return;

		// Allow unselecting.
		if (value == $scope.model.value)
			$scope.model.value = null;

		// Normal operation - set value.
		else
			$scope.model.value = value;
	};

	/*
		We use isActive() to provide an active state to a
		padding option if selected.
	*/
	$scope.isActive = function (value) {

		// No scope value, or no value so return nothing.
		if ($scope.model.value === undefined) return "";

		// Not the active value.
		if ($scope.model.value != value) return "";

		// Active value found!
		return "-active";
	};

});