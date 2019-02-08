using PruebaTecnica.Datos;
using PruebaTecnica.Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Negocio.Negocio
{
    public class NegocioDocumentacion
    {

        public IList<DominioDocumentacion> ObtenerPorId(int id)
        {
            IList<DominioDocumentacion> listaDominioDocumentacion = null;

            if (id > 0)
            {
                using (PruebaTecnicaEntities dbContext = new PruebaTecnicaEntities())
                {
                    var lista = dbContext.Documentacion.OrderByDescending(x => x.Id == id && x.Estado).ToList();

                    if (lista != null
                        && lista.Count > 0)
                    {
                        listaDominioDocumentacion = new List<DominioDocumentacion>();

                        foreach (var item in lista)
                        {
                            if (item.Estado)
                            {
                                DominioDocumentacion dominioDocumentacion = ObtenerDominioDocumentacion(item);
                                listaDominioDocumentacion.Add(dominioDocumentacion);
                            }
                        }
                    }
                }
            }

            return listaDominioDocumentacion;
        }


        public DominioDocumentacion Guardar(DominioDocumentacion dominioDocumentacion)
        {

            if (dominioDocumentacion != null
               && dominioDocumentacion.NumComunicacion > 0
               && dominioDocumentacion.IdClasificacion > 0
               && dominioDocumentacion.IdEmpleado > 0
               && !string.IsNullOrEmpty(dominioDocumentacion.NombreFuncionario))
            {
                using (PruebaTecnicaEntities dbContext = new PruebaTecnicaEntities())
                {
                    var resultado = dbContext.Documentacion.Add(new Documentacion()
                    {
                        NombreFuncionario = dominioDocumentacion.NombreFuncionario
                        , NumComunicacion = dominioDocumentacion.NumComunicacion
                        , IdClasificacion = dominioDocumentacion.IdClasificacion
                        , IdEmpleado = dominioDocumentacion.IdEmpleado
                        , Estado = true
                        , Creado = DateTime.Now
                        , Observaciones = dominioDocumentacion.Observaciones
                    });


                    if (dbContext.SaveChanges() > 0)
                    {
                        dominioDocumentacion.Id = resultado.Id;
                    }
                }
            }

            return dominioDocumentacion;
        }

        public void Eliminar(int id)
        {
            if (id > 0)
            {
                using (var dbContext = new PruebaTecnicaEntities())
                {
                    var documento = dbContext.Documentacion.Where(x => x.Id == id).FirstOrDefault();

                    if (documento != null
                        && documento.Id > 0)
                    {
                        documento.Estado = false;
                        //actividad.Modificado = DateTime.Now();

                        dbContext.Entry(documento).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }
        }

        public DominioDocumentacion ObtenerDominioDocumentacion(Documentacion entity)
        {
            DominioDocumentacion dominioDocumentacion = null;

            if (entity != null)
            {
                dominioDocumentacion = new DominioDocumentacion()
                {
                    Id = entity.Id
                    , NombreFuncionario = entity.NombreFuncionario
                    , NumComunicacion = entity.NumComunicacion
                    , IdClasificacion = entity.IdClasificacion
                    , IdEmpleado = entity.IdEmpleado
                    , Observaciones = entity.Observaciones
                    , Estado = entity.Estado
                    , Creado = entity.Creado
                    , Modificado = entity.Modificado
                };
            }

            return dominioDocumentacion;
        }

    }
}
