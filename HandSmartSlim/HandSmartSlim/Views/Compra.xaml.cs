using HandSmartSlim.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace HandSmartSlim.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Compra : ContentPage
    {
        CompraService compraService;
        public Compra()
        {
            InitializeComponent();

            compraService = new CompraService();
        }

        private void OpenScanner(object sender, EventArgs e)
        {
            // Chama a função de do Scanner
            Scanner();
        }

        // Função responsável por escanear o produto
        public async void Scanner()
        {
            var ScannerPage = new ZXingScannerPage();

            ScannerPage.OnScanResult += (result) => {
                // Parar de escanear
                ScannerPage.IsScanning = false;

                // Alert com o código escaneado
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();

                    var respostaProduto = compraService.InsereProdutoVenda(result.Text);

                    if (respostaProduto.Tipo == "ok")
                    {
                        DisplayAlert("Tudo Certo!", "O produto existe", "Cancelar");
                    } else
                    {
                        DisplayAlert("Ops...", "O produto não existe", "Cancelar");
                    }
                    
                });
            };

            await Navigation.PushAsync(ScannerPage);
        }
    }
}