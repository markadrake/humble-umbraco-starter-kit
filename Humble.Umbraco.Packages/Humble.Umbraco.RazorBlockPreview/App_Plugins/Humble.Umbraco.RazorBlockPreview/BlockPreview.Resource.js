(function () {
	"use strict";

	function razorBlockPreviewResource($http, umbRequestHelper) {

		var apiUrl = "/umbraco/backoffice/api/razorblockpreview/previewMarkup";

		var resource = {
			getPreview: getPreview
		};

		return resource;

		function getPreview(data, pageId, culture) {

			return umbRequestHelper.resourcePromise(
				$http.post(apiUrl + "?pageId=" + pageId + "&culture=" + culture, data),
				"Failed getting preview markup"
			);
		};
	}

	angular.module("umbraco.resources").factory("razorBlockPreviewResource", razorBlockPreviewResource);

})();
