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
using com.mercaderia.bono.Entidades.Dto;

namespace com.mercaderia.bono.Negocio
{
    public sealed partial class NegocioUsuario
    {
        /// <summary>
        /// Método que obtiene todos los documentos existentes
        /// </summary>
        /// <returns></returns>
        /// 
        public List<AccesoUsuarioDto> ObtenerAcceso(string identificacion, string clave)
        {
            List<AccesoUsuarioDto> lstUsuario = new List<AccesoUsuarioDto>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                lstUsuario = unitOfWork.UsuarioRepositorio.ObtenerAcceso(identificacion, clave);
                if (lstUsuario == null)
                {
                    throw new ExceptionControlada(Mensajes.MsgAeronavesError);
                }
                if (lstUsuario.Count == 0)
                {
                    throw new ExceptionControlada(Mensajes.MsgAeronavesInexistente);
                }
            }
            return lstUsuario;
        }

        public List<Usuarios> ObtenerUsuarios()
        {
            List<Usuarios> lstUsuario = new List<Usuarios>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                lstUsuario = unitOfWork.UsuarioRepositorio.ObtenerUsuario();
                if (lstUsuario == null)
                {
                    throw new ExceptionControlada(Mensajes.MsgAeronavesError);
                }
                if (lstUsuario.Count == 0)
                {
                    throw new ExceptionControlada(Mensajes.MsgAeronavesInexistente);
                }
            }
            return lstUsuario;
        }


    }
}

