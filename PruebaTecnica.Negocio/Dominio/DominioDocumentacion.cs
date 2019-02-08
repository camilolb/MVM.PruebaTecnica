using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Negocio.Dominio
{
    public class DominioDocumentacion
    {
        public int Id { get; set; }

        public string NombreFuncionario { get; set; }
        
        public int NumComunicacion { get; set; }

        public int IdClasificacion { get; set; }

        public int IdEmpleado { get; set; }

        public bool Estado { get; set; }

        public string Observaciones { get; set; }

        public DateTime Creado { get; set; }

        public DateTime? Modificado { get; set; }
    }
}
