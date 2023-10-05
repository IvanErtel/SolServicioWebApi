using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioWebApi.Data;

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
    }
}
