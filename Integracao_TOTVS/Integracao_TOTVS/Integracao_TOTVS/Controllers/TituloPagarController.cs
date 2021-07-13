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
    public class TituloPagarController : ControllerBase
    {
        readonly string urlBase = "http://bluesol104033.protheus.cloudtotvs.com.br:4050/rest";
        string username = "next";
        string password = "bjN4dGIxdXMwMQ==";
        readonly string userAuth = "bmV4dDpuM3h0YjF1czAx";

        // GET: api/<TituloPagarController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TituloPagarController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TituloPagarController>
        [HttpPost]
        public RetornoInclusao Post([FromBody] Inclui_Pagar pagar)
        {
            //return new TituloPagar(urlBase, userAuth).Incluir(pagar);
            List<ItensVenda> itens = new List<ItensVenda>();
            List<EstruturaProduto> estruturaProduto = new List<EstruturaProduto>();

            estruturaProduto.Add(new EstruturaProduto() { Cod_Componente = "102.997.001.001", Qte_Componente = 1 });
            estruturaProduto.Add(new EstruturaProduto() { Cod_Componente = "107.021.004.037", Qte_Componente = 1 });
            estruturaProduto.Add(new EstruturaProduto() { Cod_Componente = "109.007.040.021", Qte_Componente = 1 });

            itens.Add(new ItensVenda() { Cod_Produto = "600.993.001.001", Quantidade = 1, Preco_Unitario = 15000, EstruturaProduto = estruturaProduto });

            Venda nova_venda = new Venda()
            {
                Cnpj_cliente = "07214832674",
                Tipo_cliente = "f",
                Nome_cliente = "bruno vieira ferreira",
                Nome_fantasia = "bruno ferreira",
                Endereco = "rua itanhandu, 25",
                Complemento = "alphaville",
                Bairro = "s.pedro",
                Municipio = "juiz de fora",
                Estado = "mg",
                Codigo_municipio = "36702",
                Cep = "36037873",
                Inscricao_estadual = "isento",
                Ddd = "32",
                Telefone = "984015684",
                Email = "bruno.ferreira@engenharia.ufjf.br",
                Natureza = "301001",
                Filial_venda = "0101",
                Id_venda = "nxt0002",
                Cond_pagto = "04",
                Descr_pagto = "50% entrada, restante 5x",
                Itens = itens
                
            };
            //return new TituloPagar(urlBase, userAuth).Incluir(pagar);
            new Venda(urlBase, userAuth).NovaVenda(nova_venda);
            return null;
        }

        // PUT api/<TituloPagarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TituloPagarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
