using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using Xamarin.Forms;

namespace App01_ConsultarCEP {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs args) {

            //VAlidações
            string cep = CEP.Text.Trim();

            if (IsValidCEP(cep)) {
                try {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null) {
                        RESULTADO.Text = string.Format("Endereço: {2} de {3} {0}, {1}", end.Localidade, end.Uf, end.Logradouro, end.Bairro);
                    } else {
                        DisplayAlert("Erro", "Endereço não encontrado para o CEP informado: " + cep, "OK");
                    }
                } catch (Exception e) {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }
        }

        private bool IsValidCEP(string cep) {

            bool Valido = true;

            if (cep.Length != 8) {
                DisplayAlert("Erro", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                Valido = false;
            }

            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP)) {

                DisplayAlert("Erro", "CEP inválido! o CEP deve ser composto apenas por números.", "OK");
                Valido = false;
            }

            return Valido;
        }
    }
}
