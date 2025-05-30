using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos;

namespace CapaNegocio
{
    public static class EmpleadoService
    {
        // Precarga de empleados simulados (para pruebas)
        public static void PrecargarEmpleados()
        {
            RepositorioEmpleados.PrecargarEmpleados();
        }

        // Devuelve una lista de DTOs para usar en la presentación (sin exponer CapaDatos)
        public static List<EmpleadoDTO> ObtenerTodos()
        {
            var empleados = RepositorioEmpleados.ObtenerTodos();

            return empleados.Select(e => new EmpleadoDTO
            {
                Rut = e.Rut,
                Nombre = e.Nombre,
                Direccion = e.Direccion,
                Telefono = e.Telefono,
                ValorHora = e.ValorHora,
                ValorHoraExtra = e.ValorHoraExtra
            }).ToList();
        }

        // 🔹 Obtener un DTO completo por RUT
        public static EmpleadoDTO ObtenerDTOporRut(string rut)
        {
            var emp = RepositorioEmpleados.BuscarPorRut(rut);
            if (emp == null) return null;

            return new EmpleadoDTO
            {
                Rut = emp.Rut,
                Nombre = emp.Nombre,
                Direccion = emp.Direccion,
                Telefono = emp.Telefono,
                ValorHora = emp.ValorHora,
                ValorHoraExtra = emp.ValorHoraExtra
            };
        }

        // Registro a partir de campos simples
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

        // Registro con objeto Empleado (validación incluida)
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

        // Buscar empleado por RUT (uso interno)
        public static Empleado BuscarPorRut(string rut)
        {
            return RepositorioEmpleados.BuscarPorRut(rut);
        }

        // Modificar empleado usando objeto Empleado (uso interno/test)
        public static bool ModificarEmpleado(Empleado empleado)
        {
            return RepositorioEmpleados.ModificarEmpleado(empleado);
        }

        // 🔹 Método para modificar desde capa presentación (campos simples)
        public static bool ModificarEmpleadoDesdeCampos(string rut, string nombre, string direccion, string telefono, int valorHora, int valorHoraExtra)
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

            return RepositorioEmpleados.ModificarEmpleado(empleado);
        }

        // Eliminar empleado por RUT
        public static bool EliminarEmpleado(string rut)
        {
            return RepositorioEmpleados.EliminarEmpleado(rut);
        }
    }
}
