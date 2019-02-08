using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Negocio.Dominio
{
    public class DominioClasificacion
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }

        public DateTime Creado { get; set; }

        public DateTime? Modificado { get; set; }
    }
}
