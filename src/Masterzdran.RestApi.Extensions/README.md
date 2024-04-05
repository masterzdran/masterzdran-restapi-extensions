
# SwashbuckleExtensions


csproj
```xml
  <PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
    <DocumentationFile>Masterzdran.RestApi.Extensions.xml</DocumentationFile>
  </PropertyGroup>

```

appsettings

scopes key value pair:
key = scope
value = descriptions
if the scope key has ':' should be replace by '__'. This will be translated by the extesion to ':'.
