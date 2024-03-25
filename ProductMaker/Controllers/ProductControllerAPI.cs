using Microsoft.AspNetCore.Mvc;
using ProductMaker.Models;
using ProductMaker.Services;
using System.Web.Http.Description;

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
        [ResponseType(typeof(List<ProductModelDTO>))]
        public IEnumerable<ProductModelDTO> Index()
        {
            List<ProductModel> products = repository.GetAllProducts();
            // List<ProductModelDTO> productsDTOs = new List<ProductModelDTO>();

            IEnumerable<ProductModelDTO> productModelDTOs = from p in products select new ProductModelDTO(p);
            /*foreach (var p in products) 
            {
                productsDTOs.Add(new ProductModelDTO(p));
            }*/
            return productModelDTOs.ToList();
        }
        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult <IEnumerable<ProductModel>>SearchResults(string searchTerm)
        {
            return repository.SearchProducts(searchTerm);
        }

        [HttpGet("ShowOneProduct/{Id}")]
        public ActionResult <ProductModelDTO>ShowDetails(int id)
        {
            ProductModel p = repository.GetProductById(id);
            ProductModelDTO pDTO = new ProductModelDTO(p);
            return pDTO;
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
