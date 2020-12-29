using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Practica_04.Controllers
{
    public class CuentaController : Controller
    {
        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sim;

        public CuentaController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            _um = um;
            _sim = sim;
        }

        public IActionResult CrearCuenta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearCuenta(string username, string correo, string password)
        {
            var user = new IdentityUser();
            user.Email = correo;
            user.UserName = username;

            var result = _um.CreateAsync(user, password).Result;

            if (result.Succeeded) {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

        public IActionResult IniciarSesion(){
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(string correo, string password)
        {
            var result = _sim.PasswordSignInAsync(correo, password, false, false).Result;

            if (result.Succeeded) {
                return RedirectToAction("Index", "home");
            } 

            ModelState.AddModelError("", "Datos no concordantes");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _sim.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


    }

}