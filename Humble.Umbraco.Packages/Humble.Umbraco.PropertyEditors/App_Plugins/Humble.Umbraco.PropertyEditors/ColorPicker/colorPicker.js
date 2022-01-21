/*
	Web Framework Color Picker

	This property editor allows us to show a color picker
	with values coming directly from our branding & design
	choices in the UI project.
*/
angular.module("umbraco").controller("humble_umbraco_propertyEditors_colorPicker", function ($scope) {

	/*
		This list builds the grid of colors we allow an
		editor to choose from. You can comment colors
		you don't want to show, or add new entries
		for classes you've created.
	*/
	$scope.brandColors = {
		"Primary 1": "primary1",
		"Primary 2": "primary2",
		//"Primary 3": "primary3",
		"Secondary 1": "secondary1",
		"Secondary 2": "secondary2",
		//"Secondary 3": "secondary3",
		"Tertiary 1": "tertiary1",
		"Tertiary 2": "tertiary2",
		//"Tertiary 3": "tertiary3",
		"Accent 1": "accent1"
	};
	$scope.socialColors = {
		"Facebook": "facebook",
		"Flickr": "flickr",
		"GitHub": "github",
		"Google Plus": "googleplus",
		"Instagram": "instagram",
		"LinkedIn": "linkedin",
		"Pinterest": "pinterest",
		"Twitter": "twitter",
		"Vimeo": "vimeo",
		"YouTube": "youtube"
	};
	$scope.otherColors = {
		"White": "white",
		"Black": "black",
		"Green": "green",
		"Red": "red"
	};
	$scope.colors = {
		"Primary 1": "primary1",
		"Primary 2": "primary2",
		//"Primary 3": "primary3",
		"Secondary 1": "secondary1",
		"Secondary 2": "secondary2",
		//"Secondary 3": "secondary3",
		"Tertiary 1": "tertiary1",
		"Tertiary 2": "tertiary2",
		//"Tertiary 3": "tertiary3",
		"Accent 1": "accent1",
		"Green": "green",
		"Red": "red",
		"Facebook": "facebook",
		"Flickr": "flickr",
		"GitHub": "github",
		"Google Plus": "googleplus",
		"Instagram": "instagram",
		"LinkedIn": "linkedin",
		"Pinterest": "pinterest",
		"Twitter": "twitter",
		"Vimeo": "vimeo",
		"YouTube": "youtube"
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
		if ($scope.model.value != value) return "-not-active";

		// Active value found!
		return "-active";
	};

	/*
		We want to show the user what value they selected (name).
	*/
	$scope.setText = function (key) {
		$scope.text = key;
	};

});