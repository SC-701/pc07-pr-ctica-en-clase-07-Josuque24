using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class TipoCambioReglas : ITipoCambioReglas
    {
        private readonly ITipoCambioServicio _tipoCambioServicio;

        public TipoCambioReglas(ITipoCambioServicio tipoCambioServicio)
        {
            _tipoCambioServicio = tipoCambioServicio;
        }
        public async Task<decimal> conversionDivisas(decimal precioCRC)
        {
            var conversion = await _tipoCambioServicio.ObtenerCambio();

            var tipoCambio = conversion?.datos?
                .FirstOrDefault()?
                .indicadores?.FirstOrDefault()?
                .series?.FirstOrDefault()?
                .valorDatoPorPeriodo ?? 0;

            if (tipoCambio <= 0)
            {
                throw new Exception("No se pudo obtener un tipo de cambio válido.");
            }
            var calculoNuevo = Math.Round(precioCRC / tipoCambio, 2);
            return calculoNuevo;
        }
    }
}
