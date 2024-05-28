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
        public async Task<IActionResult> GetAllCurrencies()
        {
            //var result = await appDbContext1.Currencies.ToListAsync();
            //var result = this.appDbContext1.Currencies.ToList();
            var result = await (from currencies in appDbContext1.Currencies 
                                select new 
                                {
                                    CurrencyId = currencies.Id,
                                    Name = currencies.Title,
                                }
                                ).ToListAsync();
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

        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> GetAllCurrencyByIDAsync([FromRoute] int id)
        //{
        //    var result = await appDbContext1.Currencies.FindAsync(id);
        //    return Ok(result);
        //}

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAllCurrencyByNameAsync([FromRoute] string name, [FromQuery] string? description)
        {
            //var result = await appDbContext1.Currencies.
            //    FirstOrDefaultAsync(x=> x.Title == name 
            //    && (string.IsNullOrEmpty(description) || x.Description == description)
            //    );
            //var result = this.appDbContext1.Currencies.ToList();
            //var result = await (from currencies in appDbContext1.Currencies select currencies).ToListAsync();
            //var result = await appDbContext1.Currencies.
            //    Where(x => x.Title == name
            //    && (string.IsNullOrEmpty(description) || x.Description == description)
            //    ).ToListAsync();
            var result = await appDbContext1.Currencies.
                Where(x => x.Title == name
                && (string.IsNullOrEmpty(description) || x.Description == description)
                ).ToListAsync();
            return Ok(result);
        }

        //[HttpGet("all")]
        //public async Task<IActionResult> GetCurrencyByIDsAsync()
        //{
        //    var ids = new List<int>{1,6,3,4 };
        //    var result = await appDbContext1.Currencies.
        //    Where(x => ids.Contains(x.Id)).ToListAsync();
        //    return Ok(result);
        //}

        //[HttpPost("all")]
        //public async Task<IActionResult> GetCurrencyByIDsAsync([FromBody] List<int> ids)
        //{
        //    //var ids = new List<int> { 1, 6, 3, 4 };
        //    var result = await appDbContext1.Currencies.
        //    Where(x => ids.Contains(x.Id)).ToListAsync();
        //    return Ok(result);
        //}

        [HttpPost("")]
        public async Task<IActionResult> GetAllCurrency([FromBody] List<int> ids)
        {
            //var ids = new List<int> { 1, 6, 3, 4 };
            var result = await (from currencies in appDbContext1.Currencies select  currencies).ToListAsync();
            return Ok(result);
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetCurrenciesByIDsAsync([FromBody] List<int> ids)
        {
            var result = await appDbContext1.Currencies.
            Where(x => ids.Contains(x.Id)).
            Select(x => new Currency()
            {
                Id = x.Id, Title = x.Title,
            }
            ).ToListAsync();
            return Ok(result);
        }
    }
}
