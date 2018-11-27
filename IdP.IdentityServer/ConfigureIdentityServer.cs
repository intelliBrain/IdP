using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdP.IdentityServer
{
    public class ConfigureIdentityServer
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResources.Address(),

                new IdentityResource(
                    name: "IdP.IdentityServer.Identity",
                    displayName: "IdP.IdentityServer User Profile",
                    claimTypes: new[] { "IB_IdP_AccountType" })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "IdP.SimpleClient.Id",
                    ClientName = "IdP.SimpleClient",
                    ClientUri = "http://localhost:5002",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    ClientSecrets = {new Secret("THIS_IS_THE_CLIENT_SECRET".Sha256())},
                    AllowRememberConsent = true,
                    AllowOfflineAccess = true,
                    RedirectUris = { "http://localhost:5002/signin-oidc"}, // after login
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc"}, // after logout
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Address,
                        "IdP.IdentityServer.Identity"
                    }
                }
            };
        }
    }
}
