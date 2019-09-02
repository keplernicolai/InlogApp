using InlogTeste.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InlogTeste.Utils
{
    public static class WebServiceBase<T>
    {
        public static async Task<T> RequestAsync(string URL, int idFilme)
        {
            T objetoRetorno;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (idFilme > 0)
                        URL = URL + string.Format("{0}?api_key=2e508b40194129537006b7a38aadd526&language=pt-BR", idFilme);
                    else
                        URL = URL + "?api_key=2e508b40194129537006b7a38aadd526&language=pt-BR&page=1&region=BR";

                    var response = await client.GetStringAsync(URL);

                    objetoRetorno = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);

                }

                return objetoRetorno;
            }

            catch (Newtonsoft.Json.JsonException jx)
            {
                throw jx;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}
