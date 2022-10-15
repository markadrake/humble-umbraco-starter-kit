(function(){

	const controllerName = "webComponentPropertyEditorWrapper";

	const controller = function($scope, editorState) {

		// Using the editor and property, create a unique key
		const model = $scope.model,
			state = editorState.getCurrent();

		$scope.key = `${state.id}-${model.alias}`;

		// Listen for changes to our value made by the web component
		window.addEventListener($scope.key, (event) => {
			if(event.detail)
				model.value = event.detail;
		});

	};

	angular.module("umbraco").controller(controllerName, controller);

})();
