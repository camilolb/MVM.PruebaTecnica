using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using PruebaTecnica.Negocio.Dominio;
using PruebaTecnica.Negocio.Negocio;

namespace PruebaTecnica.Presentacion.Base
{
    public class SecurityProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);


            if (context != null
                && !string.IsNullOrEmpty(context.UserName)
                && !string.IsNullOrEmpty(context.Password))

            {
                DominioUsuario dominioUsuario = new NegocioUsuario().ObtenerUsuario(context.UserName, context.Password);

                if (dominioUsuario != null
                    && dominioUsuario.Id > 0)
                {
                    identity.AddClaims(ObtenerDatosUsuario(dominioUsuario));
                    context.Validated(identity);
                }
            }
        }

    
        private void RechazarAutenticacion(OAuthGrantResourceOwnerCredentialsContext context)
        {
            throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
        }


        private IList<Claim> ObtenerDatosUsuario(DominioUsuario dominioUsuario)
        {
            IList<Claim> listaDatos = new List<Claim>();

            listaDatos.Add(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(dominioUsuario)));
            listaDatos.Add(new Claim(ClaimTypes.Email, dominioUsuario.Email));

            return listaDatos;
        }



    }
}