using Newtonsoft.Json;
using PruebaTecnica.Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace PruebaTecnica.Presentacion.Base
{
    public class BaseApiController : ApiController
    {
        [NonAction]
        public DominioUsuario ObtenerUsuarioActual()
        {
            DominioUsuario usuarioActual = null;

            var userData = (ClaimsPrincipal)HttpContext.Current.User;

            if (userData.FindFirst(ClaimTypes.UserData) != null
                && !string.IsNullOrEmpty(userData.FindFirst(ClaimTypes.UserData).Value))
            {
                usuarioActual = JsonConvert.DeserializeObject<DominioUsuario>(userData.FindFirst(ClaimTypes.UserData).Value);
            }

            return usuarioActual;
        }
    }
}