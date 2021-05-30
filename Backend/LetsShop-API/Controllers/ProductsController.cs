using Core.Entities.Product;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsShop_API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly DataContext _dataContenxt;

        public ProductsController(DataContext dataContenxt)
        {
            _dataContenxt = dataContenxt;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _dataContenxt.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return Ok(await _dataContenxt.Products.FindAsync(id));
        }
    }
}
