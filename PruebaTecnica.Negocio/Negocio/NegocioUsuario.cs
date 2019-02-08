using PruebaTecnica.Datos;
using PruebaTecnica.Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Negocio.Negocio
{
    public class NegocioUsuario
    {

        public DominioUsuario ObtenerUsuario(string email, string password)
        {
            DominioUsuario dominioUsuario = null;

            if (!string.IsNullOrEmpty(email)
                && !string.IsNullOrEmpty(password))
            {
                using (var dbContext = new PruebaTecnicaEntities())
                {

                    var resultado = dbContext.Empleado.Where(x => x.Email == email
                                                            && x.Password == password).FirstOrDefault();

                    if (resultado != null
                        && resultado.Id > 0)
                    {
                        dominioUsuario = new DominioUsuario();
                        dominioUsuario = ObtenerDominioUsuario(resultado);

                        //Valido que no envie la contraseña a la presentación
                        dominioUsuario.Password = null;
                    }
                }
            }

            return dominioUsuario;
        }

        public DominioUsuario ObtenerDominioUsuario(Empleado entity)
        {
            DominioUsuario dominioHoras = null;

            if (entity != null)
            {
                dominioHoras = new DominioUsuario()
                {
                    Id = entity.Id
                    , Email = entity.Email
                    , Password = entity.Password
                    , Creado = entity.Creado
                };
            }

            return dominioHoras;
        }

    }
}
