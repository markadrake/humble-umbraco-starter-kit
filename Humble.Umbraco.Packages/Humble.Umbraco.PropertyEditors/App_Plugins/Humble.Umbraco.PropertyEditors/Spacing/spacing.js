"use strict";

(function () {

	const controllerName = "humble_umbraco_propertyEditors_spacing",
		controller = function ($scope) {

		// Set the default value if possible
		if(!$scope.model.value)
			$scope.model.value = $scope.model.config.defaultValue || "";

		$scope.state = {
			default: "0",
			size: "",
			dimension: "",
			lastSizeSet: "auto",
			clickTimeout: null,
			modal: false,
			modalProp: null
		};
		$scope.value = {
			margins: {},
			padding: {}
		};
		$scope.default = "0";
		$scope.size = "";
		$scope.dimension = "";
		$scope.lastSizeSet = "auto";
		$scope.clickTimeout = null;
		$scope.margins = {
			top: "0",
			right: "0",
			bottom: "0",
			left: "0",
			active: false
		};
		$scope.padding = {
			top: "0",
			right: "0",
			bottom: "0",
			left: "0",
			active: false
		};

		$scope.highlight = (what) => {
			$scope.margins.active = false;
			$scope.padding.active = false;

			if (what && $scope[what]) {
				$scope[what].active = true;
			}
		};

		$scope.activate = (what, location) => {
			if (!what || !$scope[what]) return;
			if (!$scope[what][location]) return;

			if ($scope.clickTimeout) return;

			$scope.clickTimeout = setTimeout(() => {
				$scope.state.modal = true;
				$scope.state.modalProp = $scope[what][location];
				$scope.$apply();
				$scope.clickTimeout = null;
			}, 250);
		};

		$scope.setOrUnset = (what, location) => {
			if ($scope.clickTimeout) {
				clearTimeout($scope.clickTimeout);
				$scope.clickTimeout = null;
			}

			if ($scope[what][location] === $scope.default) {
				$scope[what][location] = $scope.lastSizeSet;
				return;
			}

			$scope[what][location] = $scope.default;
		};

		const validSizePattern = /^(0\.[0-9]+|[1-9][0-9]*\.*[0-9]*?)[\s]*(px|em|rem|%|vw|vh)?$/;

		$scope.interpretSize = (e) => {
			if (!$scope.size) return;

			let result = validSizePattern.test($scope.size);

			if (result) {
				let match = $scope.size.match(validSizePattern);
				let number = match[1];
				let dimension = match[2];

				console.log(match);

				if (number && dimension) {
					console.log(`${number}${dimension}`);
					$scope.size = number;
					$scope.dimension = dimension;
				} else {
					console.log(`${number}`);
					$scope.size = number;
				}
			}

			if (e && e.which === 13) {
				// set value
				// close modal
			}
		};
	};

	angular.module("umbraco").controller(controllerName, controller);

})();
