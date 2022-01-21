/*
	Web Framework 9Pt Positioning Selector

	This property editor allows us to show a 9 position grid
	and select a value with our mouse.
*/
angular.module("umbraco").controller("humble_umbraco_propertyEditors_ninePtPositioningController", function ($scope) {
	// Set the default value if possible
	if(!$scope.model.value)
	$scope.model.value = $scope.model.config.defaultValue || "";

	/*
		This list builds the grid of positions
		we present as options to the user.
	*/
	$scope.positions = {
		1: "-top -left",
		2: "-top -center",
		3: "-top -right",
		4: "-middle -left",
		5: "-middle -center",
		6: "-middle -right",
		7: "-bottom -left",
		8: "-bottom -center",
		9: "-bottom -right"
	};

	/*
		We call setValue() when a click event occurs from
		a color option.
	*/
	$scope.setValue = function (value) {

		// A value should have been provided.
		if (!value) return;

		// Allow unselecting.
		if (value == $scope.model.value)
			$scope.model.value = null;

		// Normal operation - set value.
		else
			$scope.model.value = value;
	};

	/*
		We use isActive() to provide an active state to a
		color option if selected.
	*/
	$scope.isActive = function (value) {

		// No scope value, or no value so return nothing.
		if (!$scope.model.value || !value) return "";

		// Not the active value.
		if ($scope.model.value != value) return "";

		// Active value found!
		return "-active";
	};

});