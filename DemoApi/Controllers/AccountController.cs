using DemoApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterBindingModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                return Ok(new { code = code, email = model.Email });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Confirm(ConfirmBindingModel confirm)
        {
            var user = await userManager.FindByEmailAsync(confirm.Email);
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirm.Code));

            if (user == null || user.EmailConfirmed)
            {
                return BadRequest();
            }
            else if ((await userManager.ConfirmEmailAsync(user, code)).Succeeded)
            {
                return Ok("Your email is confirmed");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
