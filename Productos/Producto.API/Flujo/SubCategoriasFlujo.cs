using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class SubCategoriasFlujo : ISubCategoriasFlujo
    {
        private ISubCategoriasDA _subCategoriasDA;

        public SubCategoriasFlujo(ISubCategoriasDA subCategoriasDA)
        {
            _subCategoriasDA = subCategoriasDA;
        }

        public Task<IEnumerable<SubCategoriaResponse>> Obtener()
        {
            return _subCategoriasDA.Obtener();
        }
    }
}
