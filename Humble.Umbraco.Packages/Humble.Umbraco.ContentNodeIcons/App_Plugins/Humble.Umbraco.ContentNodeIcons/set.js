"use strict";

var controllerName = "humble.umbraco.contentNodeIcons.setController",
	controller = function ($scope, $q, $http, notificationsService, navigationService, appState, treeService, editorService) {

		var vm = this,
			currentNode = appState.getMenuState("currentNode"),
			notificationFrom = "Humble",
			notificationSuccess = "Your custom icon has been applied to this content node.",
			notificationFailure = "Something went wrong.";

		console.log(currentNode);

		function onBeforeInit() {
			if (!$scope.model) {
				$scope.model = {
					icon: null,
					color: null
				}
			}

			// Check custom icons first
			getCurrentNodesIcon().then((data) => {
				$scope.model.icon = data.icon;
				$scope.model.color = data.color;
			}, () => {
				// Fallback to the node's current icon and color values
				var iconClasses = currentNode.icon,
					iconRegex = /icon-([a-z\-]+)/,
					colorRegex = /color-([a-z\-]+)/;

				$scope.model.icon = iconClasses.match(iconRegex)[0];
				$scope.model.color = iconClasses.match(colorRegex)[0];
			}).then(() => {
				onInit();
			});
		};

		function onInit() {
			openIconPicker();
		};

		// Ref: https://github.com/umbraco/Umbraco-CMS/blob/687670cc0be5063ad108b7208938cba749599703/src/Umbraco.Web.UI.Client/src/views/propertyeditors/listview/layouts.prevalues.controller.js#L60
		function openIconPicker() {
			var iconPicker = {
				icon: $scope.model.icon,
				color: $scope.model.color,
				position: "left",
				size: "small",
				submit: function (model) {
					vm.focusLayoutName = true;
					$scope.model.color = model.color;
					$scope.model.icon = model.icon;
					editorService.close();
					submit();
					close();
				},
				close: function () {
					editorService.close();
					close();
				}
			};
			editorService.iconPicker(iconPicker);
		};

		function getCurrentNodesIcon() {
			const contentId = parseInt($scope.currentNode.id);
			if (!contentId || contentId === 0) return;

			return $q(function (resolve, reject) {
				$http.post(`/umbraco/humbleUmbraco/contentNodeIcons/getIcon/`, contentId).then((response) => {
					if (!response.data) reject(null);

					let data = response.data;
					if (!data.icon || !data.iconColor) reject(null);

					resolve({
						icon: data.icon,
						color: data.iconColor
					});
				}, () => {
					reject(null);
				});
			});
		};

		function refreshTree() {
			let currentPath = treeService.getPath(currentNode);

			treeService.loadNodeChildren({
				node: currentNode.parent()
			}).then(() => {
				navigationService.syncTree({
					tree: "content",
					path: currentPath,
					forceReload: true
				});
			});
		};

		function submit() {
			const contentId = $scope.currentNode.id,
				icon = $scope.model.icon,
				iconColor = $scope.model.color;

			$http.post("/umbraco/humbleUmbraco/contentNodeIcons/setIcon", {
				contentId,
				icon,
				iconColor
			}).then((response) => {
				close();
				refreshTree();
				notificationsService.success(notificationFrom, notificationSuccess);
			}, (reject) => {
				notificationsService.error(notificationFrom, notificationFailure);
			});
		};

		function close() {
			navigationService.hideMenu();
		};

		onBeforeInit();

	};

angular.module("umbraco").controller(controllerName, controller);
