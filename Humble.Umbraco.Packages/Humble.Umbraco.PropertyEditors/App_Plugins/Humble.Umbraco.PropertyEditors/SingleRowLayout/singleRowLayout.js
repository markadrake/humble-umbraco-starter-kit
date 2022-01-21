/*
	TODO: parameterize this property editor.
*/
/* global angular */
angular.module("umbraco").controller("humble_umbraco_propertyEditors_singleRowLayout",
	function ($scope) {
		/*
			Hardcoded configuration below.
		*/
		$scope.rowLayouts = [
			[{
				"name": "50%",
				"class": "",
				"style": "width: 50%;"
			},
			{
				"name": "50%",
				"class": "",
				"style": "width: 50%;"
			}],
			[{
				"name": "33%",
				"class": "",
				"style": "width: 33.333333%;"
			},
			{
				"name": "66%",
				"class": "-s-2",
				"style": "width: 66.66666%;"
			}],
			[{
				"name": "66%",
				"class": "-s-2",
				"style": "width: 66.66666%;"
			},
			{
				"name": "33%",
				"class": "",
				"style": "width: 33.33333%;"
			}]
		];

		/*
			We build an array of class names
		*/
		$scope.setValue = function (row) {
			if (!row) return;

			$scope.model.value = $scope.getValue(row);
			$scope.setHighlight();
		};

		/*
			Highlight the correct row
		*/
		$scope.setHighlight = function () {
			var valueJson = JSON.stringify($scope.model.value);

			[].map.call($scope.rowLayouts, function (row) {
				var rowJson = JSON.stringify($scope.getValue(row));
				if (valueJson === rowJson) {
					row.isActive = true;
				} else {
					row.isActive = false;
				}
			});
		};

		/*
			Gets the value of the chosen row
		*/
		$scope.getValue = function (row) {
			if (!row) return;

			var value = [];
			for (var i = 0, l = row.length; i < l; i++) {
				value.push(row[i].class);
			}

			return value;
		}

		/*
			Here is where we set the default selection
		*/
		$scope.initialize = function () {
			if ($scope.model.value === null || $scope.model.value === "") {
				$scope.model.value = ["", ""];
			}
			$scope.setHighlight();
		};
		$scope.initialize();
	}
);