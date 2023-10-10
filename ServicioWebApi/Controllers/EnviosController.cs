using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioWebApi.Interfaces;
using ServicioWebApi.Models;

namespace ServicioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IShipper _shipper;

        public EnviosController(IShipper shipper)
        {
            _shipper = shipper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Shipper>>> GetAll()
        {
            return await _shipper.TraerTodos();
        }
    }
}
