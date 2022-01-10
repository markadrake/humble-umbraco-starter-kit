"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class LazyLoad {
    constructor() {
        window.addEventListener("load", (e) => {
            this.loadPictures();
        });
    }
    loadPictures() {
        this.pictureEls = document.querySelectorAll("picture[data-lazy-picture]");
        this.pictureEls.forEach(el => {
            let img = document.createElement("img");
            img.alt = el.dataset.alt;
            el.appendChild(img);
        });
    }
}
;
exports.default = LazyLoad;
//# sourceMappingURL=lazyLoad.js.map