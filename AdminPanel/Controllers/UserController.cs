using BusinessLayer.Abstract;
using DataAccess.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class UserController : Controller
    {

        IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        Context con =new Context();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var informations = con.Users.FirstOrDefault(x => x.username == user.username && x.password == user.password);
            if (informations != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, informations.username),
                    new Claim(ClaimTypes.Role,informations.userRole)
                };
                var identity = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal claimprincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(claimprincipal);

                if (TempData["returnUrl"] != null)
                {
                    if (Url.IsLocalUrl(TempData["returnUrl"].ToString()))
                    {
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {

            userService.AddUser(user);
            return RedirectToAction("Login");

        }



    }
}
