using Blazored.LocalStorage;
using Dictionary.CLient.Blazor.WebApi.Infrastructure;
using Dictionary.Common.DTOs.Commands.User.Login;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Dictionary.CLient.Blazor.WebApi.Pages.Login;

public class LoginBase: ComponentBase
{
    protected UserLoginCommandRequest request=new UserLoginCommandRequest();
    [Inject]
    public IHttpService client { get; set; }
    [Inject]
    private ILocalStorageService localStorage { get; set; }
    [Inject]
    public NavigationManager navigationManager { get; set; }
    [Inject]
    public AuthenticationStateProvider authenticationStateProvider { get; set; }

    public async Task UserLogin()
    {

     UserLoginCommandResponse response= await   client.PostAsync<UserLoginCommandRequest, UserLoginCommandResponse>("https://localhost:7155/api/User/Login", request);
        if(response is not null)
        {
            await localStorage.SetItemAsync<string>("AccessToken", response.Token);

            await (authenticationStateProvider as AuthProvider).NotfyLoginAsync(response.Token);

            navigationManager.NavigateTo("/");
        }
     
    }
}
