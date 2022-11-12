class RazorBlockPreview extends HTMLElement {

	rootShadowElement = null;

	constructor() {
		super();
	}

	connectedCallback() {

		// Create a shadow root
		this.attachShadow({ mode: "open" });
		this.rootShadowElement = document.createElement("div");
		console.log(this.rootShadowElement);
		this.shadowRoot.appendChild(this.rootShadowElement);

	}

	static get observedAttributes() { 
		return [
			"markup",
			"stylesheet"
		]; 
	}

	attributeChangedCallback(name, oldValue, newValue) {

		if(name === "markup")
			this.handleMarkupChange(oldValue, newValue);
		
		else if (name === "stylesheet") 
			this.handleStylesheetChange(oldValue, newValue);
	}

	handleMarkupChange(oldValue, newValue) {

		// These values indicate that our markup has not loaded (yet).
		if(newValue === "{{markup}}" || newValue === "Loading preview")
			return;

		this.setInnerHTML(newValue);

	}

	handleStylesheetChange(oldValue, newValue) {

		// Exit: no value provided for stylesheet.
		if(!newValue) return;

		// Apply external styles to the shadow DOM
		const linkElem = document.createElement("link");
		linkElem.setAttribute("rel", "stylesheet");
		linkElem.setAttribute("href", newValue);
		this.shadowRoot.appendChild(linkElem);	

	}

	setInnerHTML(markup) {
		this.rootShadowElement.innerHTML = markup;
	}

}

customElements.define("razor-block-preview", RazorBlockPreview);
