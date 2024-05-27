using EFOperations.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFOperations.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext appDbContext1;
        
        public CurrencyController(AppDbContext appDbContext1) 
        {
            this.appDbContext1 = appDbContext1;
        }

        [HttpGet("")]
        public async Task <IActionResult> GetAllCurrencies()
        {
            //var result = await appDbContext1.Currencies.ToListAsync();
            //var result = this.appDbContext1.Currencies.ToList();
            var result = await (from currencies in appDbContext1.Currencies select currencies).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllCurrencyByAsync([FromRoute] int id)
        {
            var result = await appDbContext1.Currencies.FindAsync(id);
            //var result = this.appDbContext1.Currencies.ToList();
            //var result = await (from currencies in appDbContext1.Currencies select currencies).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{name}/{description}")]
        public async Task<IActionResult> GetAllCurrencyByNameAsync([FromRoute] string name, [FromRoute] string description)
        {
            var result = await appDbContext1.Currencies.Where(x=> x.Title == name && x.Description == description).FirstAsync();
            //var result = this.appDbContext1.Currencies.ToList();
            //var result = await (from currencies in appDbContext1.Currencies select currencies).ToListAsync();
            return Ok(result);
        }
    }
}
