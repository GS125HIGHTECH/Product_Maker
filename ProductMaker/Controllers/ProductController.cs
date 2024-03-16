using Bogus;
using Microsoft.AspNetCore.Mvc;
using ProductMaker.Models;
using ProductMaker.Services;

namespace ProductMaker.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductsDAO products = new ProductsDAO();

            return View(products.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm) 
        { 
            ProductsDAO products = new ProductsDAO();

            List<ProductModel> productList = products.SearchProducts(searchTerm);

            return View("index", productList);
        }

        public IActionResult SearchForm() 
        {
            return View();
        }
    }
}
