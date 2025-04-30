using System.Text.RegularExpressions;

namespace CapaNegocio
{
    public static class ValidacionService
    {
        // Verifica si un string está vacío o es solo espacios
        public static bool EstaVacio(string valor)
        {
            return string.IsNullOrWhiteSpace(valor);
        }

        // Verifica si un string es un número entero válido
        public static bool EsEnteroValido(string valor)
        {
            return int.TryParse(valor, out _);
        }

        // Verifica si se seleccionó una opción válida en un ComboBox
        public static bool SeleccionValida(string valor)
        {
            return !string.IsNullOrEmpty(valor) && valor != "Seleccione...";
        }

        // Opcional: Verifica si un campo solo contiene letras (para nombre, por ejemplo)
        public static bool ContieneSoloLetras(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
        }

        // Opcional: Valida que un número sea mayor o igual a cero
        public static bool EsMayorOIgualACero(string valor)
        {
            return int.TryParse(valor, out int numero) && numero >= 0;
        }
    }
}
