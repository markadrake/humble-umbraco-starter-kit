import { LitElement, html } from "https://cdn.jsdelivr.net/gh/lit/dist@2/all/lit-all.min.js";

class WebComponentPropertyEditor extends LitElement {

	static properties = {
		value: {
			type: Object,
			reflect: true,
		},
		key: {
			type: String,
			reflect: false
		}
	}

	// Notify the angular wrapper that this value has changed
	triggerValueChangeEvent() {
		const event = new CustomEvent(this.key, { detail: this.value });
		window.dispatchEvent(event);
	}

	// Provide default values for our properties here
	constructor() {
		super();
		this.value = [];
	}

	// Now we have access to our properties
	connectedCallback() {
		super.connectedCallback();
		if(!this.value) this.value = [];
	}

	// Provide HTML to render
	render() { 
		return html`
			<p>There are ${this.value.length} entries.</p>
			<button class="btn" type="button" @click=${this.removeAnEntry}>Remove an Entry</button>
			<button class="btn" type="button" @click=${this.addAnEntry}>Add an Entry</button>
		`;
	}

	removeAnEntry(event) {
		this.value.pop();
		this.triggerValueChangeEvent();
	}

	addAnEntry(event) {
		this.value.push(true);
		this.triggerValueChangeEvent();
	}

}

customElements.define("web-component-property-editor", WebComponentPropertyEditor);
