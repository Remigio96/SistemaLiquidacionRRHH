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
                empleados.Add(new Empleado("19.595.224-4", "Ana Ríos", "Los Olmos 123, Macul", "+56912345678", 5000, 7000));
                empleados.Add(new Empleado("18.461.837-k", "Luis Soto", "Av. Providencia 456, Providencia", "+56987654321", 5000, 7000));
                empleados.Add(new Empleado("13.218.530-0", "Ignacio Paredes", "Av. Matta 123, Santiago", "+56947851236", 5000, 7000));
                empleados.Add(new Empleado("10.172.930-4", "Camila Rojas", "Calle Los Pinos 456, Puente Alto", "+56974125698", 5000, 7000));
                empleados.Add(new Empleado("12.820.418-1", "Tomás Herrera", "Av. España 234, Ñuñoa", "+56932548714", 5000, 7000));
                empleados.Add(new Empleado("14.588.806-6", "Cristina Leiva", "Pasaje Las Rosas 789, Maipú", "+56987412365", 5000, 7000));
                empleados.Add(new Empleado("14.596.138-8", "Luis González", "Av. Salvador 1100, Providencia", "+56996325874", 5000, 7000));
                empleados.Add(new Empleado("15.621.887-5", "María Díaz", "Calle Lo Ovalle 902, La Florida", "+56974125896", 5000, 7000));
                empleados.Add(new Empleado("16.473.291-3", "Sebastián Vega", "Camino La Viña 321, Peñalolén", "+56935789641", 5000, 7000));
                empleados.Add(new Empleado("13.552.974-2", "Valentina Fuentes", "Av. Macul 1203, Macul", "+56947581239", 5000, 7000));
                empleados.Add(new Empleado("11.203.498-0", "Javiera Álvarez", "Calle Los Robles 84, Recoleta", "+56998745123", 5000, 7000));
                empleados.Add(new Empleado("17.193.850-1", "Matías Salazar", "Pasaje Las Violetas 56, San Miguel", "+56912347854", 5000, 7000));
                empleados.Add(new Empleado("16.238.774-9", "Paula Zamora", "Av. La Dehesa 3421, Lo Barnechea", "+56931245789", 5000, 7000));
                empleados.Add(new Empleado("18.374.522-0", "Andrés Navarro", "Calle Principal 75, Huechuraba", "+56958472136", 5000, 7000));
                empleados.Add(new Empleado("19.521.368-7", "Francisca Toro", "Pasaje Quillay 99, La Reina", "+56974125632", 5000, 7000));
                empleados.Add(new Empleado("12.983.416-3", "Carlos Jara", "Av. Grecia 1111, Ñuñoa", "+56936521487", 5000, 7000));
                empleados.Add(new Empleado("15.234.567-8", "Daniela Flores", "Calle Diego Portales 100, Conchalí", "+56974236589", 5000, 7000));
                empleados.Add(new Empleado("14.874.300-2", "Felipe Morales", "Av. Perú 430, Independencia", "+56996321475", 5000, 7000));
                empleados.Add(new Empleado("17.236.890-1", "Josefa Martínez", "Camino Las Torres 222, Quilicura", "+56989632145", 5000, 7000));
                empleados.Add(new Empleado("13.100.875-6", "Raúl Contreras", "Pasaje Los Aromos 654, Renca", "+56998563214", 5000, 7000));
                empleados.Add(new Empleado("12.485.130-0", "Pía Santander", "Calle Las Parcelas 873, Pudahuel", "+56974321985", 5000, 7000));
                empleados.Add(new Empleado("19.583.720-4", "Vicente Núñez", "Av. Kennedy 1700, Vitacura", "+56945698712", 5000, 7000));
                empleados.Add(new Empleado("19.524.327-8", "Valeria Riquelme", "Av. Grecia 456, Ñuñoa", "+56922233444", 5000, 7000));
                empleados.Add(new Empleado("17.198.643-2", "Esteban Paredes", "Calle Amapolas 789, La Florida", "+56987654322", 5000, 7000));
                empleados.Add(new Empleado("20.159.876-3", "Javiera Muñoz", "Pasaje Limache 102, Maipú", "+56912347890", 5000, 7000));
                empleados.Add(new Empleado("16.489.753-6", "Felipe Araya", "Av. Matta 890, Santiago Centro", "+56923456789", 5000, 7000));
                empleados.Add(new Empleado("18.357.111-0", "Carolina Díaz", "Camino Melipilla 1150, Cerrillos", "+56933445566", 5000, 7000));
                empleados.Add(new Empleado("15.267.890-5", "Rodrigo Fuentes", "Calle Las Vertientes 22, Las Condes", "+56999887766", 5000, 7000));
                empleados.Add(new Empleado("19.765.123-1", "Francisca Pinto", "Pasaje Río Bueno 333, Puente Alto", "+56911223344", 5000, 7000));
                empleados.Add(new Empleado("17.654.987-6", "Nicolás Soto", "Av. Manuel Rodríguez 555, Independencia", "+56966554433", 5000, 7000));
                empleados.Add(new Empleado("20.778.666-4", "Daniela Rojas", "Calle Lincoyán 456, Quilicura", "+56932165498", 5000, 7000));
                empleados.Add(new Empleado("18.235.890-2", "Cristóbal Salinas", "Camino El Alba 777, Peñalolén", "+56945678901", 5000, 7000));
                empleados.Add(new Empleado("19.478.456-7", "María Jesús Leiva", "Pasaje Los Copihues 99, San Joaquín", "+56977889900", 5000, 7000));
                empleados.Add(new Empleado("17.890.345-3", "Jorge Herrera", "Calle San Ignacio 1234, Estación Central", "+56966557788", 5000, 7000));
                empleados.Add(new Empleado("16.123.789-1", "Camila Torres", "Av. Los Carrera 321, Recoleta", "+56988990011", 5000, 7000));
                empleados.Add(new Empleado("20.456.112-9", "Tomás Valenzuela", "Calle El Tranque 88, Vitacura", "+56955334477", 5000, 7000));
                empleados.Add(new Empleado("18.765.432-6", "Matías Gutiérrez", "Callejón El Sauce 67, Lo Prado", "+56998765432", 5000, 7000));
                empleados.Add(new Empleado("19.852.963-5", "Isidora Peña", "Camino Las Parcelas 654, Pudahuel", "+56944445555", 5000, 7000));
                empleados.Add(new Empleado("15.789.123-0", "Pedro Venegas", "Pasaje Los Andes 321, La Reina", "+56977778888", 5000, 7000));
                empleados.Add(new Empleado("20.321.789-4", "Catalina Carrasco", "Av. Vicuña Mackenna 1000, San Miguel", "+56911221122", 5000, 7000));
                empleados.Add(new Empleado("18.000.111-9", "Gonzalo Vera", "Calle Santa Rosa 789, San Bernardo", "+56999998888", 5000, 7000));
                empleados.Add(new Empleado("19.667.333-7", "Lorena Bustos", "Camino Antupirén 345, Huechuraba", "+56922334455", 5000, 7000));
                empleados.Add(new Empleado("16.456.987-2", "Agustín Navarrete", "Av. El Parque 109, Lo Espejo", "+56933669988", 5000, 7000));
                empleados.Add(new Empleado("17.234.567-3", "Trinidad Lagos", "Callejón Quilpué 222, Pedro Aguirre Cerda", "+56999008877", 5000, 7000));
                empleados.Add(new Empleado("15.345.678-9", "Martín Acuña", "Av. Departamental 654, El Bosque", "+56911224455", 5000, 7000));
                empleados.Add(new Empleado("18.998.321-5", "Josefa Parra", "Pasaje El Arrayán 450, La Granja", "+56933447788", 5000, 7000));
                empleados.Add(new Empleado("20.000.789-1", "Benjamín Rivera", "Av. Santa Isabel 123, Santiago Centro", "+56944332211", 5000, 7000));
                empleados.Add(new Empleado("19.888.456-2", "Florencia Morales", "Camino La Higuera 765, Cerro Navia", "+56955667788", 5000, 7000));
                empleados.Add(new Empleado("18.234.900-3", "Diego Tapia", "Calle Los Pinos 333, Renca", "+56966558877", 5000, 7000));
                empleados.Add(new Empleado("17.483.290-5", "Javiera Olivares", "Camino El Alba 1350, Las Condes", "+56956789934", 5000, 7000));
                empleados.Add(new Empleado("16.294.812-7", "Felipe Gutiérrez", "Los Acacios 812, Renca", "+56943981267", 5000, 7000));
            }
        }
    }
}
