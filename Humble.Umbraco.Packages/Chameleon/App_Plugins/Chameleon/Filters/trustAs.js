﻿function filter($sce) {

	return function (input, type) {

		if (typeof input === "string") {
			return $sce.trustAs(type || "html", input);
		}

		console.log("trustAs filter. Error. input isn't a string");

		return "";

	};
};

angular.module("umbraco").filter("trustAs", filter);
