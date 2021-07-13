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
    public class TituloPagar
    {
        private string urlBase;
        private string userAuth;

        public TituloPagar() { }

        public TituloPagar(string _urlBase, string _userAuth)
        {
            urlBase = _urlBase;
            userAuth = _userAuth;
        }

        public RetornoInclusao Incluir(Fornecedor cliente, TituloPagar titulo)
        {
            throw new NotImplementedException();
        }

        public RetornoInclusao Incluir(Inclui_Pagar dados)
        {
            RetornoInclusao retorno = new RetornoInclusao();

            string comando = "/IncluiPagar";

            var client = new HttpClient();

            List<Inclui_Pagar> incluiPagar = new List<Inclui_Pagar>();

            incluiPagar.Add(dados);

            Principal principal = new Principal() { Inclui_Pagar = incluiPagar };

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

    internal class Principal
    {
        public List<Inclui_Pagar> Inclui_Pagar { get; set; }
    }

    public class Inclui_Pagar
    {
        public string Cnpj_fornecedor { get; set; }
        public string Tipo_fornecedor { get; set; }
        public string Nome_fornecedor { get; set; }
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
        public string Banco_fornec { get; set; }
        public string Agencia_fornec { get; set; }
        public string Dv_agencia_fornec { get; set; }
        public string Numero_conta_fornec { get; set; }
        public string Dv_conta_fornec { get; set; }
        public string Tipo_conta_fornec { get; set; }
        public string Filial_titulo { get; set; }
        public string Prefixo_titulo { get; set; }
        public string Numero_titulo { get; set; }
        public string Parcela_titulo { get; set; }
        public string Tipo_titulo { get; set; }
        public string Data_emissao { get; set; }
        public string Data_vencimento { get; set; }
        public decimal Valor_titulo { get; set; }
        public string Historico { get; set; }
        public string Numero_projeto { get; set; }
        public string Centro_custo { get; set; }
        public string Banco_titulo { get; set; }
        public string Agencia_titulo { get; set; }
        public string Dv_agencia_titulo { get; set; }
        public string Numero_conta_titulo { get; set; }
        public string Dv_conta_titulo { get; set; }

    }
}
