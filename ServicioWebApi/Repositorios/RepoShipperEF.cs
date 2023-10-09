using Microsoft.EntityFrameworkCore;
using ServicioWebApi.Data;
using ServicioWebApi.Interfaces;
using ServicioWebApi.Models;

namespace ServicioWebApi.Repositorios
{
    public class RepoShipperEF : IShipper
    {
        private readonly NorthwindContext _Contexto;

        public RepoShipperEF(NorthwindContext contexto)
        {
            _Contexto = contexto;
        }

        public async Task<Shipper> Actualizar(Shipper entidad)
        {
            _Contexto.Shippers.Update(entidad);
            await _Contexto.SaveChangesAsync();
            return entidad;
        }

        public async Task<Shipper> Agregar(Shipper entidad)
        {
            _Contexto.Shippers.Add(entidad);
            await _Contexto.SaveChangesAsync();
            return entidad;
        }

        public async Task<Shipper> Borrar(int id)
        {
            var ship= await _Contexto.Shippers.FindAsync(id);
            _Contexto.Shippers.Remove(ship);
            await _Contexto.SaveChangesAsync();
            return ship;
        }

        public async Task<List<Shipper>> TraerTodos()
        {
            var shipper = from sh in _Contexto.Shippers
                          select sh;
            return await shipper.ToListAsync();
        }

        public async Task<Shipper> TraerUno(int id)
        {
            var ship = await _Contexto.Shippers.FindAsync(id);
            return ship;
        }
    }
}
