using _529Homework.Data;
using _529Homework.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _529Homework.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly string _connectionString;

        public UsersController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [Route("add")]
        [HttpPost]
        public void AddUser (SignupViewModel user)
        {
            var repo = new UserRepository(_connectionString);
            repo.AddUser(user, user.Password);
        }

        [Route("getcurrentuser")]
        [HttpGet]
        public User GetCurrentUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            var repo = new UserRepository(_connectionString);
            return repo.GetByEmail(User.Identity.Name);
        }

        [Route("logout")]
        [HttpPost]
        public void Logout()
        {
            HttpContext.SignOutAsync().Wait();
        }

        [Route("login")]
        [HttpPost]
        public User Login(LoginViewModel lvm)
        {
            var repo = new UserRepository(_connectionString);
            var user = repo.Login(lvm.Email, lvm.Password);
            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim("user", lvm.Email)
            };
            HttpContext.SignInAsync(new ClaimsPrincipal(
                new ClaimsIdentity(claims, "Cookies", "user", "role"))).Wait();
            return user;
        }
    }
}
