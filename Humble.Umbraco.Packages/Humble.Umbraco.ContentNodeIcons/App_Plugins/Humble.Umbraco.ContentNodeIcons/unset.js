"use strict";

var controllerName = "humble.umbraco.contentNodeIcons.unsetController",
	controller = function ($scope, $http, notificationsService, navigationService, appState, treeService) {

		var vm = this,
			notificationFrom = "Humble",
			notificationSuccess = "Your custom icon has been removed from this content node.",
			notificationFailure = "Something went wrong.";

		function onInit() {
			unsetIcon();
		};

		function refreshTree() {
			let currentNode = appState.getTreeState("selectedNode"),
				currentPath = treeService.getPath(currentNode);

			treeService.loadNodeChildren({ node: currentNode.parent() }).then(() => {
				navigationService.syncTree({ tree: "content", path: currentPath, forceReload: true });
			});
		};

		function close() {
			navigationService.hideMenu();
			refreshTree();
		};

		function unsetIcon() {
			const contentId = parseInt($scope.currentNode.id);
			if (!contentId || contentId === 0) return;

			$http.post(`/umbraco/humbleUmbraco/contentNodeIcons/unsetIcon/`, contentId)
				.then(() => {
					notificationsService.success(notificationFrom, notificationSuccess);
					close();
				}, () => {
					notificationsService.error(notificationFrom, notificationFailure);
					close();
				});
		};

		onInit();

	};

angular.module("umbraco").controller(controllerName, controller);
