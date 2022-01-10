function controller() {
	const vm = this;

	vm.selectedBreakpoint = null;
	vm.breakpoints = [
		{
			label: "XS",
			alias: "xs",
			widthMin: "0",
			widthMax: "39.999rem"
		},
		{
			label: "S",
			alias: "s",
			widthMin: "40rem",
			widthMax: "63.999rem"
		},
		{
			label: "M",
			alias: "m",
			widthMin: "64rem",
			widthMax: "89.999rem"
		},
		{
			label: "L",
			alias: "l",
			widthMin: "90rem",
			widthMax: "119.999rem"
		},
		{
			label: "XL",
			alias: "l",
			widthMin: "120rem",
			widthMax: ""
		}
	];

	vm.selectedDevice = null;
	vm.commonDevices = [
		{
			label: "iPhone X, XS, 11 Pro",
			width: "375px",
			height: "812px"
		},
		{
			label: "iPhone 12, 12 Pro",
			width: "390px",
			height: "844px"
		},
		{
			label: "iPhone 12 Pro Max",
			width: "428px",
			height: "926px"
		},
		{
			label: "Google Pixel 4, 4XL",
			width: "412px",
			height: "870px"
		},
		{
			label: "Google Pixel 5",
			width: "393px",
			height: "851px"
		},
		{
			label: "iPad",
			width: "768px",
			height: "1024px"
		},
		{
			label: "Desktop – 1440x1080",
			width: "1440px",
			height: "1080px"
		}
	];

	vm.select = function (key, what) {

		if (vm[key] == what) {
			vm[key] = null;
			return;
		}

		vm[key] = what;
	}
}

angular.module("umbraco").controller("HumbleUmbraco.Dashboard.BreakpointsController", controller);
