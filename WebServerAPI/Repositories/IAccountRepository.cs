using Microsoft.AspNetCore.Identity;
using WebServerAPI.Models;

namespace WebServerAPI.Repositories
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Sign up
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<IdentityResult> SingUp(SignUpModel model);

        /// <summary>
        /// Sign In
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<string> SignIn(SingInModel model);
    }
}
