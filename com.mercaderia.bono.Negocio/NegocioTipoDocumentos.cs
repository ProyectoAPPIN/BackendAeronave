using com.mercaderia.bono.DAL;
using com.mercaderia.bono.Entidades.ModeloEntidades;
using com.mercaderia.bono.Utilidades.Auditoria;
using com.mercaderia.bono.Entidades.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using com.mercaderia.bono.Utilidades.Excepciones;

namespace com.mercaderia.bono.Negocio
{
    public sealed partial class NegocioTipoDocumentos //: NegocioAbstracto
    {
        /// <summary>
        /// Método que obtiene todos los documentos existentes
        /// </summary>
        /// <returns></returns>
        /// 
        public List<Aeronaves> ObtenerAeronaves()
        {
            List<Aeronaves> lstTipoDoc = new List<Aeronaves>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                lstTipoDoc = unitOfWork.TipoDocumentoRepositorio.ObtenerAeronaves();                   
                if (lstTipoDoc == null)
                {
                    throw new ExceptionControlada(Mensajes.MsgAeronavesError);
                }
                if (lstTipoDoc.Count == 0)
                {
                    throw new ExceptionControlada(Mensajes.MsgAeronavesInexistente);
                }
            }
            return lstTipoDoc;
        } 
    }
}
