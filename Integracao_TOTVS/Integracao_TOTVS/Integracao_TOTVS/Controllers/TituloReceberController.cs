using Integracao_TOTVS.Model;
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
        string urlBase = "http://bluesol104033.protheus.cloudtotvs.com.br:4050/rest";
        string username = "next";
        string password = "bjN4dGIxdXMwMQ==";
        string userAuth = "bmV4dDpuM3h0YjF1czAx";

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
        public RetornoInclusao Post([FromBody] INCLUI_RECEBER receber)
        {
            return new TituloReceber(urlBase, userAuth).Incluir(receber);
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
