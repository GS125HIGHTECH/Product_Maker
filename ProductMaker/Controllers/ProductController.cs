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
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(id);

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(id);

            return View("ShowEdit", product);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);

            return View("Index", products.GetAllProducts());
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
