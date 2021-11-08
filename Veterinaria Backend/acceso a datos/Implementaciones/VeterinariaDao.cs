using Veterinaria_Backend.acceso_a_datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Veterinaria_Backend.dominio;
using Veterinaria_Backend.servicios;

namespace Veterinaria_Backend.acceso_a_datos.Implementaciones
{
    class VeterinariaDao : IVeterinariaDao


    {
        private string connectionString = @"Data Source=localhost;Initial Catalog=Veterinaria_PII;Integrated Security=True";

        public List<Cliente> GetClientes()
        {
            List<Cliente> lst = new List<Cliente>();
            SqlConnection cnn = new SqlConnection(@"Data Source=localhost;Initial Catalog=Veterinaria_PII;Integrated Security=True");
            cnn.Open();
            SqlCommand cmd = new SqlCommand("pa_consultar_cliente", cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());

            cnn.Close();

            foreach (DataRow row in table.Rows)
            {
                Cliente oCliente = new Cliente();
                oCliente.IdCliente = Convert.ToInt32(row["id_cliente"]);
                oCliente.Nombre = row["nombre"].ToString();

                lst.Add(oCliente);
            }

            return lst;
        }

        public List<Mascota> GetMascotas()
        {
            List<Mascota> lst = new List<Mascota>();
            SqlConnection cnn = new SqlConnection(@"Data Source=localhost;Initial Catalog=Veterinaria_PII;Integrated Security=True");
            cnn.Open();
            SqlCommand cmd = new SqlCommand("pa_consultar_mascota", cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());

            cnn.Close();

            foreach (DataRow row in table.Rows)
            {
                Mascota oMascota = new Mascota();
                oMascota.IdMascota = Convert.ToInt32(row["id_mascota"]);
                oMascota.Nombre = row["nombre"].ToString();

                lst.Add(oMascota);
            }

            return lst;
        }


        //public List<Mascota> GetByFiltersMascota(string id_cliente)
        //{
        //    List<Mascota> lst = new List<Mascota>();
            
        //    SqlConnection cnn = new SqlConnection(@"Data Source=localhost;Initial Catalog=Veterinaria_PII;Integrated Security=True");
        //    cnn.Open();
        //    SqlCommand cmd = new SqlCommand("pa_mascota_cliente", cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;
            
        //    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
        //    DataTable dt = new DataTable();

        //    dt.Load(cmd.ExecuteReader());
        //    cnn.Close();



        //    cnn.Close();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Mascota oMascota = new Mascota();
        //        oMascota.IdMascota = Convert.ToInt32(row["id_mascota"]);
        //        oMascota.Nombre = row["nombre"].ToString();
        //        oMascota.Cliente = row["id_cliente"].ToString();

        //        lst.Add(oMascota);
        //    }

        //    return lst;

        //}

        public int GetProximaAtencion()
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("pa_proximo_id", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@next";
            param.SqlDbType = SqlDbType.Int;
            param.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            cnn.Close();

            return (int)param.Value;
        }

        public bool Login(string User, string Password)
        {
            bool b = false;
            SqlConnection cnn = new SqlConnection(@"Data Source=localhost;Initial Catalog=Veterinaria_PII;Integrated Security=True");
            cnn.Open();

            try
            {

                SqlCommand cmd = new SqlCommand("SP_LOGIN", cnn);

                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@USUARIO", User);
                cmd.Parameters.AddWithValue("@CONTRASENA", Password);

                SqlParameter param = new SqlParameter("@USUARIOS", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                if ((int)param.Value == 1) b = true;
            }
            catch (SqlException ex)
            {
                b = false;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) cnn.Close();
            }
            return b;
        }


    }


     
}
