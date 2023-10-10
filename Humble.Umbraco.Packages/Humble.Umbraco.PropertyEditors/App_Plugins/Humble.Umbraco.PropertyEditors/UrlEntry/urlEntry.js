"use strict";

(function () {

    const controllerName = "humble_umbraco_propertyEditors_urlEntry",
        controller = function ($scope, $element) {
        
            // Track url input
            var input = null;
            var uuiInput = $element[0].querySelector("uui-input");
            uuiInput.addEventListener("change", (e) => {
                input = e.target.value || null;
            });
            
            // Sanitize helper
            var sanitize = (value) => {
                // Reduce multiple commas to a single comma using a regular expression
                const sanitizedString = value.replace(/,+/g, ',');

                // Remove a comma at the end of the string (if it exists)
                if (sanitizedString.endsWith(',')) {
                    return sanitizedString.slice(0, -1);
                }

                return sanitizedString;          
            };
            
            // Reset helper
            var reset = () => {
                input = null;
                uuiInput.value = null;
            };
            

            // Add the url
            $scope.addUrl = (event) => {
                $scope.model.value = sanitize(`${input},${$scope.model.value}`);
                reset();
            };
            
            // Remove a previously entered url
            $scope.removeUrl = (which) => {
                var parts = $scope.model.value.split(',');

                // Use filter to exclude the element at the specified index
                var filteredParts = parts.filter((_, index) => index !== which);

                // Join the remaining elements back into a string with commas
                $scope.model.value = filteredParts.join(',');
            };
        };

    angular.module("umbraco").controller(controllerName, controller);

})();