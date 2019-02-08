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
    public class AutenticacionController : BaseApiController
    {

        [AllowAnonymous]
        [HttpGet]

        [Route("oauth/check")]
        public HttpResponseMessage GetCurrentUser()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized);

            try
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    DominioUsuario dominioUsuario = ObtenerUsuarioActual();

                    if (dominioUsuario != null
                        && dominioUsuario.Id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(dominioUsuario));
                    }
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

    }
}
