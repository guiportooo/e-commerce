using AutoMapper;
using ECommerce.Api.Domain;
using ECommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICatalog catalog;
        private readonly IMapper mapper;

        public ProductsController(ICatalog catalog, IMapper mapper)
        {
            this.catalog = catalog;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Get()
            => Ok(mapper.Map<IEnumerable<ProductModel>>(catalog.GetAllProducts()));

        [HttpGet("{id}")]
        public ActionResult<ProductModel> Get(int id)
        {
            var product = mapper.Map<ProductModel>(catalog.GetProductWithId(id));

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet()]
        [Route("category/{category}")]
        public ActionResult<IEnumerable<ProductModel>> GetByCategory(string category)
        {
            var productsFromCategory = mapper.Map<IEnumerable<ProductModel>>(catalog.GetProductsFromCategory(category));

            if (!productsFromCategory.Any())
                return NotFound();

            return Ok(productsFromCategory);
        }
    }
}
