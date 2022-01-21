"use strict";

(function () {

	const controllerName = "humble_element_dualSlider",
		controller = function ($scope, mediaResource) {

			// Build a set of background images 
			$scope.images = [];

			$scope.block.data.slides.contentData.forEach((slide) => {

				let mediaKey = slide.backgroundImage[0].mediaKey;

				mediaResource.getById(mediaKey).then((media) => {
					$scope.images.push(media.mediaLink);
				});

			});
		};

	angular.module("umbraco").controller(controllerName, controller);

})();
