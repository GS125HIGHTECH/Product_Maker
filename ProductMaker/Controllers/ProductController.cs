using Bogus;
using Microsoft.AspNetCore.Mvc;
using ProductMaker.Controllers.Services;
using ProductMaker.Models;

namespace ProductMaker.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            HardCodedSampleDataRepository hardCodedSampleDataRepository = new HardCodedSampleDataRepository();
            return View(hardCodedSampleDataRepository.GetAllProducts());
        }
    }
}
