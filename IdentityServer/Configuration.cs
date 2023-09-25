using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class Configuration
    {
        internal static List<ApiResource> ApiResources = new List<ApiResource> {
            new ApiResource{
                Name = "Api",
                Scopes = { "Api" }
            },
        };

        internal static List<IdentityResource> IdentityResources = new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        internal static List<ApiScope> Scopes = new List<ApiScope> {
            new ApiScope{Name = "Api"},
        };

        internal static List<Client> Clients = new List<Client>{
            new Client{
                ClientId = "react",
                RequireClientSecret = false,

                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,

                AllowAccessTokensViaBrowser = true,
                RequireConsent = false,

                RedirectUris = { "https://localhost:44484/callback" },
                PostLogoutRedirectUris = { "https://localhost:44484" },

                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "Api",
                },
            }
        };
    }
}
