using System;

namespace CapaDatos
{
    public class Empleado
    {
        // Propiedades del empleado
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int ValorHora { get; set; }
        public int ValorHoraExtra { get; set; }

        // Constructor
        public Empleado(string rut, string nombre, string direccion, string telefono, int valorHora, int valorHoraExtra)
        {
            Rut = rut;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ValorHora = valorHora;
            ValorHoraExtra = valorHoraExtra;
        }

        // Constructor vacío por si se necesita con serialización o edición manual
        public Empleado() { }

        // Para mostrar fácilmente en listas o combos (opcional)
        public override string ToString()
        {
            return $"{Rut} - {Nombre}";
        }
    }
}
