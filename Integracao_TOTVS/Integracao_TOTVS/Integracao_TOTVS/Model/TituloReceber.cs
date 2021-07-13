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
    public class TituloReceber : ITituloReceber
    {
        private string urlBase;
        private string userAuth;

        public TituloReceber() { }

        public TituloReceber(string _urlBase, string _userAuth)
        {
            urlBase = _urlBase;
            userAuth = _userAuth;
        }

        public RetornoInclusao Incluir(Cliente cliente, TituloReceber titulo)
        {
            throw new NotImplementedException();
        }

        public RetornoInclusao Incluir(Inclui_Receber dados)
        {
            RetornoInclusao retorno = new RetornoInclusao();

            string comando = "/IncluiReceber";

            var client = new HttpClient();

            List<Inclui_Receber> incluireceber = new List<Inclui_Receber>();

            incluireceber.Add(dados);
            
            Teste teste = new Teste() { INCLUI_RECEBER = incluireceber };

            var incluir = JsonConvert.SerializeObject(teste);

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

        private class Teste
        {
            public List<Inclui_Receber> INCLUI_RECEBER { get; set; }
        }
    }

    
}

