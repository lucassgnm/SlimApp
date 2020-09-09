using HandSmartSlim.Models;
using HandSmartSlim.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandSmartSlim.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            // Remove o botão de retornar da página
            NavigationPage.SetHasBackButton(this, false);

            // Inicializa o array de imagens de propaganda
            var images = new List<string>
            {
                "propaganda1","propaganda2","propaganda3"
            };
            
            // Adicionas as imagens no slide
            CarousselPropagandas.ItemsSource = images;

            nomeUsuario.Text = ClienteLogado.nome;
        }

        // Verifica o click do botão voltar do Android
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            //new thread
            Device.BeginInvokeOnMainThread(async () => {
                // Exibe o alerta
                var result = await this.DisplayAlert("Atenção", "Deseja sair do aplicativo?", "Sim", "Não");
                // Verifia o resultado
                if (result)
                {
                    Preferences.Clear();
                    // Retorna para a pagina de Login
                    await Navigation.PushAsync(new Login());
                }
            });
            // Quebra a função
            return true;
        }

        private async void AbrePaginaCompra(object sender, EventArgs e)
        {
            // Chama a página de compra
            await Navigation.PushAsync(new Compra());
        }
    }
}