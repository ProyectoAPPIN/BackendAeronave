using com.mercaderia.bono.Entidades.ModeloEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace com.mercaderia.bono.DAL
{
    public sealed partial class TipoDocumentoRepositorio : Repositorio<Aeronaves>
    {
        public TipoDocumentoRepositorio(AeronauticaEntities context) : base(context)
        {

        }

        /// <summary>
        /// Método que obtiene todas los tipos documentos existentes
        /// </summary>
        /// <returns></returns>
        public List<Aeronaves> ObtenerAeronaves()
        { 
            return dbSet.OrderBy(t => new { t.Id, t.Nombre }).ToList<Aeronaves>();
        }      
    }
}
