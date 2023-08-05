using FirmaDigital.Models;
using System;
using Xamarin.Forms;
using System.IO;

namespace FirmaDigital
{


    public partial class MainPage : ContentPage
    {
        SignatureDatabase database;

        public MainPage()
        {
            InitializeComponent();
            database = new SignatureDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "signatures.db3"));
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (signaturePad.IsBlank)
            {
                await DisplayAlert("Error", "Por favor, realice una firma", "OK");
                return;
            }

            var signature = new Signature
            {
                ImageData = signaturePad.GetImageStream().ReadFully(),
                Description = descripcionEntry.Text
            };

            await database.SaveSignatureAsync(signature);

            signaturePad.Clear();
            descriptionEntry.Text = string.Empty;

            await DisplayAlert("Éxito", "La firma ha sido guardada.", "OK");
        }

        private async void OnShowSignaturesButtonClicked(object sender, EventArgs e)
        {
            var signatures = await database.GetSignaturesAsync();
            await Navigation.PushAsync(new SignaturesPage(signatures));
        }
    }

}
}
