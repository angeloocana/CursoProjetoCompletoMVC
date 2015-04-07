using System;
using System.Globalization;
using System.Linq;

namespace TutorialEcommerce.Helpers
{
    public class TextoHelper
    {
        public static string RemoverAcentos(string texto)
        {
            if (texto == null) return string.Empty;

            const string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            const string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (var i = 0; i < comAcentos.Length; i++)
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());

            return texto;
        }

        public static string FormatarTextoParaUrl(string texto)
        {
            texto = RemoverAcentos(texto);

            var textoretorno = texto.Replace(" ", "");

            const string permitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmonopqrstuvwxyz0123456789-_";

            for (var i = 0; i < texto.Length; i++)
                if (!permitidos.Contains(texto.Substring(i, 1))) { textoretorno = textoretorno.Replace(texto.Substring(i, 1), ""); }

            return textoretorno;
        }

        public static string GetNumeros(string texto)
        {
            return string.IsNullOrEmpty(texto) ? "" : new String(texto.Where(Char.IsDigit).ToArray());
        }

        public static string AjustarTexto(string valor, int tamanho)
        {
            if (valor.Length > tamanho)
            {
                valor = valor.Substring(1, tamanho);
            }
            return valor;
        }

        /// <summary>
        /// deixa as primeiras letras maiusculas
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string ToTitleCase(string texto)
        {
            return ToTitleCase(texto, false);
        }

        public static string ToTitleCase(string texto, bool manterOqueJaEstiverMaiusculo)
        {
            texto = texto.Trim();

            if (!manterOqueJaEstiverMaiusculo)
                texto = texto.ToLower();

            TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;
            return textInfo.ToTitleCase(texto);
        }
    }
}