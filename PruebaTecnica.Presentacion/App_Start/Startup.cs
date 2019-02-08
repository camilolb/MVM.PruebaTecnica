using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PruebaTecnica.Presentacion.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(PruebaTecnica.Presentacion.App_Start.Startup))]

namespace PruebaTecnica.Presentacion.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                Provider = new SecurityProvider()
                , AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1440)
                , AllowInsecureHttp = true
                , TokenEndpointPath = new PathString("/oauth/token")
            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseWebApi(config);

            app.Use(async (context, next) =>
            {
                string host = context.Request.Uri.Host.ToLower();


                if (context.Request.IsSecure
                    || host.ToLower().Contains("localhost")
                    || host.Contains("127.0.0.1"))
                {
                    await next();
                }
                else
                {
                    var withHttps = Uri.UriSchemeHttps + Uri.SchemeDelimiter + context.Request.Uri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Scheme, UriFormat.SafeUnescaped);
                    context.Response.Redirect(withHttps);
                }
            });
        }


    }
}