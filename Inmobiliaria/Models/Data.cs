using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Data
    {

      public List<Propietario> ObtenerPropietarios()
        {
            List<Propietario> res = new List<Propietario>();
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBInmobiliaria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            String sql = "SELECT * FROM Propietarios";
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Propietario p = new Propietario
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader[nameof(p.FirstName)].ToString(),
                    LastName = reader[nameof(p.LastName)].ToString(),
                    Email = reader[nameof(p.Email)].ToString(),
                    Pass = reader[nameof(p.Pass)].ToString(),
                };
                res.Add(p);
            }
            conn.Close();

            return res;
        }

    }
}
