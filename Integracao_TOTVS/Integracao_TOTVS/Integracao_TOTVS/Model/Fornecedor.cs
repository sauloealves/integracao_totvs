using Integracao_TOTVS.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Integracao_TOTVS.Model
{
    public class Fornecedor : IFornecedor
    {
        public string AGENCIA { get; set; }
        public string BAIRRO { get; set; }
        public string BANCO { get; set; }
        public string CEP { get; set; }
        public string CODIGO_MUNICIPIO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string DDD { get; set; }
        public string DV_AGENCIA { get; set; }
        public string DV_CONTA { get; set; }
        public string EMAIL { get; set; }
        public string ENDERECO { get; set; }
        public string ESTADO { get; set; }
        public string INSCRICAO_ESTADUAL { get; set; }
        public string MUNICIPIO { get; set; }
        public string NATUREZA { get; set; }
        public string NOME_FANTASIA { get; set; }
        public string NOME_FORNECEDOR { get; set; }
        public string NUMERO_CONTA { get; set; }
        public string TELEFONE { get; set; }
        public string TIPO_CONTA { get; set; }
        public string TIPO_FORNECEDOR { get; set; }

        private string urlBase = string.Empty;
        private string userAuth = string.Empty;

        public Fornecedor(string _urlBase, string _userAuth)
        {
            urlBase = _urlBase;
            userAuth = _userAuth;
        }

        public Fornecedor(){}

        public Fornecedor GetFornecedor(string cpfCnpj)
        {
            Fornecedor fornecedor;
            
            string comando = "/ConsultaFornecedor";

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, urlBase + comando);

            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("userAuth", userAuth);
            client.DefaultRequestHeaders.Add("cnpjFornecedor", cpfCnpj);

            HttpResponseMessage responseMessage = client.SendAsync(requestMessage).Result;

            if (responseMessage.IsSuccessStatusCode)
            {

                var resultado = responseMessage.Content.ReadAsStringAsync().Result;
                dynamic jsonconvert = JsonConvert.DeserializeObject(resultado);

                fornecedor = JsonConvert.DeserializeObject<Fornecedor>(JsonConvert.SerializeObject(jsonconvert["DADOSFORNECEDOR"][0]));
                return fornecedor;
            }
            else
            {
                return null;
            }
        }
    }
}
