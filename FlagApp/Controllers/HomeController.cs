using FlagApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlagApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UygulamaDbContext _db;
        private readonly IWebHostEnvironment env;

        public HomeController(ILogger<HomeController> logger, UygulamaDbContext db, IWebHostEnvironment env)
        {
            _logger = logger;
            _db = db;
            this.env = env;
        }

        public IActionResult Index()
        {
            return View(_db.Flags.Include(x => x.Colors).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FlagCreateViewModel model)
        {
            model.Flag.ImageUrl = ResmiKaydet(model.Image);
            _db.Flags.Add(model.Flag);
            _db.SaveChanges(); 
            

            return View();
        }

        private string ResmiKaydet(IFormFile file)
        {
            if (file.Length==0|| file==null)         
                return null;

            string uzanti = Path.GetExtension(file.FileName);
            string yeniAd = Guid.NewGuid() + uzanti;
            string kayitYolu = Path.Combine(env.WebRootPath, "Images", yeniAd);

            using (var fs = System.IO.File.Create(kayitYolu))
            {
                file.CopyTo(fs);
            }
            return kayitYolu;

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
