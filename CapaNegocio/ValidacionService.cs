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

        // Valida formato de RUT chileno (XX.XXX.XXX-X o sin puntos)
        public static bool EsFormatoRutValido(string rut)
        {
            if (string.IsNullOrWhiteSpace(rut)) return false;
            return Regex.IsMatch(rut.Trim(), @"^\d{1,2}\.\d{3}\.\d{3}-[\dkK]$");
        }

        // Valida el dígito verificador del RUT con algoritmo módulo 11
        public static bool EsRutValido(string rut)
        {
            if (!EsFormatoRutValido(rut)) return false;

            rut = rut.Trim();

            // Separar cuerpo y dígito verificador
            string[] partes = rut.Split('-');
            if (partes.Length != 2) return false;

            string cuerpo = partes[0].Replace(".", "");
            string digitoIngresado = partes[1].ToUpper();

            // Calcular dígito verificador con módulo 11
            int suma = 0;
            int multiplicador = 2;

            for (int i = cuerpo.Length - 1; i >= 0; i--)
            {
                suma += int.Parse(cuerpo[i].ToString()) * multiplicador;
                multiplicador++;
                if (multiplicador > 7) multiplicador = 2;
            }

            int resto = suma % 11;
            int resultado = 11 - resto;

            string digitoCalculado;
            if (resultado == 11)
                digitoCalculado = "0";
            else if (resultado == 10)
                digitoCalculado = "K";
            else
                digitoCalculado = resultado.ToString();

            return digitoIngresado == digitoCalculado;
        }
    }
}
