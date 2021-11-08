using Veterinaria_Backend.acceso_a_datos.Implementaciones;
using Veterinaria_Backend.acceso_a_datos.Interfaces;
using Veterinaria_Backend.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria_Backend.servicios
{
    class VeterinariaService : IService
    {
        private IVeterinariaDao dao;

        public VeterinariaService()
        {
            dao = new VeterinariaDao();
        }

        public List<Cliente> GetCliente()
        {
            return dao.GetClientes();
        }

        public List<Mascota> GetMascota()
        {
            return dao.GetMascotas();
        }

        //public List<Mascota> GetByFiltersMascota(string id_cliente)
        //{
        //    return dao.GetByFiltersMascota(id_cliente);
        //}

        public bool Login(string User, string Password)
        {
            return dao.Login(User, Password);
        }


    }
}
