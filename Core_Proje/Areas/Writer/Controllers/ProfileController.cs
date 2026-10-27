using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureURL = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory(); // Projenin çalıştığı ana dizin yolu
                var extension = Path.GetExtension(p.Picture.FileName); // Yüklenen dosyanın uzantısı(.jpg, .png vs.)
                var imagename = Guid.NewGuid() + extension; // Benzersiz bir dosya adı üretir
                var savelocation = resource + "/wwwroot/userimage/" + imagename; // Resmin kaydedileceği tam fiziksel yolu belirler
                var stream = new FileStream(savelocation, FileMode.Create); // Belirtilen yolda yeni bir dosya akışı (Stream) başlatır.
                await p.Picture.CopyToAsync(stream); // Resmi fiziksel olarak sunucudaki klasöre kopyalar/yazar
                user.ImageUrl = imagename; // Veritabanına kaydedilmek üzere kullanıcının ImageUrl alanına yeni dosya adını atar.
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}

// User.Identity.Name: O an sisteme giriş yapmış olan kullanıcının kullanıcı adını Cookie'den okur.
// FindByNameAsync: Bu kullanıcı adını veritabanında arar ve kullanıcının tüm satır verisini (Name, Surname, ImageUrl vs.) getirir.