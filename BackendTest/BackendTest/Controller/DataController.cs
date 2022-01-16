using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private DataContext context;

        public DataController(DataContext db)
        {
            context = db;
        }

        [HttpGet("{productSkuId}/{storeId}")]
        public async Task<IActionResult> GetSkus(int productSkuId, int storeId)
        {
            
            List<Stock> rez = await context.Stocks.Where(x => x.ProductSkuId == productSkuId && x.StoreId == storeId).ToListAsync();
            if (rez.Count > 0)
            {
                int quantity = rez.Select(x => x.Quantity).First();
                return Ok(quantity);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{storeId}")]
        public async Task<IActionResult> ProductsQuantities(int storeId)
        {
            List<DbResult> rez = await context.Quantities.FromSqlRaw("exec dbo.KolicinaProizvodapoRadnji @Id={0}", storeId).ToListAsync();
            if (rez.Count > 0)
            {
                return Ok(rez);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
