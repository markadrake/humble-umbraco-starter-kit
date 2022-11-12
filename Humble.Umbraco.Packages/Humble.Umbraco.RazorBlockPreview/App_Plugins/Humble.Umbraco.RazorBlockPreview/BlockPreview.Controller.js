(() => {
	const controllerName = "Humble.Umbraco.RazorBlockPreview";
	const controller = ($scope, $sce, $timeout, editorState, razorBlockPreviewResource) => {
		
		const activeVariant = editorState.getCurrent().variants.find(function (v) {
			return v.active;
		});

		$scope.language = activeVariant.language ? activeVariant.language.culture : "en_us";
		$scope.id = editorState.getCurrent().id;
		$scope.loading = true;
		$scope.markup = $sce.trustAsHtml("Loading preview");

		function loadPreview(blockData) {
			$scope.markup = $sce.trustAsHtml("Loading preview");
			$scope.loading = true;

			razorBlockPreviewResource.getPreview(blockData, $scope.id, $scope.language).then(function (data) {
				$scope.markup = $sce.trustAsHtml(data);
				$scope.loading = false;
			});
		}

		let timeoutPromise;

		$scope.$watch("block.data", function (newValue, oldValue) {
			$timeout.cancel(timeoutPromise);

			timeoutPromise = $timeout(function () {   //Set timeout
				loadPreview(newValue);
			}, 500);
		}, true);
	};

	angular.module("umbraco").controller(controllerName, controller);

})();