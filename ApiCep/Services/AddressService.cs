using System.IO;
using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiCep.Service
{
    public class AddressService
    {
        public AddressService()
        {
         
        }
        // A classe Task representa uma operação assíncrona.
        public async Task<string> Main(string cep)
        {
            // A HttpClient Fornece uma classe para enviar solicitações HTTP e receber respostas HTTP de um recurso identificado por uma URI.
            using (HttpClient client = new HttpClient())
            {
                // A Classe HttpResponseMensage representa uma mensagem de resposta HTTP incluindo o código de status e os dados.
                // O GetAsync envia uma solicitação GET para o URI especificado como uma operação assíncrona.
                HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");

                // O EnsureSuccessStatusCode gera uma exceção se a propriedade IsSuccessStatusCode da resposta HTTP for false
                response.EnsureSuccessStatusCode();

                // O ReadAsStringAsync serializa o conteúdo HTTP em uma cadeia de caracteres como uma operação assíncrona.
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
