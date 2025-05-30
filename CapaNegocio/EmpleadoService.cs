using System;
using CapaDatos;

namespace CapaNegocio
{
    public static class EmpleadoService
    {
        // Método llamado desde LoginForm para precargar datos simulados
        public static void PrecargarEmpleados()
        {
            RepositorioEmpleados.PrecargarEmpleados();
        }

        // Este método se llama desde la capa de presentación
        public static void RegistrarEmpleado(string rut, string nombre, string direccion, string telefono, int valorHora, int valorHoraExtra)
        {
            var empleado = new Empleado
            {
                Rut = rut,
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                ValorHora = valorHora,
                ValorHoraExtra = valorHoraExtra
            };

            // Llamada al método validado interno
            RegistrarEmpleado(empleado);
        }

        // Esta sobrecarga es la lógica central de validación y guardado
        public static void RegistrarEmpleado(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException("El objeto Empleado no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(empleado.Rut) ||
                string.IsNullOrWhiteSpace(empleado.Nombre) ||
                string.IsNullOrWhiteSpace(empleado.Direccion) ||
                string.IsNullOrWhiteSpace(empleado.Telefono))
            {
                throw new ArgumentException("Todos los campos del empleado deben estar completos.");
            }

            if (empleado.ValorHora <= 0 || empleado.ValorHoraExtra <= 0)
            {
                throw new ArgumentException("Los valores numéricos deben ser mayores a cero.");
            }

            // Finalmente, guardamos en la capa de datos
            RepositorioEmpleados.AgregarEmpleado(empleado);
        }
    }
}
