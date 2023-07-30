using AspNetCoreEgitim6584.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;
        public LoginController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email, string password)
        {
            try
            {
                var kullanici = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (kullanici != null)
                {

                    var haklar = new List<Claim>()//kullanici hakları tanımladıık
                    {
                        new Claim(ClaimTypes.Email,email)

                    };
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login");// kullanıcı için bir kimlik oluşturduk
                    ClaimsPrincipal claimsPrincipal = new(kullaniciKimligi);
                    await HttpContext.SignInAsync(claimsPrincipal);// yukarıdaki yetkilerle sisteme giriş yaptık
                    return Redirect("/Admin");
                }
                else TempData["Message"] = "<div class='alert alert-danger'>Giriş Başarısız!</div";
            }
            catch (Exception)
            {

                TempData["Message"] = "<div class='alert alert-danger'>Hata Oluştu!</div";
            }
            return View();
        }
        public async Task<ActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin");
        }
    }
}
