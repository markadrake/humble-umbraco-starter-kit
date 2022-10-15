(function () {
	'use strict';

	function previewResource($http, umbRequestHelper) {

		var apiUrl = "https://localhost:44307/umbraco/backoffice/api/blocklistpreviews/previewMarkup";

		var resource = {
			getPreview: getPreview
		};

		return resource;

		function getPreview(data, pageId, culture) {

			return umbRequestHelper.resourcePromise(
				$http.post(apiUrl + '?pageId=' + pageId + '&culture=' + culture, data),
				'Failed getting preview markup'
			);
		};
	}

	angular.module('umbraco.resources').factory('TwentyFourDays.Resources.PreviewResource', previewResource);

})();
