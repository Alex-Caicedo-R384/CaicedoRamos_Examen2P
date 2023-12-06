using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace CaicedoRamos_Examen2P.Models
{
    internal class AC_AllNotes
    {
        public ObservableCollection<AC_Nota> Notes { get; set; } = new ObservableCollection<AC_Nota>();

        public AC_AllNotes() =>
            LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<AC_Nota> notes = Directory
                .EnumerateFiles(appDataPath, "*.notes.txt")
                .Select(filename => new AC_Nota()
                {
                    Filename = filename,
                    Date = File.GetCreationTime(filename),
                    Title = ReadTitleFromFile(filename),
                    Text = ReadContentFromFile(filename),
                })
                .OrderBy(note => note.Date);

            // Add each note into the ObservableCollection
            foreach (AC_Nota note in notes)
                Notes.Add(note);
        }

        private string ReadTitleFromFile(string filename)
        {
            string[] lines = File.ReadLines(filename).ToArray();
            return lines.Length > 0 ? lines[0] : "Sin título";
        }

        private string ReadContentFromFile(string filename)
        {
            IEnumerable<string> lines = File.ReadLines(filename).Skip(1);
            return string.Join("\n", lines);
        }
    }
}
