window.fetch("/app_plugins/Humble.Umbraco.Workflows/data.json").then((response) => {
	return response.json();
}).then((data) => {
	console.log(data);
});
