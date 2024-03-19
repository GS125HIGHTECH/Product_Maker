using Microsoft.AspNetCore.Mvc;
using ProductMaker.Models;
using ProductMaker.Services;

namespace ProductMaker.Controllers
{
    public class ProductController : Controller
    {
        ProductsDAO repository;

        public ProductController()
        {
            repository = new ProductsDAO();
        }
        public IActionResult Index()
        {
            return View(repository.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            return View("index", repository.SearchProducts(searchTerm));
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult InputForm()
        {
            return View();
        }

        public IActionResult ProcessCreate(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Insert(product);

            return RedirectToAction("Index");
        }

        public IActionResult ShowDetails(int id)
        {
            return View(repository.GetProductById(id));
        }

        public IActionResult ShowDetailsJSON(int id)
        {
            return Json(repository.GetProductById(id));
        }

        public IActionResult Edit(int id)
        {
            return View("ShowEdit", repository.GetProductById(id));
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            return View("Index", repository.GetAllProducts());
        }

        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
            repository.Update(product);
            return PartialView("_productCard", product);
        }

        public IActionResult Delete(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(id);
            if (product != null)
            {
                products.Delete(product);
            }
            return View("Index", products.GetAllProducts());
        }
    }
}
