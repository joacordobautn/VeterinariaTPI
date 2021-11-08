using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria_Backend.dominio
{
    public class Atencion
    {
        public int IdAtencion { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double Importe { get; set; }
        public int IdMascota { get; set; }

        //public Atencion()
        //{

        //}
    }
}
