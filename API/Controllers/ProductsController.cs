using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //dependency injection to get StoreContext so that we get access to products table in our database
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
            
        }
        //use the context inside our controller
        [HttpGet]
        //Type we want to return is ActionResult type
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products= await _context.Products.ToListAsync();

            return Ok(products);
        }
        [HttpGet("{id}")] //api/Products/3
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}