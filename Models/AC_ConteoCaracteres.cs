namespace CaicedoRamos_Examen2P.Models
{
    public class AC_ConteoCaracteres
    {
        public int TotalCaracteres { get; set; }
        public int TotalNumeros { get; set; }
        public int TotalLetras { get; set; }
        public int TotalVocales { get; set; }
        public int TotalMayusculas { get; set; }
        public int TotalMinusculas { get; set; }
        public int TotalSignosEspeciales { get; set; }
        public int TotalEspacios { get; set; }

        public void Reset()
        {
            TotalCaracteres = 0;
            TotalNumeros = 0;
            TotalLetras = 0;
            TotalVocales = 0;
            TotalMayusculas = 0;
            TotalMinusculas = 0;
            TotalSignosEspeciales = 0;
            TotalEspacios = 0;
        }
    }
}
