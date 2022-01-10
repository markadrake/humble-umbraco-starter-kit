"use strict";

/* Lazy Load Images */
import LazyLoad from "./lazyLoad";
(function () {
	new LazyLoad();
})();

/* CSS Preload */
(function () {
	try {
		if (!document.createElement("link").relList.supports("preload"))
			throw "Preload is not supported for link elements in this environment.";
	} catch (e) {
		window.addEventListener("load", function (e) {
			[].map.call(document.querySelectorAll("link[rel=preload]"), function (link: HTMLLinkElement) {
				link.rel = "stylesheet";
			});
		});
	}
})();

/* Queue for Inline Scripts */
declare global {
	interface Window {
		_queue: WindowQueue
	}
}

interface WindowQueue {
	onReady: Array<Function>,
	onLoad: Array<Function>,
	onInit: Array<Function>
};

(function () {
	window._queue = {
		onReady: [],
		onLoad: [],
		onInit: []
	};

	window.addEventListener("DOMContentLoaded", (e) => {
		window._queue.onReady.forEach(fn => { fn(); });
	});

	window.addEventListener("initialized", (e) => {
		window._queue.onInit.forEach(fn => { fn(); });
	});

	window.addEventListener("load", (e) => {
		window._queue.onLoad.forEach(fn => { fn(); });
	});
})();
