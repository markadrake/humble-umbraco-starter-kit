(()=>{"use strict";window.app={},window.app.dualLayerSlider=function(e){var t=this;this.log=function(e){e&&t.debug&&("string"==typeof e?console.log("Dual Layer Slider: "+e):(console.log("Dual Layer Slider:"),console.log(e)))},this.init=function(){t.log("init() called"),t.setActiveState(),t.handlePagination(),t.handleNext()},this.setActiveState=function(){t.log("setActiveState() called");var e=t.element.querySelectorAll(".-active");[].map.call(e,(function(e){e.classList.remove("-active")}));var n=t.fgSequence.children[t.activeIndex],i=t.bgSequence.children[t.activeIndex],a=t.pages[t.activeIndex];i.classList.add("-active"),n.classList.add("-active"),a.classList.add("-active")},this.handlePagination=function(){t.log("handlePagination() called"),[].map.call(t.pages,(function(e,n){e.addEventListener("click",(function(e){e.preventDefault(),e.stopPropagation(),t.activeIndex=n,t.log("moving to index "+t.activeIndex),t.move()}))}))},this.handleNext=function(){t.log("handleNext() called"),t.next.addEventListener("click",(function(e){e.preventDefault(),e.stopPropagation(),t.activeIndex++,t.activeIndex==t.pages.length&&(t.activeIndex=0),t.log("moving to index "+t.activeIndex),t.move()}))},this.move=function(){t.log("move() called"),t.setActiveState(),t.translation=-100*t.activeIndex,t.log("translation "+t.translation),t.bgSequence.style.transform="translateX("+t.translation+"%)",t.fgSequence.style.transform="translateX("+t.translation+"%)"},this.reset=function(){t.log("reset() called"),t.bgSequence.style.transform="translateX("+t.translation+"%)",t.fgSequence.style.transform="translateX("+t.translation+"%)"},e&&(this.debug=!0,this.log("constructor() called"),this.element=e,this.fg=e.querySelector(".fg"),this.fgSequence=this.fg.querySelector(".sequenced"),this.bg=e.querySelector(".bg"),this.bgSequence=this.bg.querySelector(".sequenced"),this.pagination=this.element.querySelector(".pagination"),this.pages=this.pagination.querySelectorAll(".page"),this.next=this.pagination.querySelector(".next"),this.fg&&this.fgSequence&&this.bg&&this.bgSequence&&(this.sequenceCount=this.fgSequence.children.length,this.activeIndex=0,this.translation=0,this.maxTranslation=this.sequenceCount-100,this.init()))};var e=new Event("initialized");window.dispatchEvent(e)})();