using System;
using System.IO;
using System.Linq;
using Microsoft.Maui.Controls;

namespace CaicedoRamos_Examen2P.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NotePage : ContentPage
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
        bool isEditing = false;

        public NotePage()
        {
            InitializeComponent();
            LoadNote(Path.Combine(FileSystem.AppDataDirectory, $"{Path.GetRandomFileName()}.notes.txt"));
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Models.AC_Nota note)
            {
                File.WriteAllText(note.Filename, $"{note.Title}\n{TextEditor.Text}");
            }

            await Shell.Current.GoToAsync("..");
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Models.AC_Nota note && File.Exists(note.Filename))
                File.Delete(note.Filename);

            await Shell.Current.GoToAsync("..");
        }

        private void LoadNote(string fileName)
        {
            Models.AC_Nota noteModel = new Models.AC_Nota { Filename = fileName };

            if (File.Exists(fileName))
            {
                noteModel.Date = File.GetCreationTime(fileName);
                string[] lines = File.ReadAllLines(fileName);
                noteModel.Title = lines.FirstOrDefault();
                noteModel.Text = string.Join("\n", lines.Skip(1));
                isEditing = true; // Si el archivo existe, estamos editando
            }

            BindingContext = noteModel;

            // Actualiza el título de la página según estemos creando o editando
            Title = isEditing ? "Editar Nota" : "Crear Nota";
        }

        public string ItemId
        {
            set => LoadNote(value);
        }
    }
}
