using Newtonsoft.Json;
using PruebaTecnica.Negocio.Dominio;
using PruebaTecnica.Negocio.Negocio;
using PruebaTecnica.Presentacion.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PruebaTecnica.Presentacion.Controllers
{

    [Authorize]
    public class DocumentacionController : BaseApiController
    {
        // GET: api/Actividad
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            
            try
            {
                DominioUsuario dominioUsuario = ObtenerUsuarioActual();
                IList<DominioDocumentacion> listaDocumentaciones = new NegocioDocumentacion().ObtenerPorId(dominioUsuario.Id);

                if (listaDocumentaciones != null
                    && listaDocumentaciones.Count > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(listaDocumentaciones));
                }

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // GET: api/Actividad/5
        public string Get(int id)
        {
            return "";
        }

        // POST: api/Actividad
        public HttpResponseMessage Post(DominioDocumentacion dominioDocumentacion)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                if (dominioDocumentacion != null
                   && dominioDocumentacion.NumComunicacion > 0
                   && dominioDocumentacion.IdClasificacion > 0
                   && !string.IsNullOrEmpty(dominioDocumentacion.NombreFuncionario))
                {
                    DominioUsuario dominioUsuario = ObtenerUsuarioActual();
                    dominioDocumentacion.IdEmpleado = dominioUsuario.Id;

                    dominioDocumentacion = new NegocioDocumentacion().Guardar(dominioDocumentacion);

                    if (dominioDocumentacion.Id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(dominioDocumentacion));
                    }
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;

        }

        // PUT: api/Actividad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Actividad/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                new NegocioDocumentacion().Eliminar(id);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }
    }
}
