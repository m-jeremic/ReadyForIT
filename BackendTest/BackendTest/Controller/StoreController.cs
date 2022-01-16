using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTest.Models;
using Microsoft.EntityFrameworkCore;
using BackendTest.ViewModels;

namespace BackendTest.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private DataContext context;

        public StoreController(DataContext db)
        {
            context = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            return Ok(await context.Stores.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore(StoreBindingTarget target)
        {
            Store str = target.ToStore();
            await context.Stores.AddAsync(str);
            await context.SaveChangesAsync();
            return Ok(str);
        }
            
        

        [HttpPut]
        public async Task<IActionResult> UpdateStore(Store store)
        {
            Store str = await context.Stores.Where(x => x.Id == store.Id).FirstOrDefaultAsync();
            if (str != null)
            {
                str.Name = store.Name;
                str.Addrese = store.Addrese;
                context.Stores.Update(str);
                await context.SaveChangesAsync();
                return Ok(str);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
