/*
 * Icon Picker Controller
 * - Slightly modified from Umbraco OOTB.
 * - Prefixed with `Humble`.
 * - Injected `$q, $http, notificationsService, navigationService, appState, treeService` to function scope.
 * - Removed `setTitle` function.
 * - Modify `close` to call `humbleClose`;
 * - Modify `submit` to call `humbleSubmit`;
 * 
 * Original:
 * https://github.com/umbraco/Umbraco-CMS/blob/v9/dev/src/Umbraco.Web.UI.Client/src/views/common/infiniteeditors/iconpicker/iconpicker.controller.js
 * 
 */
function IconPickerController($scope, $q, $http, notificationsService, navigationService, appState, treeService, editorService) {

	var vm = this;

	function onInit() {
		// open the icon picker immediately
		openIconPicker();
	}

	// https://github.com/umbraco/Umbraco-CMS/blob/687670cc0be5063ad108b7208938cba749599703/src/Umbraco.Web.UI.Client/src/views/propertyeditors/listview/layouts.prevalues.controller.js#L60
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
	}

	function getCurrentNodesIcon() {
		const contentId = parseInt($scope.currentNode.id);
		if (!contentId || contentId === 0) return;

		return $q(function (resolve, reject) {
			$http.post(`/umbraco/api/contentnodeicons/geticon/`, contentId).then((response) => {
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
	}

	function refreshTree() {
		let currentNode = appState.getTreeState("selectedNode"),
			currentPath = treeService.getPath(currentNode);

		treeService.loadNodeChildren({ node: currentNode.parent() }).then(() => {
			navigationService.syncTree({ tree: "content", path: currentPath, forceReload: true });
		});
	}

	function onBeforeInit() {
		if (!$scope.model) {
			$scope.model = {
				icon: null,
				color: null
			}
		}

		getCurrentNodesIcon().then((data) => {
			$scope.model.icon = data.icon;
			$scope.model.color = data.color;
		}, () => {
			$scope.model.icon = "icon-activity";
			$scope.model.color = "color-black";
		}).then(() => {
			onInit();
		});
	}

	function submit() {
		const contentId = $scope.currentNode.id,
			icon = $scope.model.icon,
			iconColor = $scope.model.color;

		$http.post("/umbraco/api/contentnodeicons/saveicon", {
			contentId,
			icon,
			iconColor
		}).then((response) => {
			close();
			refreshTree();
			notificationsService.success("Icon Set", "Your custom icon has been applied to this content node.");
		}, (reject) => {
			notificationsService.error("Icon Not Set", "Something went wrong.");
		});
	}

	function close() {
		navigationService.hideMenu();
	}

	function humbleRemove() {
		const contentId = parseInt($scope.currentNode.id);
		if (!contentId || contentId === 0) return;

		$http.post(`/umbraco/api/contentnodeicons/removeicon/`, contentId).then(() => {
			notificationsService.success("Icon Removed", "Your custom icon has been removed from this content node.");
			close();
			refreshTree();
		}, () => {
			notificationsService.error("Icon Not Removed", "Something went wrong.");
		});
	}

	onBeforeInit();

}

angular.module("umbraco").controller("HumbleUmbraco.Editors.IconPickerController", IconPickerController);
