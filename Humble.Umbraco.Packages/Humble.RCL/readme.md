By default, static assets are made available in the following path:

```
/_content/_NAMESPACE_/_PATH_/_FILE_
```

By setting the following value in your `.csproj`, you can ensure that the path above matches the path in your project:

```
<StaticWebAssetBasePath>/</StaticWebAssetBasePath>
```