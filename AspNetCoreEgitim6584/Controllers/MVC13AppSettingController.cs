using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.Controllers
{
    public class MVC13AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;

        public MVC13AppSettingController(IConfiguration configuration)// Bu yönteme  Dependency Injection deniliyor.Kısacası DI diye de bahsedilir.
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            TempData["Email"] = _configuration["Email"];
            TempData["MailSunucu"] = _configuration["MailSunucu"];
            TempData["KullaniciAdi"] = _configuration["MailKullanici:UserName"];
            TempData["Sifre"] = _configuration.GetSection("MailKullanici:Password").Value;//_configiration dan 
            return View();
        }
    }
}
