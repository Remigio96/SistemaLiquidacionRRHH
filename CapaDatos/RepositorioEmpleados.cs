using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public static class RepositorioEmpleados
    {
        // Lista estática que simula la base de datos
        private static readonly List<Empleado> empleados = new List<Empleado>();

        // Agregar un nuevo empleado
        public static void AgregarEmpleado(Empleado empleado)
        {
            empleados.Add(empleado);
        }

        // Obtener todos los empleados
        public static List<Empleado> ObtenerTodos()
        {
            return empleados;
        }

        // Buscar un empleado por RUT
        public static Empleado BuscarPorRut(string rut)
        {
            return empleados.FirstOrDefault(e => e.Rut == rut);
        }

        // Eliminar empleado por RUT
        public static bool EliminarEmpleado(string rut)
        {
            var empleado = BuscarPorRut(rut);
            if (empleado != null)
            {
                empleados.Remove(empleado);
                return true;
            }
            return false;
        }

        // Modificar un empleado
        public static bool ModificarEmpleado(Empleado nuevoEmpleado)
        {
            var existente = BuscarPorRut(nuevoEmpleado.Rut);
            if (existente != null)
            {
                existente.Nombre = nuevoEmpleado.Nombre;
                existente.Direccion = nuevoEmpleado.Direccion;
                existente.Telefono = nuevoEmpleado.Telefono;
                existente.ValorHora = nuevoEmpleado.ValorHora;
                existente.ValorHoraExtra = nuevoEmpleado.ValorHoraExtra;
                return true;
            }
            return false;
        }

        // Precarga de empleados para pruebas
        public static void PrecargarEmpleados()
        {
            if (empleados.Count == 0) // Evita duplicación si ya fueron precargados
            {
                empleados.Add(new Empleado("19.595.224-4", "Ana Ríos", "Los Olmos 123", "+56912345678", 5000, 7000));
                empleados.Add(new Empleado("18.461.837-k", "Luis Soto", "Av. Providencia 456", "+56987654321", 5000, 7000));
            }
        }
    }
}
