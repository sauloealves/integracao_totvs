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

        public RetornoInclusao Incluir(string dados)
        {
            RetornoInclusao retorno = new RetornoInclusao();

            string comando = "/IncluiReceber";

            //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, urlBase + comando);

            var client = new HttpClient();

            List<INCLUI_RECEBER> incluireceber = new List<INCLUI_RECEBER>();

            incluireceber.Add(new INCLUI_RECEBER
            {
                CNPJ_CLIENTE = "29437740810",
                TIPO_CLIENTE = "F",
                NOME_CLIENTE = "SAULO ALVES",
                NOME_FANTASIA = "SAULO ALVES",
                ENDERECO = "RUA ITANHANDU 25",
                COMPLEMENTO = "ALPHAVILLE",
                BAIRRO = "S.PEDRO",
                MUNICIPIO = "BELO HORIZONTE",
                ESTADO = "MG",
                CODIGO_MUNICIPIO = "06200",
                CEP = "36037873",
                INSCRICAO_ESTADUAL = "ISENTO",
                DDD = "32",
                TELEFONE = "984015684",
                EMAIL = "sauloealves@gmail.com",
                NATUREZA = "301001",
                FILIAL_TITULO = "0101",
                PREFIXO_TITULO = "VDA",
                NUMERO_TITULO = "902612",
                PARCELA_TITULO = "1",
                TIPO_TITULO = "BRA",
                FORMA_PAGAMENTO = "BOL",
                DATA_EMISSAO = "20210625",
                DATA_VENCIMENTO = "20210825",
                VALOR_TITULO = "8332.65",
                HISTORICO = "",
                NUMERO_PROJETO = "902119",
                CENTRO_CUSTO = "0102"
            });
            
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
        public string VALOR_TITULO { get; set; }
        public string HISTORICO { get; set; }
        public string NUMERO_PROJETO { get; set; }
        public string CENTRO_CUSTO { get; set; }

    }

}

