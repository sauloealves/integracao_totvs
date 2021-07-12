using Integracao_TOTVS.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Integracao_TOTVS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        string urlBase = "http://bluesol104033.protheus.cloudtotvs.com.br:4050/rest";
        string userAuth = "bmV4dDpuM3h0YjF1czAx";

        // GET: api/<FornecedorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FornecedorController>/5
        [HttpGet("{id}")]
        public Fornecedor Get(string id)
        {
            //return new Fornecedor(urlBase, userAuth).GetFornecedor(id);
            new TituloReceber(urlBase, userAuth).Incluir("");
            return null;
        }

        // POST api/<FornecedorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FornecedorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FornecedorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
