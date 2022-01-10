function colorsController() {
	const vm = this;

	/*
	 * Simple Icons Integration
	 * https://github.com/simple-icons/simple-icons
	*/

	vm.colors = [
		{
			label: "Primary",
			value: "#3544b1",
			cssClass: "primary"
		},
		{
			label: "Secondary",
			value: "#f9f7f4",
			cssClass: "secondary"
		},
		{
			label: "Accent",
			value: "#f5c1bc",
			cssClass: "accent"
		},
		{
			label: "Black",
			value: "#000000",
			cssClass: "black"
		},
		{
			label: "White",
			value: "#ffffff",
			cssClass: "white"
		},
		{
			label: "Almost Black",
			value: "#303030",
			cssClass: "almost-black"
		},
		{
			label: "Almost White",
			value: "#dfdfdf",
			cssClass: "almost-white"
		},
		{
			label: "Facebook",
			value: "#1877F2",
			cssClass: "facebook"
		},
		{
			label: "Twitter",
			value: "#1DA1F2",
			cssClass: "twitter"
		},
		{
			label: "LinkedIn",
			value: "#0A66C2",
			cssClass: "linkedin"
		},
		{
			label: "YouTube",
			value: "#FF0000",
			cssClass: "youtube"
		},
		{
			label: "Twitch",
			value: "#9146FF",
			cssClass: "twitch"
		}
	];
}

angular.module("umbraco").controller("HumbleUmbraco.Dashboard.ColorsController", colorsController);
