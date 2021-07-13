using Integracao_TOTVS.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Integracao_TOTVS.Model
{
    public class Venda : IVenda
    {

        private string urlBase;
        private string userAuth;

        #region [ Propriedades ]

        public string Cnpj_cliente { get; set; }
        public string Tipo_cliente { get; set; }
        public string Nome_cliente { get; set; }
        public string Nome_fantasia { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Codigo_municipio { get; set; }
        public string Cep { get; set; }
        public string Inscricao_estadual { get; set; }
        public string Ddd { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Natureza { get; set; }
        public string Filial_venda { get; set; }
        public string Id_venda { get; set; }
        public string Cond_pagto { get; set; }
        public string Descr_pagto { get; set; }
        public List<ItensVenda> Itens { get; set; }

        #endregion

        #region [ Construtores ]
        public Venda() { }
        public Venda(string _urlBase, string _userAuth)
        {
            urlBase = _urlBase;
            userAuth = _userAuth;
        }

        #endregion

        public RetornoInclusao NovaVenda(Cliente cliente, TituloReceber titulo)
        {
            throw new NotImplementedException();
        }

        public RetornoInclusao NovaVenda(Venda dados)
        {
            RetornoInclusao retorno = new RetornoInclusao();

            string comando = "/NovaVenda";

            var client = new HttpClient();

            List<Venda> nova_venda = new List<Venda>();

            nova_venda.Add(dados);

            PrincipalVenda principal = new PrincipalVenda() { Nova_Venda = nova_venda };

            var incluir = JsonConvert.SerializeObject(principal);

            Uri uri = new Uri(urlBase + comando);

            client.BaseAddress = uri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("userAuth", userAuth);

            var content = new StringContent(incluir, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PostAsync(uri, content).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                var resultado = responseMessage.Content.ReadAsStringAsync().Result;
                dynamic jsonconvert = JsonConvert.DeserializeObject(resultado);

                retorno = JsonConvert.DeserializeObject<RetornoInclusao>(JsonConvert.SerializeObject(jsonconvert["RETORNO_INCLUSAO"][0]));
                return retorno;
            }
            else
            {
                return null;
            }
        }
    }

    internal class PrincipalVenda
    {
        public List<Venda> Nova_Venda { get; set; }
    }

    public class ItensVenda
    {
        public string Cod_Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco_Unitario { get; set; }
        public List<EstruturaProduto> EstruturaProduto { get; set; }
    }

    public class EstruturaProduto
    {
        public string Cod_Componente { get; set; }
        public int Qte_Componente { get; set; }

    }
}

    
