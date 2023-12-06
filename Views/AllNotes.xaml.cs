using System;
using Microsoft.Maui.Controls;

namespace CaicedoRamos_Examen2P.Views
{
    public partial class AllNotes : ContentPage
    {
        public AllNotes()
        {
            InitializeComponent();

            BindingContext = new Models.AC_AllNotes();
        }

        protected override void OnAppearing()
        {
            ((Models.AC_AllNotes)BindingContext).LoadNotes();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NotePage));
        }

        private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count != 0)
            {
                var note = (Models.AC_Nota)e.CurrentSelection[0];
                await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");
                notesCollection.SelectedItem = null;
            }
        }
    }
}
