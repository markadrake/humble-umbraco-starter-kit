function startUpDynamicContentController($q, $timeout, $scope, dashboardResource, assetsService, tourService, eventsService) {
	var vm = this;
	var evts = [];

	vm.content = {
		name: "Humble Design System",
		navigation: [
			{
				"alias": "humble.dashboard.breakpoints",
				"name": "Breakpoints",
				"icon": "icon-width",
				"view": "/App_Plugins/Chameleon/Sections/Dashboards/breakpoints.html",
			},
			{
				"alias": "humble.dashboard.colors",
				"name": "Colors",
				"icon": "icon-palette",
				"view": "/App_Plugins/Chameleon/Sections/Dashboards/colors.html",
				"active": true
			},
			{
				"alias": "humble.dashboard.typography",
				"name": "Typography",
				"icon": "icon-font",
				"view": "/App_Plugins/Chameleon/Sections/Dashboards/typography.html",
			},
			{
				"alias": "humble.dashboard.stylguide",
				"name": "Styleguide",
				"icon": "icon-app",
				"view": "/App_Plugins/Chameleon/Sections/Dashboards/styleguide.html",
			}
		]
	};
}

angular.module("umbraco").controller("HumbleUmbraco.Dashboard.DefaultController", startUpDynamicContentController);
