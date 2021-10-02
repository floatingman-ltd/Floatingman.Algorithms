# Readme

## Setting up Nuget 

> Try setting thr nuget config in the WSL2 path and then mounting the folder the same as with SSH and GPG keys.

**These are the manual steps required**

```sh
dotnet nuget add source "https://nuget.pkg.github.com/floatingman-ltd/index.json" --name "GITHUB" --username waltiam --store-password-in-clear-text --password {github api key}
```



**This is a local configuration**

``` sh
# dotnet new nugetconfig 
# dotnet nuget add source "https://nuget.pkg.github.com/floatingman-ltd/index.json" --name "GITHUB"
```
