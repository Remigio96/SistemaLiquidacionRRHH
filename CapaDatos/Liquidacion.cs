using System;

namespace CapaDatos
{
    public class Liquidacion
    {
        // Referencia al empleado asociado
        public Empleado Empleado { get; set; }

        // Datos de entrada para el cálculo
        public int HorasTrabajadas { get; set; }
        public int HorasExtras { get; set; }
        public string AFP { get; set; }
        public string Salud { get; set; }

        // Constructor
        public Liquidacion(Empleado empleado, int horasTrabajadas, int horasExtras, string afp, string salud)
        {
            Empleado = empleado;
            HorasTrabajadas = horasTrabajadas;
            HorasExtras = horasExtras;
            AFP = afp;
            Salud = salud;
        }

        // Métodos de cálculo
        public int CalcularSueldoBruto()
        {
            return (HorasTrabajadas * Empleado.ValorHora) + (HorasExtras * Empleado.ValorHoraExtra);
        }

        public double CalcularDescuentoAFP()
        {
            double porcentaje = 0.0;

            switch (AFP)
            {
                case "CUPRUM":
                    porcentaje = 0.07;
                    break;
                case "MODELO":
                    porcentaje = 0.09;
                    break;
                case "CAPITAL":
                    porcentaje = 0.12;
                    break;
                case "PROVIDA":
                    porcentaje = 0.13;
                    break;
                default:
                    porcentaje = 0.0;
                    break;
            }

            return CalcularSueldoBruto() * porcentaje;
        }

        public double CalcularDescuentoSalud()
        {
            double porcentaje = 0.0;

            switch (Salud)
            {
                case "FONASA":
                    porcentaje = 0.12;
                    break;
                case "CONSALUD":
                    porcentaje = 0.13;
                    break;
                case "MASVIDA":
                    porcentaje = 0.14;
                    break;
                case "BANMEDICA":
                    porcentaje = 0.15;
                    break;
                default:
                    porcentaje = 0.0;
                    break;
            }

            return CalcularSueldoBruto() * porcentaje;
        }


        public double CalcularSueldoLiquido()
        {
            return CalcularSueldoBruto() - CalcularDescuentoAFP() - CalcularDescuentoSalud();
        }
    }
}
