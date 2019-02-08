using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Negocio.Dominio
{
    public class DominioUsuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public DateTime Creado { get; set; }
    }
}
