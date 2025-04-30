using CapaDatos;

namespace CapaNegocio
{
    public class LiquidacionService
    {
        // Método principal para generar liquidación y devolverla
        public Liquidacion GenerarLiquidacion(
            Empleado empleado,
            int horasTrabajadas,
            int horasExtras,
            string afp,
            string salud)
        {
            return new Liquidacion(empleado, horasTrabajadas, horasExtras, afp, salud);
        }

        // Métodos auxiliares para acceder a cada cálculo (opcional pero útil para separar responsabilidades)
        public int ObtenerSueldoBruto(Liquidacion liquidacion)
        {
            return liquidacion.CalcularSueldoBruto();
        }

        public double ObtenerDescuentoAFP(Liquidacion liquidacion)
        {
            return liquidacion.CalcularDescuentoAFP();
        }

        public double ObtenerDescuentoSalud(Liquidacion liquidacion)
        {
            return liquidacion.CalcularDescuentoSalud();
        }

        public double ObtenerSueldoLiquido(Liquidacion liquidacion)
        {
            return liquidacion.CalcularSueldoLiquido();
        }
    }
}
