using Dictionary.CLient.Blazor.WebApi.Infrastructure;
using Dictionary.Common.DTOs.Commands.User.Update;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Dictionary.CLient.Blazor.WebApi.Pages.User
{
    public class UserProfileBase : ComponentBase
    {
        [Inject]
        public AuthenticationStateProvider authenticationStateProvider { get; set; }
        [Parameter]
        public int Id { get; set; }
        public UserUpdateCommandRequest UserProfileUpdate=new UserUpdateCommandRequest();
        [Inject]
        public IHttpService httpService { get; set; }

        public string Message { get; set; }
        public async Task ChangeProfile()
        {
            var user = (await (authenticationStateProvider as AuthProvider).GetAuthenticationStateAsync()).User;
            if (user.Identity.IsAuthenticated)
            {
                Id = Convert.ToInt32(user.FindFirst(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            }


            UserProfileUpdate.Id = Id;
            UserProfileUpdate.Email = "iman@gmail.com";
                UserProfileUpdate.Surname = "Imanov";
            

            bool IsChange = await httpService.PutAsync("https://localhost:7155/api/User/Update", UserProfileUpdate);
            if (IsChange)
                Message = "ugurla yeniledi";
            else
                Message = "error";
        }
    }
}
