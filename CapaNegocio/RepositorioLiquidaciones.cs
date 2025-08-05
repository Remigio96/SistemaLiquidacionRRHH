using System.Collections.Generic;

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
    }
}
