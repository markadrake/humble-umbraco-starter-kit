class LazyLoad {
	pictureEls: NodeListOf<HTMLPictureElement>;

	constructor() {
		window.addEventListener("load", (e) => {
			this.loadPictures();
		});
	}

	private loadPictures() {
		this.pictureEls = document.querySelectorAll("picture[data-lazy-picture]");

		this.pictureEls.forEach(el => {
			let img = document.createElement("img");
			img.alt = el.dataset.alt;
			el.appendChild(img);
		});
	}
};

export default LazyLoad;
