using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practica_04.Models;
using Practica_04.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Practica_04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly FailsContext _context;


        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment, FailsContext context)
        {
            _logger = logger;
            _context = context;
            this._hostEnvironment = hostEnvironment;

        }

        public IActionResult Index()
        {
           var fails = _context.Fails.ToList();

            return View(fails);        }

        public IActionResult Fail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpPost]
        public async Task<IActionResult> Registrar(Fails objFails)
        {

                    


            if(ModelState.IsValid) 
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(objFails.imageFile.FileName);
                string extension = Path.GetExtension(objFails.imageFile.FileName);
                objFails.rootImageProduct = fileName + DateTime.Now.ToString("yyyymmddhh") + extension;
                string path = Path.Combine(wwwRootPath + "/img", fileName +  DateTime.Now.ToString("yyyymmddhh") + extension);

                using(var fileStream = new FileStream(path,FileMode.Create))
                {
                    await objFails.imageFile.CopyToAsync(fileStream);
                }
                
                
                _context.Add(objFails);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return View(objFails);
        }
    }
}
