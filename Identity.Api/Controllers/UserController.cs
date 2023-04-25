using Identity.Api.Models;
using Identity.Api.Models.ViewModesl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        readonly UserManager<AppUser> _userManager;
        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("SignIn")]
        public async Task<string> SignIn(AppUserViewModel appUserViewModel)
        {
            
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = appUserViewModel.UserName,
                    Email = appUserViewModel.Email
                };
                IdentityResult result = await _userManager.CreateAsync(appUser, appUserViewModel.Sifre);
                if (result.Succeeded)
                    return "qeydiyyat ugurludur";
                else
                    return result.Errors.ToList()?.FirstOrDefault()?.Description??"xəta";
                        
            }
            return "qeydiyyat ugursuzdur";
        }
    }
}
