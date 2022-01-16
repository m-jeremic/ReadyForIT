using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendTest.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BackendTest.ViewModels;

namespace BackendTest.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private DataContext context;

        private IMapper mapper;
        private IMapper mapperSingle;

        public ProductsController(DataContext db)
        {
            context = db;

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Product, ProductView>()
                .ForMember(dest => dest.Skus, opt => opt.MapFrom(src => src.ProductSkus.Select(x => x.Sku))));
            mapper = new Mapper(config);

            var configSingle = new MapperConfiguration(cfg =>
                cfg.CreateMap<Product, ProductSingle>()
            );
            mapperSingle = new Mapper(configSingle);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            IEnumerable<Product> products = await context.Products.Include(x => x.ProductSkus).ToListAsync();
            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductView>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            Product p = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (p != null)
            {
                return Ok(mapperSingle.Map<Product, ProductSingle>(p));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
