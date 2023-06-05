using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SolucaoErpDomain.Auth;
public static class AuthConfigurationsHelpers
{
    public static Action<AuthenticationOptions> authOptions = options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    };
}