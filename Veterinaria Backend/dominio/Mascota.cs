using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria_Backend.dominio
{
    public class Mascota
    {
        public int IdMascota { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }

        //public string Cliente { get; set; }

        public Tipo Tipos { get; set; }

        public List<Atencion> Atenciones { get; set; }

        public Mascota()
        {
            Tipos = new Tipo();
            Atenciones = new List<Atencion>();
            

        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
