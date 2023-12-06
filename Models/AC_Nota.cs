using System;
using Microsoft.Maui.Graphics;

namespace CaicedoRamos_Examen2P.Models
{
    internal class AC_Nota
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string FormattedDate => Date.ToString("dd/MM/yyyy");

        public string Title { get; set; }

        public Color FrameBackgroundColor { get; private set; }
    }
}
