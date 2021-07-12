using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_TOTVS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TituloReceberController : ControllerBase
    {
        // GET: api/<IncluirReceberController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IncluirReceberController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IncluirReceberController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<IncluirReceberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IncluirReceberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
