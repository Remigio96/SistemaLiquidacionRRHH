using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class LiquidacionDTO
    {
        public int SueldoBruto { get; set; }
        public double DescuentoAFP { get; set; }
        public double DescuentoSalud { get; set; }
        public double SueldoLiquido { get; set; }
        public string RutEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public int HorasTrabajadas { get; set; }
        public int HorasExtras { get; set; }
        public string AFP { get; set; }
        public string Salud { get; set; }

    }
}
