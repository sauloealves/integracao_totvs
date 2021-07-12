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
    public class ClienteController : ControllerBase
    {
        string urlBase = "http://bluesol104033.protheus.cloudtotvs.com.br:4050/rest";
        string username = "next";
        string password = "bjN4dGIxdXMwMQ==";
        string userAuth = "bmV4dDpuM3h0YjF1czAx";
        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //var cliente = new Cliente().GetCliente("29437740810");
            new User(urlBase).getUserAuth(username, password);            

            return new string[] { "value1", "value2" };
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public Cliente Get(string id)
        {
            var cliente = new Cliente(urlBase, userAuth).GetCliente(id);
            return cliente;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
