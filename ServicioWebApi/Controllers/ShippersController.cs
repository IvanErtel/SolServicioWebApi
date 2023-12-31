﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioWebApi.Data;
using ServicioWebApi.Models;

namespace ServicioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly NorthwindContext _Contexto;

        public ShippersController(NorthwindContext contexto)
        {
            _Contexto = contexto;
        }

        //CRUD
        [HttpGet]

        public async Task<ActionResult<List<Shipper>>> TraerTodos()
        {
            var listaShippers = (from sh in _Contexto.Shippers
                                 select sh).ToListAsync();
            return await listaShippers;
        }

        //Traer por ID
        [HttpGet("{id}")]

        public async Task<ActionResult<Shipper>> TraerUno(int id)
        {
            var shipper = await _Contexto.Shippers.FindAsync(id);
            if (shipper == null)
            {
                return NotFound(); //Error 404 SI NO ENCUENTRA ID
            }
            else
            {
                return Ok(shipper); //RETORNA OBJETO + Status 200 (OK)
            }
        }

        [HttpPost]

        public async Task<ActionResult> Agregar(Shipper shipper)
        {
            _Contexto.Shippers.Add(shipper); //agrega a la coleccion
            await _Contexto.SaveChangesAsync();// aplica el insert
            return Ok(shipper);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Actualizar(int id, Shipper shipper)
        {
            if (id!=shipper.ShipperID)
            {
                return BadRequest(); //400
            }
            _Contexto.Shippers.Update(shipper); //actualiza

            try
            {
                await _Contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NoContent(); //codigo 204
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Borrar(int id)
        {
            var shipBorrar = await _Contexto.Shippers.FindAsync(id);
            if (shipBorrar == null)
            {
                return NotFound();
            }
            _Contexto.Shippers.Remove(shipBorrar);
            await _Contexto.SaveChangesAsync();
            return Ok();
        }
    }
}
