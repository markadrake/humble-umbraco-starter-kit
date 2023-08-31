> Humble Umbraco is still in development. There is no official release date for the starter kit at this time. Individual portions of the starter kit may be released sooner. We'll update this readme file to include links to the individual nuget packages.

# Humble Umbraco Starter Kit

**Humble Umbraco** is (ironically) a highly opinionated starter kit for Umbraco 9.0. This repository is the easiest way to get started and includes every package that makes up the starter kit. Advanced users may consider installing only the packages they need.

1. [Overview](#Overview)
2. [Architecture](#Architecture)
3. [Credentials](#Credentials)
4. [Licensing](#)
5. [Testimonials](#Testimonials])

## Overview

|Package|Standalone|Use Case|Ready
---|---|---|---
Humble.Umbraco|No|The full starter kit. Includes all packages (as dependencies) and sample content.|x
_Humble.Umbraco_<br>RazorBlockPreview|Standalone|Allows for block list views to be rendered from their razor templates. Includes the benefit of Shadow DOM and custom stylesheets.|x
_Humble.Umbraco_<br>Cloudflare|Standalone|Clear Cloudflare cache when content changes are detected. Allows Umbraco Users to manually clear cache without giving them access to Cloudflare directly.|x
_Humble.Umbraco_<br>ContentNodeIcons|Standalone|Assign new color + icon combinations to any content node, regardless of the document type.|x
_Humble.Umbraco_<br>PropertyEditors|Standalone|Provides a set of property editors useful to both content authors and developers.|x
_Humble.Umbraco_<br>UI|No|Allows for customization and control over a design system.|x

## Architecture

TBD

## Upgrades

```
dotnet add package Diplo.GodMode -v '10.*'
dotnet add package Umbraco.Cms -v '10.*'
dotnet add package uSync -v '10.*'

dotnet add package Umbraco.Cms -v '10.*'
dotnet add package Umbraco.Cms -v '10.*'
dotnet add package Umbraco.Cms -v '10.*'
```

## Credentials

<table>
<thead>
<tr><th colspan=2>Umbraco Backoffice:</th></tr>
</thead>
<tbody>
<tr><th>username:</th><td>demo@nextplayerup.com</td></tr>
<tr><th>password:</th><td>umbraco123</td></tr>
</tbody>
</table>

<table>
<thead>
<tr><th colspan=2>Member:</th></tr>
</thead>
<tbody>
<tr><th>username:</th><td>demo@nextplayerup.com</td></tr>
<tr><th>password:</th><td>umbraco123</td></tr>
</tbody>
</table>

## Licensing

This project is currently licensed under MIT. Please note that after it's official release, the license for particular modules may change.

## Testimonials

�As the most qualified and insightful developer I know, this is the definitive starter kit for Umbraco available.�

_- Mark Drake_

> demo@nextplayer | umb123