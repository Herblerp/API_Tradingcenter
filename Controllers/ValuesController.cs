using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Tradingcenter.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Tradingcenter.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DatabaseContext context;

        public ValuesController(DatabaseContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = context.Values.ToList();
            
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = context.Values.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
