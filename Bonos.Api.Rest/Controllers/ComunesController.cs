using Bonos.Api.Rest.Helper;
using com.mercaderia.bono.Entidades.ModeloEntidades;
using com.mercaderia.bono.Negocio;
using com.mercaderia.bono.Utilidades.Auditoria;
using com.mercaderia.bono.Utilidades.Excepciones;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using com.mercaderia.bono.Entidades.Dto;
using System.Web.Http.Cors;

namespace Bonos.Api.Rest.Controllers
{
    [RoutePrefix("api/Comunes")]
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Headers")]
    public class DominioController : ApiController
    {
        Logger log = Logger.Instancia;
        /// <summary>
        /// M�todo que devuelve los tipos de documento registrados en la base de datos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAeronaves")]
        public HttpResponseMessage GetAeronaves()
        {
            try
            {
                NegocioTipoDocumentos negocioComun = new NegocioTipoDocumentos();
                List<Aeronaves> lstTipoDocResultado = negocioComun.ObtenerAeronaves();
                if (lstTipoDocResultado.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MsgAeronavesInexistente);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lstTipoDocResultado);
            }
            catch (ExceptionControlada ex)
            {
                log.EscribirLogError(Mensajes.MsgAeronavesError, ex);
                return Request.CreateResponse(HttpStatusCode.Conflict, new ApiException(HttpStatusCode.Conflict,
                    ex.Message, ex));
            }
            catch (Exception ex)
            {
                log.EscribirLogError(Mensajes.MsgErrorNoEspacificado, ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new ApiException(HttpStatusCode.InternalServerError, Mensajes.MsgErrorNoEspacificado, ex));
            }
        }

        /// <summary>
        /// Servicio para dar acceso a la aplicacion se valida si el tipo documento y numero de documento e institucion existen
        /// Se verifica si tiene un registro de ingreso
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("ValidaUsuario")]
        public HttpResponseMessage GetValidaUsuario(string usuario, string clave)
        {
            try
            {
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                List<AccesoUsuarioDto> lstTipoDocResultado = negocioUsuario.ObtenerAcceso(usuario, clave);
                if (lstTipoDocResultado.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MsgAeronavesError);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lstTipoDocResultado);
            }
            catch (ExceptionControlada ex)
            {
                log.EscribirLogError(Mensajes.MsgAeronavesError, ex);
                return Request.CreateResponse(HttpStatusCode.Conflict, new ApiException(HttpStatusCode.Conflict,
                    ex.Message, ex));
            }
            catch (Exception ex)
            {
                log.EscribirLogError(Mensajes.MsgErrorNoEspacificado, ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new ApiException(HttpStatusCode.InternalServerError, Mensajes.MsgErrorNoEspacificado, ex));
            }
        }

        [HttpGet]
        [Route("GetUsuario")]
        public HttpResponseMessage GetUsuario()
        {
            try
            {
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                List<Usuarios> lstTipoDocResultado = negocioUsuario.ObtenerUsuarios();
                if (lstTipoDocResultado.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MsgAeronavesError);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lstTipoDocResultado);
            }
            catch (ExceptionControlada ex)
            {
                log.EscribirLogError(Mensajes.MsgAeronavesError, ex);
                return Request.CreateResponse(HttpStatusCode.Conflict, new ApiException(HttpStatusCode.Conflict,
                    ex.Message, ex));
            }
            catch (Exception ex)
            {
                log.EscribirLogError(Mensajes.MsgErrorNoEspacificado, ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new ApiException(HttpStatusCode.InternalServerError, Mensajes.MsgErrorNoEspacificado, ex));
            }
        }



    }    
}
