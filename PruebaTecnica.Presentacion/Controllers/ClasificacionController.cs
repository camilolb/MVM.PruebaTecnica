using Newtonsoft.Json;
using PruebaTecnica.Negocio.Dominio;
using PruebaTecnica.Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaTecnica.Presentacion.Controllers
{
    public class ClasificacionController : ApiController
    {
        // GET: api/Clasificacion
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                IList<DominioClasificacion> listaClasificaciones = new NegocioClasificacion().ObtenerTodo();

                if (listaClasificaciones != null
                    && listaClasificaciones.Count > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(listaClasificaciones));
                }

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // GET: api/Clasificacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clasificacion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clasificacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clasificacion/5
        public void Delete(int id)
        {
        }
    }
}
