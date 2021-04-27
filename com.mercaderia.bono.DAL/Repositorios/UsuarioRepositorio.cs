using com.mercaderia.bono.Entidades.Dto;
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
    public sealed partial class UsuarioRepositorio : Repositorio<Usuarios>
    {
        public UsuarioRepositorio(AeronauticaEntities context) : base(context)
        {

        }

        /// <summary>
        /// Método que obtiene todas los tipos documentos existentes
        /// </summary>
        /// <returns></returns>
        public List<AccesoUsuarioDto> ObtenerAcceso(string identificacion, string clave)
        {
            var usuarioActivo = context.Usuarios.Where(x => x.Identificacion == identificacion
                                                && x.clave == clave);

            var consulta = (from usu in usuarioActivo
                            select new AccesoUsuarioDto()
                            {
                                codUsuario = usu.Id,
                                nombres = usu.Nombre + " " + usu.Apellidos,
                                rol = usu.Rol                               

                            }).ToList();

            return consulta.ToList();
        }

        public List<Usuarios> ObtenerUsuario()
        {
            var usuarioActivo = context.Usuarios.Where(x => x.Rol == 1);           
            return usuarioActivo.ToList();
        }
    }
}
