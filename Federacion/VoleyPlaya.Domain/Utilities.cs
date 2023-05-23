using System.Text.RegularExpressions;

namespace VoleyPlaya.Domain
{
    public static class Utilities
    {
        public static string ObtenerDigitosContinuos(string cadena)
        {
            string patron = @"\d+"; // Expresión regular para buscar dígitos continuos
            MatchCollection coincidencias = Regex.Matches(cadena, patron);

            string digitos = "";
            foreach (Match coincidencia in coincidencias)
            {
                digitos += coincidencia.Value;
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
