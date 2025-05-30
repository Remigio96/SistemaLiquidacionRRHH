using System;
using System.Collections.Generic;
using System.Linq;
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

        // Método expuesto a CapaPresentacion → solo devuelve EmpleadoDTO (no Empleado real)
        public static List<EmpleadoDTO> ObtenerTodos()
        {
            var empleados = RepositorioEmpleados.ObtenerTodos();

            return empleados.Select(e => new EmpleadoDTO
            {
                Rut = e.Rut,
                Nombre = e.Nombre,
                Direccion = e.Direccion
            }).ToList();
        }

        // Método que recibe datos simples desde el formulario
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

            RegistrarEmpleado(empleado);
        }

        // Validación y guardado de objeto Empleado
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

            RepositorioEmpleados.AgregarEmpleado(empleado);
        }
    }
}
