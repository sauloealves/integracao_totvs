using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Integracao_TOTVS.Model
{
    public class User : IUser
    {
        public string UserAuth { get; set; }
        string _urlbase = string.Empty;

        public User(String urlBase)
        {
            _urlbase = urlBase;
        }

        public User(){}

        public void getUserAuth(string username, string password)
        {
            string comando = "/Authorization";
            List<KeyValuePair<string, string>> lstParametros = new List<KeyValuePair<string, string>>();
            lstParametros.Add(new KeyValuePair<string, string>("USUARIO", username));
            lstParametros.Add(new KeyValuePair<string, string>("SENHA", password));

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://bluesol104033.protheus.cloudtotvs.com.br:4050/rest/ConsultaFornecedor");
            
            //requestMessage.Content = new FormUrlEncodedContent(lstParametros);

            
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("userAuth", "bmV4dDpuM3h0YjF1czAx");
            client.DefaultRequestHeaders.Add("cnpjFornecedor", "11167539000237");

            HttpResponseMessage responseMessage = client.SendAsync(requestMessage).Result;

        }
    }
}
