using HandSmartSlim.Models;
using HandSmartSlim.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandSmartSlim.Services
{
    class CompraService
    {
        // Função responsável por encaminhar as rotas e os parâmetros para a ApiService
        public string EnviaRequisicao(string caminho, string post)
        {
            ApiService apiserv = new ApiService();
            return apiserv.FazRequisicaoPOST("https://slimws.tk/mobile/" + caminho, post);
        }

        // Função responsável por buscar o Produto
        public RespostaApi InsereProdutoVenda(string codProduto)
        {
            // Envia a requisição para realizaLogin
            var json = EnviaRequisicao("/insereProdutoVenda",
                "codProduto="   + codProduto +
                "&idCliente= "  + ClienteLogado.id +
                "&cpfCliente= " + ClienteLogado.cpf
            );

            // Formata o Json
            RespostaApi result = JsonConvert.DeserializeObject<RespostaApi>(json);

            return result;
        }

    }
}
