using Microsoft.Data.SqlClient;
using ServicioWebApi.Interfaces;
using ServicioWebApi.Models;

namespace ServicioWebApi.Repositorios
{
    public class RepoShipperADO : IShipper
    {
            string strCadena;
            public RepoShipperADO(IConfiguration confi)
            {
                strCadena = confi.GetConnectionString("CadenaActual").ToString();
            }
            public Task<Shipper> Actualizar(Shipper entidad)
            {
                throw new NotImplementedException();
            }

            public Task<Shipper> Agregar(Shipper entidad)
            {
                throw new NotImplementedException();
            }

            public Task<Shipper> Borrar(int id)
            {
                throw new NotImplementedException();
            }

            public async Task<List<Shipper>> TraerTodos()
            {
                string strSQL = "select * from shippers";
                SqlConnection con = new SqlConnection(strSQL);
                SqlCommand comm = new SqlCommand(strSQL, con);
                List<Shipper> list = new List<Shipper>();
                SqlDataReader drShipper;
                con.Open();
                drShipper = comm.ExecuteReader();
                
                while (drShipper.Read())
            {
                Shipper sh = new Shipper();
                sh.ShipperID = Convert.ToInt32(drShipper["ShipperID"]);
                sh.CompanyName = drShipper["CompanyName"].ToString();
                sh.Phone = drShipper["Phone"].ToString();
                list.Add(sh);
            }
                return list;
            }

            public Task<Shipper> TraerUno(int id)
            {
                throw new NotImplementedException();
            }
    }
}
