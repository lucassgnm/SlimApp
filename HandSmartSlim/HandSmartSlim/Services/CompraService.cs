using HandSmartSlim.Models;
using HandSmartSlim.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public dynamic InsereProdutoVenda(string codProduto)
        {
            // Envia a requisição para realizaLogin
            var json = EnviaRequisicao("/insereProdutoVenda",
                "codProduto=" + codProduto +
                "&idCliente= " + ClienteLogado.id +
                "&cpfCliente= " + ClienteLogado.cpf
            );

            dynamic venda = null;
            bool erro = false;

            // Converte para a lista
            try
            {
                venda = JsonConvert.DeserializeObject<List<CompraModel>>(json);

            } catch (Exception ex)
            {
                erro = true;
            }

            if (erro)
            {
                // Formata o Json
                venda = JsonConvert.DeserializeObject<RespostaApi>(json);
            }
            
            
            // Retorna a requisição
            return venda;
        }

        public List<CompraModel> BuscaVendaAberta()
        {
            // Envia a requisição para realizaLogin
            var json = EnviaRequisicao("/buscaVendaAbertaCliente",
                "idCliente=" + ClienteLogado.id
            );

            // Converte para a lista
            var venda = JsonConvert.DeserializeObject<List<CompraModel>>(json);

            // Retorna a requisição
            return venda;
        }

    }
}
