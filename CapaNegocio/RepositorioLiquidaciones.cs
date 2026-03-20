using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CapaNegocio
{
    public static class RepositorioLiquidaciones
    {
        private static List<LiquidacionDTO> liquidaciones = new List<LiquidacionDTO>();

        public static void Guardar(LiquidacionDTO liquidacion)
        {
            liquidaciones.Add(liquidacion);
        }

        public static List<LiquidacionDTO> ObtenerTodas()
        {
            return new List<LiquidacionDTO>(liquidaciones);
        }

        public static void Limpiar()
        {
            liquidaciones.Clear();
        }

        // Precarga de liquidaciones para pruebas
        public static void PrecargarLiquidaciones()
        {
            if (liquidaciones.Count == 0)
            {
                liquidaciones.Add(new LiquidacionDTO
                {
                    RutEmpleado = "19.595.224-4", NombreEmpleado = "Ana Ríos",
                    HorasTrabajadas = 160, HorasExtras = 20, AFP = "CUPRUM", Salud = "FONASA",
                    SueldoBruto = 940000, DescuentoAFP = 65800, DescuentoSalud = 112800, SueldoLiquido = 761400
                });
                liquidaciones.Add(new LiquidacionDTO
                {
                    RutEmpleado = "18.461.837-k", NombreEmpleado = "Luis Soto",
                    HorasTrabajadas = 180, HorasExtras = 10, AFP = "MODELO", Salud = "CONSALUD",
                    SueldoBruto = 970000, DescuentoAFP = 87300, DescuentoSalud = 126100, SueldoLiquido = 756600
                });
                liquidaciones.Add(new LiquidacionDTO
                {
                    RutEmpleado = "13.218.530-0", NombreEmpleado = "Ignacio Paredes",
                    HorasTrabajadas = 200, HorasExtras = 30, AFP = "CAPITAL", Salud = "MASVIDA",
                    SueldoBruto = 1210000, DescuentoAFP = 145200, DescuentoSalud = 169400, SueldoLiquido = 895400
                });
                liquidaciones.Add(new LiquidacionDTO
                {
                    RutEmpleado = "10.172.930-4", NombreEmpleado = "Camila Rojas",
                    HorasTrabajadas = 150, HorasExtras = 5, AFP = "PROVIDA", Salud = "BANMEDICA",
                    SueldoBruto = 785000, DescuentoAFP = 102050, DescuentoSalud = 117750, SueldoLiquido = 565200
                });
                liquidaciones.Add(new LiquidacionDTO
                {
                    RutEmpleado = "12.820.418-1", NombreEmpleado = "Tomás Herrera",
                    HorasTrabajadas = 170, HorasExtras = 15, AFP = "CUPRUM", Salud = "FONASA",
                    SueldoBruto = 955000, DescuentoAFP = 66850, DescuentoSalud = 114600, SueldoLiquido = 773550
                });
                liquidaciones.Add(new LiquidacionDTO
                {
                    RutEmpleado = "14.588.806-6", NombreEmpleado = "Cristina Leiva",
                    HorasTrabajadas = 160, HorasExtras = 0, AFP = "MODELO", Salud = "CONSALUD",
                    SueldoBruto = 800000, DescuentoAFP = 72000, DescuentoSalud = 104000, SueldoLiquido = 624000
                });
                liquidaciones.Add(new LiquidacionDTO
                {
                    RutEmpleado = "14.596.138-8", NombreEmpleado = "Luis González",
                    HorasTrabajadas = 190, HorasExtras = 25, AFP = "CAPITAL", Salud = "MASVIDA",
                    SueldoBruto = 1125000, DescuentoAFP = 135000, DescuentoSalud = 157500, SueldoLiquido = 832500
                });
                liquidaciones.Add(new LiquidacionDTO
                {
                    RutEmpleado = "15.621.887-5", NombreEmpleado = "María Díaz",
                    HorasTrabajadas = 140, HorasExtras = 10, AFP = "PROVIDA", Salud = "BANMEDICA",
                    SueldoBruto = 770000, DescuentoAFP = 100100, DescuentoSalud = 115500, SueldoLiquido = 554400
                });
                liquidaciones.Add(new LiquidacionDTO
                {
                    RutEmpleado = "16.473.291-3", NombreEmpleado = "Sebastián Vega",
                    HorasTrabajadas = 160, HorasExtras = 40, AFP = "CUPRUM", Salud = "FONASA",
                    SueldoBruto = 1080000, DescuentoAFP = 75600, DescuentoSalud = 129600, SueldoLiquido = 874800
                });
                liquidaciones.Add(new LiquidacionDTO
                {
                    RutEmpleado = "13.552.974-2", NombreEmpleado = "Valentina Fuentes",
                    HorasTrabajadas = 175, HorasExtras = 8, AFP = "MODELO", Salud = "CONSALUD",
                    SueldoBruto = 931000, DescuentoAFP = 83790, DescuentoSalud = 121030, SueldoLiquido = 726180
                });
            }
        }

        // 🔹 Guardar en archivo JSON
        public static void GuardarEnArchivo(string ruta)
        {
            string json = JsonConvert.SerializeObject(liquidaciones, Formatting.Indented);
            File.WriteAllText(ruta, json);
        }

        // 🔹 Cargar desde archivo JSON
        public static void CargarDesdeArchivo(string ruta)
        {
            if (File.Exists(ruta))
            {
                string json = File.ReadAllText(ruta);
                liquidaciones = JsonConvert.DeserializeObject<List<LiquidacionDTO>>(json) ?? new List<LiquidacionDTO>();
            }
        }
    }
}
