using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Masterzdran.RestApi.Extensions.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Masterzdran.RestApi.Extensions.Handler
{
    public class SimpleApiKeyAuthenticationHandler : AuthenticationHandler<SimpleApiKeyAuthenticationSchemeOptions>
    {

        public SimpleApiKeyAuthenticationHandler(
            IOptionsMonitor<SimpleApiKeyAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var apiKey = Request.Headers[SimpleApiKeyAuthenticationSchemeOptions.ApiKeyDefaultSchema];
            if (apiKey != Options.ApiKey)
            {
                return await Task.FromResult(AuthenticateResult.Fail("Invalid X-API-KEY"));
            }
            var claims = new[] { new Claim(ClaimTypes.Name, "VALID USER") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return await Task.FromResult(AuthenticateResult.Success(ticket));

        }
    }
}
