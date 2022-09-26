window.fetch("/app_plugins/humble/backoffice/sections/automation/data.json").then((response) => {
	return response.json();
}).then((data) => {
	console.log(data);
});
