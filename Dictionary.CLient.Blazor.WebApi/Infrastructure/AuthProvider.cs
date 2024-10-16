using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Dictionary.CLient.Blazor.WebApi.Infrastructure
{
    public class AuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        public ClaimsPrincipal cp;
        public AuthProvider(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
            cp = new ClaimsPrincipal(new ClaimsIdentity());
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await localStorageService.GetItemAsync<string>("AccessToken");

          
            if (string.IsNullOrEmpty(token))
                return new AuthenticationState(cp);

            var jwt = new JwtSecurityTokenHandler();
            var readToken = jwt.ReadJwtToken(token);
            cp = new ClaimsPrincipal(new ClaimsIdentity(readToken.Claims,"Jwt"));

            return new AuthenticationState(cp);
        }

        public async Task NotfyLoginAsync(string token)
        {



            var jwt = new JwtSecurityTokenHandler();
            var readToken = jwt.ReadJwtToken(token);
            cp = new ClaimsPrincipal(new ClaimsIdentity(readToken.Claims, "Jwt"));

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(cp)));
        }
        public async Task NotfyLogoutAsync()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(cp)));
            await localStorageService.RemoveItemAsync("AccessToken");
        }
    }
}
