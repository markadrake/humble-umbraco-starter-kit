class BlockPreview extends HTMLElement {

	rootShadowElement = null;
	stylesheets = [
		"/assets/critical.min.css",
		"/assets/app.min.css"
	];

	constructor() {
		super();
	}

	connectedCallback() {

		// Create a shadow root
		this.attachShadow({ mode: 'open' });
		this.rootShadowElement = document.createElement("div");
		console.log(this.rootShadowElement);
		this.shadowRoot.appendChild(this.rootShadowElement);

		// Apply external styles to the shadow DOM
		this.stylesheets.forEach((stylesheet) => {
			const linkElem = document.createElement('link');
			linkElem.setAttribute('rel', 'stylesheet');
			linkElem.setAttribute('href', stylesheet);
			this.shadowRoot.appendChild(linkElem);	
		});

	}

	static get observedAttributes() { 
		return [
			"markup"
		]; 
	}

	attributeChangedCallback(name, oldValue, newValue) {

		// These values indicate that our markup has not loaded (yet).
		if(newValue === "{{markup}}" || newValue === "Loading preview")
			return;

		this.setInnerHTML(newValue);
	}

	setInnerHTML(markup) {
		this.rootShadowElement.innerHTML = markup;
	}

}

customElements.define("block-preview", BlockPreview);
