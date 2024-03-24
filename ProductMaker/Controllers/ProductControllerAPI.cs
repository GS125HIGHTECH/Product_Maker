using Microsoft.AspNetCore.Mvc;
using ProductMaker.Models;
using ProductMaker.Services;

namespace ProductMaker.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductControllerAPI : ControllerBase
    {
        ProductsDAO repository;

        public ProductControllerAPI()
        {
            repository = new ProductsDAO();
        }

        [HttpGet]
        public ActionResult <IEnumerable<ProductModel>>Index()
        {
            return repository.GetAllProducts();
        }
        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult <IEnumerable<ProductModel>>SearchResults(string searchTerm)
        {
            return repository.SearchProducts(searchTerm);
        }

        [HttpGet("ShowOneProduct/{Id}")]
        public ActionResult <ProductModel>ShowDetails(int id)
        {
            return repository.GetProductById(id);
        }

        [HttpPost("insertOne")]
        public ActionResult <int> InsertOne(ProductModel product)
        {
            int newId = repository.Insert(product);
            return newId;
        }

        [HttpPut("ProcessEdit")]
        public ActionResult <ProductModel>ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            return repository.GetProductById(product.Id);
        }

        [HttpDelete("DeleteOne/{id}")]
        public ActionResult <int> DeleteOne(int id)
        {
            ProductModel product = repository.GetProductById(id);
            int success = repository.Delete(product);
            return success;
        }
    }
}
