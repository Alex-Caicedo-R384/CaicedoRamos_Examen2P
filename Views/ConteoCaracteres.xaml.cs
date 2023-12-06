using CaicedoRamos_Examen2P.Models;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace CaicedoRamos_Examen2P.Views
{
    public partial class ConteoCaracteres : ContentPage
    {
        private AC_ConteoCaracteres conteoModel = new AC_ConteoCaracteres();

        public ConteoCaracteres()
        {
            InitializeComponent();
        }

        private void CountButton_Clicked(object sender, EventArgs e)
        {
            string inputText = InputEntry.Text;

            conteoModel.TotalCaracteres = inputText.Length;
            conteoModel.TotalNumeros = inputText.Count(char.IsDigit);
            conteoModel.TotalLetras = inputText.Count(char.IsLetter);
            conteoModel.TotalVocales = inputText.Count(c => "aeiouAEIOU".Contains(c));
            conteoModel.TotalMayusculas = inputText.Count(char.IsUpper);
            conteoModel.TotalMinusculas = inputText.Count(char.IsLower);
            conteoModel.TotalSignosEspeciales = inputText.Count(c => char.IsPunctuation(c));
            conteoModel.TotalEspacios = inputText.Count(char.IsWhiteSpace);

            MostrarResultados();
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            InputEntry.Text = string.Empty;
            ResultLabel.Text = string.Empty;

            conteoModel.Reset();
        }

        private void MostrarResultados()
        {
            string resultText = $"Total caracteres: {conteoModel.TotalCaracteres}\n" +
                                $"Total números: {conteoModel.TotalNumeros}\n" +
                                $"Total letras: {conteoModel.TotalLetras}\n" +
                                $"Total vocales: {conteoModel.TotalVocales}\n" +
                                $"Total mayúsculas: {conteoModel.TotalMayusculas}\n" +
                                $"Total minúsculas: {conteoModel.TotalMinusculas}\n" +
                                $"Total signos especiales: {conteoModel.TotalSignosEspeciales}\n" +
                                $"Total espacios: {conteoModel.TotalEspacios}";

            ResultLabel.Text = resultText;
        }
    }
}
