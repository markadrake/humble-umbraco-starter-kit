# Setup a Test Umbraco Instance

1. Install a _specific version_ of `Umbraco.Templates`
2. Scaffold a new project based on these templates.

> The example below references the current LTS version of Umbraco, version 10.

```
dotnet new install Umbraco.Templates::10.0.0
dotnet new umbraco --name Umbraco_10
```