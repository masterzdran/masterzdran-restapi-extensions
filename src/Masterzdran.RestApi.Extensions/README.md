# SwashbuckleExtensions

This is the first attempt to simplify the "basic" configuration of Swashbuckle Swagger in the projects. Most projects are pretty straight away, with the same configurations. Instead of copying pasting those configurations, this library offer a simple interface and expect the appsettings being properly set for the flow it self.

Also offer the flexibility to create new "configurations" keeping the appsettings structure.

## CSPROJ Configurations

```xml
  <PropertyGroup>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>

```

## APPSETTINGS Configurations

```text
scopes key value pair:

key = scope
value = descriptions

if the scope key has ':' should be replace by '\_\_'. This will be translated by the extension to ':'.
```

### Complete appSettings Section

```json
  "SwaggerOptions": {
    "OpenApiInfo": {
      "Title": "ToDo API",
      "Description": "A simple example ASP.NET Core Web API",
      "Version": "v1",
      "TermsOfService": "https://example.com/terms",
      "Contact": {
        "Name": "Shayne Boyer",
        "Email": "no@rmail.com",
        "Url": "https://twitter.com/spboyer"
      },
      "License": {
        "Name": "Use under LICX",
        "Url": "https://example.com/license"
      }
    },
    "OpenApiSecurityScheme": {
      "Type": "OAuth2",
      "Description": " OAuth2.0 Auth Code with PKCE",
      "Name": " oauth2",
      "Flows": {
        "Implicit": {
         "AuthorizationUrl": "",
         "TokenUrl": "",
         "RefreshUrl": "",
         "Scopes": {
           "": ""
         }
        },
        "Password": {
         "AuthorizationUrl": "",
         "TokenUrl": "",
         "RefreshUrl": "",
         "Scopes": {
           "": ""
         }
        },
        "ClientCredentials": {
         "AuthorizationUrl": "",
         "TokenUrl": "",
         "RefreshUrl": "",
         "Scopes": {
           "": ""
         }
        },
        "AuthorizationCode": {
          "AuthorizationUrl": "",
          "TokenUrl": "",
          "RefreshUrl": "",
          "Scopes": {
          }
        }
      }
    },
    "SwaggerEndpoint": "",
    "ApiName": "",
    "Name": "",
    "OpenIdClientId": "",
    "XmlFile": "",
    "ApiKeyHeader": "",
    "ApiKeyHeaderToken": ""
  },
```

### "SwaggerOptions":"OpenApiInfo"

OpenApi Swagger metadata information. Should be as complete as possible.

```json
    "OpenApiInfo": {
      "Title": "ToDo API",
      "Description": "A simple example ASP.NET Core Web API",
      "Version": "v1",
      "TermsOfService": "https://example.com/terms",
      "Contact": {
        "Name": "Shayne Boyer",
        "Email": "no@rmail.com",
        "Url": "https://twitter.com/spboyer"
      },
      "License": {
        "Name": "Use under LICX",
        "Url": "https://example.com/license"
      }
    },
```

### Swagger complementaty appsettigs

````json
{
  "SwaggerEndpoint": "",
  "ApiName": "",
  "Name": "",
  "OpenIdClientId": "",
  "XmlFile": ""
}


## OAuth Flows

### OAuth2 Implicit Flow appsettings

```json
Flow{
  "Implicit": {
    "AuthorizationUrl": "",
    "TokenUrl": "",
    "RefreshUrl": "",
    "Scopes": {
      "key": "value"
    }
  }
}
````

### OAuth2 Password Flow appsettings

```json
Flow{
  "Password": {
    "AuthorizationUrl": "",
    "TokenUrl": "",
    "RefreshUrl": "",
    "Scopes": {
      "key": "value"
    }
  }
}
```

### OAuth2 ClientCredentials Flow appsettings

```json
Flow{
  "ClientCredentials": {
    "AuthorizationUrl": "",
    "TokenUrl": "",
    "RefreshUrl": "",
    "Scopes": {
      "key": "value"
    }
  }
}
```

### OAuth2 AuthorizationCode Flow appsettings

```json
Flow{
  "AuthorizationCode": {
    "AuthorizationUrl": "",
    "TokenUrl": "",
    "RefreshUrl": "",
    "Scopes": {
      "key": "value"
    }
  }
}
```

### OAuth2 APIKEY Flow appsettings

```json
{
  "ApiKeyHeader": "X-API-KEY",
  "ApiKeyHeaderToken": "APITOKEN"
}
```

# Code Samples

## OAuth2 Authorization

Program.cs

```csharp
// Get Options
SwaggerExtensionsOptions swaggerOptions = new SwaggerExtensionsOptions();
builder.Configuration.GetSection(SwaggerExtensionsConstants.SwaggerOptionsConfiguration).Bind(swaggerOptions);

// Add  Authentication
builder.Services
.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// ... Other configurations

// Register the 'automatic' Swagger generator configurations.
builder.Services.AddCustomSwaggerGenerator(swaggerOptions);

// ... Other configurations

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger(swaggerOptions);
}

// ... Other configurations
```

## Custom OAuth2 With 'Authorization Code' Flow

**Program.cs**

```csharp
// Register the Add Custom OAuth2 With Authorization Code Flow configurations.
builder.Services.AddCustomOAuth2WithAuthorizationCodeFlowSwaggerGenerator(swaggerOptions);
```

## Custom OAuth2 With 'Client Credentials' Flow

**Program.cs**

```csharp
// Register the Custom OAuth2 With Client Credentials Flow configurations.
builder.Services.AddCustomOAuth2WithClientCredentialsFlowSwaggerGenerator(swaggerOptions);
```

## Custom OAuth2 With 'Implicit' Flow

**Program.cs**

```csharp
// Register the Custom OAuth2 With Implicit Flow configurations.
builder.Services.AddCustomOAuth2WithImplicitFlowSwaggerGenerator(swaggerOptions);
```

## Custom OAuth2 With 'Client Credentials' Flow

**Program.cs**

```csharp
// Register the Custom OAuth2 With Client Credentials Flow configurations.
builder.Services.AddCustomOAuth2WithClientCredentialsFlowSwaggerGenerator(swaggerOptions);
```

## Add Custom OAuth2 With 'Password' Flow Swagger Generator

**Program.cs**

```csharp
// Register the Custom OAuth2 With Password Flow configurations.
builder.Services.AddCustomOAuth2WithPasswordFlowSwaggerGenerator(swaggerOptions);
```

## Add Custom 'ApiKey

**Program.cs**

```csharp
SwaggerExtensionsOptions swaggerOptions = new SwaggerExtensionsOptions();
builder.Configuration.GetSection(SwaggerExtensionsConstants.SwaggerOptionsConfiguration).Bind(swaggerOptions);
var apiKey = swaggerOptions.ApiKeyHeaderToken;
var apikeyHeader = swaggerOptions.ApiKeyHeader;

// ... Other configurations

builder.Services.AddSingleton(new SimpleApiKeyAuthenticationSchemeOptions { ApiKey = apiKey });
builder.Services.AddAuthentication(apikeyHeader)
    .AddScheme<SimpleApiKeyAuthenticationSchemeOptions, SimpleApiKeyAuthenticationHandler>(
        apikeyHeader,
        opts => opts.ApiKey = apiKey
    );

// Register the 'automatic' Swagger generator configurations.
builder.Services.AddCustomApiKeySwaggerGenerator(swaggerOptions);
```

# Contributors

- [@masterzdran](https://github.com/masterzdran)

# Attribution

<a href="https://www.flaticon.com/free-icons/api" title="api icons">Api icons created by Smashicons - Flaticon</a>
