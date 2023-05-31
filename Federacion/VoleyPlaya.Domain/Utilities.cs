using System.Text.RegularExpressions;

namespace VoleyPlaya.Domain
{
    public static class Utilities
    {
        public static string ObtenerDigitosContinuos(string cadena)
        {
            string patron = @"\d+"; // Expresión regular para buscar dígitos continuos hasta encontrar una letra
            Match match = Regex.Match(cadena, patron);

            if (match.Success)
            {
                return match.Value;
            }
            return string.Empty;
        }
        public static bool EsMejorPuesto(string cadena)
        {
            string patron = @"\dM\d";

            return Regex.IsMatch(cadena, patron);
        }
        public static string ObtenerDigitosAlFinal(string cadena)
        {
            string digitos = null;
            int i = cadena.Length - 1;

            while (i >= 0 && char.IsDigit(cadena[i]))
            {
                digitos = cadena[i] + digitos;
                i--;
            }

            return digitos;
        }
        public static string ObtenerLetras(string cadena)
        {
            string patron = "[a-zA-Z]"; // Expresión regular para buscar letras
            MatchCollection coincidencias = Regex.Matches(cadena, patron);

            string letras = "";
            foreach (Match coincidencia in coincidencias)
            {
                letras += coincidencia.Value;
            }

            return letras;
        }
    }
}
