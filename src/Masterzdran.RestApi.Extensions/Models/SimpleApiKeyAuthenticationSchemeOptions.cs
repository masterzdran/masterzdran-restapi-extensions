using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace Masterzdran.RestApi.Extensions.Models
{
    public sealed class SimpleApiKeyAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public const string ApiKeyDefaultSchema = "X-API-KEY";
        public string ApiKey { get; set; }
    }
}
