using System.IO;
using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApiCep.Service
{
    public class AddressService
    {
        public AddressService()
        {
         
        }

        //Método para executar uma requisição web
        public string GetAddress(string cep)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + cep + "/json/");
            request.AllowAutoRedirect = false;
            HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();

            Stream web = ChecaServidor.GetResponseStream();

            if (web == null)
                return null;

            StreamReader responseReader = new StreamReader(web);

            //Caso a requisição obtenha uma resposta ela insere na string responseText
            string responseText = responseReader.ReadToEnd();
            
            return responseText;
        }
    }
}
