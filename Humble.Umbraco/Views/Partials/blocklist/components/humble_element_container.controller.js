"use strict";

(function () {

	const controllerName = "humble_element_container",
		controller = function ($scope) {
			$scope.propertyModel = $scope.$parent.$parent.block.content.variants[0].tabs[0].properties[1];
		};

	angular.module("umbraco").controller(controllerName, controller);

})();
