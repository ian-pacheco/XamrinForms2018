using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        //Método para buscar com o parametro cep
        public static Endereco BuscarEnderecoViaCEP (string cep) {

            //Constrói a URL
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            //Instancia webclient com metodo síncrono (trava a tela enquanto carrega)
            WebClient oWebClient = new WebClient();
            string Conteudo = oWebClient.DownloadString(NovoEnderecoURL);

            //Converte o conteúdo para uma string (nuget Newtonsoft)
            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (endereco.Cep == null) return null;

            return endereco;
        }
    }
}
