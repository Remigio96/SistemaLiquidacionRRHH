using CapaDatos;

namespace CapaNegocio
{
    public class LiquidacionService
    {
        // Método original
        public Liquidacion GenerarLiquidacion(
            Empleado empleado,
            int horasTrabajadas,
            int horasExtras,
            string afp,
            string salud)
        {
            return new Liquidacion(empleado, horasTrabajadas, horasExtras, afp, salud);
        }

        // Método para convertir DTO a entidad interna
        public Liquidacion GenerarLiquidacionDTO(
            EmpleadoDTO dto,
            int horasTrabajadas,
            int horasExtras,
            string afp,
            string salud)
        {
            var empleado = new Empleado
            {
                Rut = dto.Rut,
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                ValorHora = dto.ValorHora,
                ValorHoraExtra = dto.ValorHoraExtra
            };

            return new Liquidacion(empleado, horasTrabajadas, horasExtras, afp, salud);
        }

        // NUEVO método para retornar un DTO limpio
        public LiquidacionDTO CalcularLiquidacionDesdeDTO(
            EmpleadoDTO dto,
            int horasTrabajadas,
            int horasExtras,
            string afp,
            string salud)
        {
            var liquidacion = GenerarLiquidacionDTO(dto, horasTrabajadas, horasExtras, afp, salud);

            return new LiquidacionDTO
            {
                SueldoBruto = liquidacion.CalcularSueldoBruto(),
                DescuentoAFP = liquidacion.CalcularDescuentoAFP(),
                DescuentoSalud = liquidacion.CalcularDescuentoSalud(),
                SueldoLiquido = liquidacion.CalcularSueldoLiquido()
            };
        }

        // Exponer arreglos de AFP y Salud a la capa de presentación
        public static string[] ObtenerNombresAFP()
        {
            return Liquidacion.NombresAFP;
        }

        public static string[] ObtenerNombresSalud()
        {
            return Liquidacion.NombresSalud;
        }

        // Métodos auxiliares
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
