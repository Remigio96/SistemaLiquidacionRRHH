using System;

namespace CapaDatos
{
    public class Liquidacion
    {
        // Arreglos unidimensionales para AFP: nombres y porcentajes
        public static readonly string[] NombresAFP = { "CUPRUM", "MODELO", "CAPITAL", "PROVIDA" };
        public static readonly double[] PorcentajesAFP = { 0.07, 0.09, 0.12, 0.13 };

        // Arreglos unidimensionales para Salud: nombres y porcentajes
        public static readonly string[] NombresSalud = { "FONASA", "CONSALUD", "MASVIDA", "BANMEDICA" };
        public static readonly double[] PorcentajesSalud = { 0.12, 0.13, 0.14, 0.15 };

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

            for (int i = 0; i < NombresAFP.Length; i++)
            {
                if (NombresAFP[i] == AFP)
                {
                    porcentaje = PorcentajesAFP[i];
                    break;
                }
            }

            return CalcularSueldoBruto() * porcentaje;
        }

        public double CalcularDescuentoSalud()
        {
            double porcentaje = 0.0;

            for (int i = 0; i < NombresSalud.Length; i++)
            {
                if (NombresSalud[i] == Salud)
                {
                    porcentaje = PorcentajesSalud[i];
                    break;
                }
            }

            return CalcularSueldoBruto() * porcentaje;
        }

        public double CalcularSueldoLiquido()
        {
            return CalcularSueldoBruto() - CalcularDescuentoAFP() - CalcularDescuentoSalud();
        }
    }
}
