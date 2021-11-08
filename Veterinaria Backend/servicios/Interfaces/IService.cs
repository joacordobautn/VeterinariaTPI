using Veterinaria_Backend.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria_Backend.servicios
{
    public interface IService
    {

        public List<Cliente> GetCliente();
        public List<Mascota> GetMascota();
        //public List<Mascota> GetByFiltersMascota(string id_cliente);
        bool Login(string User, string Password);

    }
}
