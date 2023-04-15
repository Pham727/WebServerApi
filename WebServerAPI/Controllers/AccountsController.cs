using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServerAPI.Models;
using WebServerAPI.Repositories;

namespace WebServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController: ControllerBase
    {
        private readonly IAccountRepository accountsRepo;

        public AccountsController( IAccountRepository repo) { 
            accountsRepo = repo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp( SignUpModel model)
        {
            var result = await accountsRepo.SingUp(model);
            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn( SingInModel model)
        {
            var result =  await accountsRepo.SignIn(model);
            if(string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
