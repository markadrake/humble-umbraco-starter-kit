class DualLayerSlider {
	debug: boolean;
	element: HTMLElement;
	fg: HTMLElement;
	fgSequence: HTMLElement;
	bg: HTMLElement;
	bgSequence: HTMLElement;
	pagination: HTMLElement;
	pages: NodeListOf<HTMLElement>;
	next: HTMLEmbedElement;
	sequenceCount: number;
	activeIndex: number;
	translation: number;
	maxTranslation: number;

	constructor(element) {
		if (!element) return;
		this.debug = true;
		this.log(`constructor() called`);

		this.element = element;
		this.fg = element.querySelector(".fg");
		this.fgSequence = this.fg.querySelector(".sequenced");
		this.bg = element.querySelector(".bg");
		this.bgSequence = this.bg.querySelector(".sequenced");
		this.pagination = this.element.querySelector(".pagination");
		this.pages = this.pagination.querySelectorAll(".page");
		this.next = this.pagination.querySelector(".next");

		// Error state: required DOM structure is not provided.
		if (!this.fg || !this.fgSequence || !this.bg || !this.bgSequence) {
			return;
		}

		this.sequenceCount = this.fgSequence.children.length;
		this.activeIndex = 0;
		this.translation = 0;
		this.maxTranslation = this.sequenceCount - 1 * 100;

		this.init();
	}

	private log = (message) => {
		if (!message || !this.debug) return;

		if (typeof message === typeof "") {
			console.log(`Dual Layer Slider: ${message}`);
		} else {
			console.log(`Dual Layer Slider:`);
			console.log(message);
		}
	}

	private init = () => {
		this.log(`init() called`);
		this.setActiveState();
		this.handlePagination();
		this.handleNext();
	}

	private setActiveState = () => {
		this.log(`setActiveState() called`);

		const activeElements = this.element.querySelectorAll(".-active");
		[].map.call(activeElements, (element) => {
			element.classList.remove("-active");
		});

		const activeFgElement = this.fgSequence.children[this.activeIndex],
			activeBgElement = this.bgSequence.children[this.activeIndex],
			activePageElement = this.pages[this.activeIndex];

		activeBgElement.classList.add("-active");
		activeFgElement.classList.add("-active");
		activePageElement.classList.add("-active");
	}

	/*
		Handles Pagination CLicks
		- Set `this.activeIndex`
	*/
	private handlePagination = () => {
		this.log(`handlePagination() called`);

		[].map.call(this.pages, (page, index) => {
			page.addEventListener("click", (e) => {
				e.preventDefault();
				e.stopPropagation();
				this.activeIndex = index;
				this.log(`moving to index ${this.activeIndex}`);
				this.move();
			});
		});
	}

	/*
		Handles Next Click
		- Set `this.activeIndex`
	*/
	private handleNext = () => {
		this.log(`handleNext() called`);

		this.next.addEventListener("click", (e) => {
			e.preventDefault();
			e.stopPropagation();
			this.activeIndex++;
			if (this.activeIndex == this.pages.length) this.activeIndex = 0;
			this.log(`moving to index ${this.activeIndex}`);
			this.move();
		});
	}

	private move = () => {
		this.log(`move() called`);

		this.setActiveState();

		this.translation = this.activeIndex * -100;
		this.log(`translation ${this.translation}`);
		this.bgSequence.style.transform = `translateX(${this.translation}%)`;
		this.fgSequence.style.transform = `translateX(${this.translation}%)`;
	}

	private reset = () => {
		this.log(`reset() called`);

		this.bgSequence.style.transform = `translateX(${this.translation}%)`;
		this.fgSequence.style.transform = `translateX(${this.translation}%)`;
	}

}

export default DualLayerSlider;
