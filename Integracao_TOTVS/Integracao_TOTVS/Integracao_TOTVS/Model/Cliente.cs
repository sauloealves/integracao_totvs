using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Integracao_TOTVS.Model
{
    public class Cliente : ICliente
    {
        private string urlBase = string.Empty;
        private string userAuth = string.Empty;

        public string BAIRRO { get; set; }
        public string CEP { get; set; }
        public string CODIGO_MUNICIPIO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string DDD { get; set; }
        public string EMAIL { get; set; }
        public string ENDERECO { get; set; }
        public string ESTADO { get; set; }
        public string INSCRICAO_ESTADUAL { get; set; }
        public string MUNICIPIO { get; set; }
        public string NATUREZA { get; set; }
        public string NOME_CLIENTE { get; set; }
        public string NOME_FANTASIA { get; set; }
        public string TELEFONE { get; set; }
        public string TIPO_CLIENTE { get; set; }


        public Cliente() { }
        public Cliente(String _urlBase, string _userAuth) 
        {
            urlBase = _urlBase;
            userAuth = _userAuth;
        }

        public Cliente GetCliente(string cpfCnpj)
        {
            Cliente cliente = new Cliente();

            string comando = "/ConsultaCliente";

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, urlBase + comando);
            
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("userAuth", userAuth);
            client.DefaultRequestHeaders.Add("cnpjCliente", cpfCnpj);

            HttpResponseMessage responseMessage = client.SendAsync(requestMessage).Result;

            if (responseMessage.IsSuccessStatusCode)
            {

                var resultado = responseMessage.Content.ReadAsStringAsync().Result;
                dynamic jsonconvert = JsonConvert.DeserializeObject(resultado);

                cliente = JsonConvert.DeserializeObject<Cliente>(JsonConvert.SerializeObject(jsonconvert["DADOSCLIENTE"][0]));
                return cliente;
            }
            else
            {
                return null;
            }
        }
    }
}


