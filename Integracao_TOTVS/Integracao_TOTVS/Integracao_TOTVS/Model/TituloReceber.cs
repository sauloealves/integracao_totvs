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

        public RetornoInclusao Incluir(INCLUI_RECEBER dados)
        {
            RetornoInclusao retorno = new RetornoInclusao();

            string comando = "/IncluiReceber";

            //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, urlBase + comando);

            var client = new HttpClient();

            List<INCLUI_RECEBER> incluireceber = new List<INCLUI_RECEBER>();

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
    }

    public class Teste
    {
        public  List<INCLUI_RECEBER> INCLUI_RECEBER { get; set; }
    }

    public class INCLUI_RECEBER
    {
        public string CNPJ_CLIENTE { get; set; }
        public string TIPO_CLIENTE { get; set; }
        public string NOME_CLIENTE { get; set; }
        public string NOME_FANTASIA { get; set; }
        public string ENDERECO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string BAIRRO { get; set; }
        public string MUNICIPIO { get; set; }
        public string ESTADO { get; set; }
        public string CODIGO_MUNICIPIO { get; set; }
        public string CEP { get; set; }
        public string INSCRICAO_ESTADUAL { get; set; }
        public string DDD { get; set; }
        public string TELEFONE { get; set; }
        public string EMAIL { get; set; }
        public string NATUREZA { get; set; }
        public string FILIAL_TITULO { get; set; }
        public string PREFIXO_TITULO { get; set; }
        public string NUMERO_TITULO { get; set; }
        public string PARCELA_TITULO { get; set; }
        public string TIPO_TITULO { get; set; }
        public string FORMA_PAGAMENTO { get; set; }
        public string DATA_EMISSAO { get; set; }
        public string DATA_VENCIMENTO { get; set; }
        public Decimal VALOR_TITULO { get; set; }
        public string HISTORICO { get; set; }
        public string NUMERO_PROJETO { get; set; }
        public string CENTRO_CUSTO { get; set; }

    }

}

