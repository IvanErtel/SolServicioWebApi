using ServicioWebApi.Models;

namespace ServicioWebApi.Interfaces
{
    public interface IShipper
    {
        Task<List<Shipper>> TraerTodos();
        
        Task<Shipper> TraerUno(int id);

        Task<Shipper> Agregar(Shipper entidad);

        Task<Shipper> Actualizar(Shipper entidad);

        Task<Shipper> Borrar(int id);
    }
}
