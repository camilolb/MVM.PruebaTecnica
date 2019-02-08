using PruebaTecnica.Datos;
using PruebaTecnica.Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Negocio.Negocio
{
    public class NegocioClasificacion
    {

        public IList<DominioClasificacion> ObtenerTodo()
        {
            IList<DominioClasificacion> listaDominioClasificacion = null;


                using (PruebaTecnicaEntities dbContext = new PruebaTecnicaEntities())
                {
                    var lista = dbContext.Clasificacion.OrderByDescending(x => x.Id).ToList();

                    if (lista != null
                        && lista.Count > 0)
                    {
                    listaDominioClasificacion = new List<DominioClasificacion>();

                        foreach (var item in lista)
                        {

                        DominioClasificacion dominioClasificacion = ObtenerDominioClasificacion(item);
                        listaDominioClasificacion.Add(dominioClasificacion);
                            
                        }
                    }
                }
            

            return listaDominioClasificacion;

        }


        public DominioClasificacion ObtenerDominioClasificacion(Clasificacion entity)
        {
            DominioClasificacion dominioClasificacion = null;

            if (entity != null)
            {
                dominioClasificacion = new DominioClasificacion()
                {
                    Id = entity.Id
                    , Nombre = entity.Nombre
                    , Creado = entity.Creado
                    , Modificado = entity.Modificado
                };
            }

            return dominioClasificacion;
        }




    }
}
