## Start with the Umbraco Package Template
The Umbraco Package template will create a new directory with all the necessary scaffolding for you to get started:

```
dotnet new umbracopackage -n MyPackage
```

## Hot to Set the Version of Your Package

Edit `MyPackage.csproj`:

```
<Project>
    <PropertyGroup>
		<VersionPrefix>1.0.0</VersionPrefix>
		<VersionSuffix>alpha</VersionSuffix>
    <PropertyGroup>
</Project>
```
## How to Create the Nuget Package

```
cd MyPackage
dotnet pack
```

## Add your new package as a reference to the Umbraco project.

```
<Project>
    <Import Project="..\MyPackage\build\MyPackage.targets"/>
    <ItemGroup>
        <ProjectReference Include="..\MyPackage\MyPackage.csproj"/>
    </ItemGroup>
</Project>
```