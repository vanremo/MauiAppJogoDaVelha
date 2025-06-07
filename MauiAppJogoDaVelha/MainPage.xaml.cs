using System;
using Microsoft.Maui.Controls;

namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string jogadorAtual = "X";

        public MainPage()
        {
            InitializeComponent();
        }

        private void DestacarVencedor(params Button[] botoes)
        {
            foreach (var btn in botoes)
            {
                btn.BackgroundColor = Colors.Green;
                btn.TextColor = Colors.White;
                btn.FontAttributes = FontAttributes.Bold;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            if (string.IsNullOrEmpty(botao.Text))
            {
                botao.Text = jogadorAtual;

                if (VerificarVitoria())
                {
                    DisplayAlert("Vitória", $"Parabéns! {jogadorAtual} venceu!", "OK");
                    DesabilitarBotoes();
                    return;
                }

                jogadorAtual = (jogadorAtual == "X") ? "O" : "X";
            }
        }

        private void ReiniciarJogo_Clicked(object sender, EventArgs e)
        {
            var botoes = new[] { btn10, btn11, btn12, btn20, btn21, btn22, btn30, btn31, btn32 };

            foreach (var btn in botoes)
            {
                btn.Text = string.Empty;
                btn.IsEnabled = true;
                btn.BackgroundColor = Colors.Black;  // Botões voltam a preto
                btn.TextColor = Colors.White;
                btn.FontAttributes = FontAttributes.None;
            }

            jogadorAtual = "X";
        }

        private void DesabilitarBotoes()
        {
            var botoes = new[] { btn10, btn11, btn12, btn20, btn21, btn22, btn30, btn31, btn32 };

            foreach (var btn in botoes)
            {
                btn.IsEnabled = false;
            }
        }

        private bool VerificarVitoria()
        {
            // Verifica linhas
            if (!string.IsNullOrEmpty(btn10.Text) && btn10.Text == btn11.Text && btn11.Text == btn12.Text)
            {
                DestacarVencedor(btn10, btn11, btn12);
                return true;
            }

            if (!string.IsNullOrEmpty(btn20.Text) && btn20.Text == btn21.Text && btn21.Text == btn22.Text)
            {
                DestacarVencedor(btn20, btn21, btn22);
                return true;
            }

            if (!string.IsNullOrEmpty(btn30.Text) && btn30.Text == btn31.Text && btn31.Text == btn32.Text)
            {
                DestacarVencedor(btn30, btn31, btn32);
                return true;
            }

            // Verifica colunas
            if (!string.IsNullOrEmpty(btn10.Text) && btn10.Text == btn20.Text && btn20.Text == btn30.Text)
            {
                DestacarVencedor(btn10, btn20, btn30);
                return true;
            }

            if (!string.IsNullOrEmpty(btn11.Text) && btn11.Text == btn21.Text && btn21.Text == btn31.Text)
            {
                DestacarVencedor(btn11, btn21, btn31);
                return true;
            }

            if (!string.IsNullOrEmpty(btn12.Text) && btn12.Text == btn22.Text && btn22.Text == btn32.Text)
            {
                DestacarVencedor(btn12, btn22, btn32);
                return true;
            }

            // Verifica diagonais
            if (!string.IsNullOrEmpty(btn10.Text) && btn10.Text == btn21.Text && btn21.Text == btn32.Text)
            {
                DestacarVencedor(btn10, btn21, btn32);
                return true;
            }

            if (!string.IsNullOrEmpty(btn12.Text) && btn12.Text == btn21.Text && btn21.Text == btn30.Text)
            {
                DestacarVencedor(btn12, btn21, btn30);
                return true;
            }

            return false;
        }
    }
}
