using api.eavila.cuentas.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Service;

namespace api.eavila.cuentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : Controller
    {
        private OperacionesServices operacionesService;

        private IConfiguration configuration;
        public OperacionesController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.operacionesService = new OperacionesServices(configuration.GetConnectionString("postgresDB"));

        }



        [HttpPut("depositar/{id}")]
        public ActionResult<string> depositar( double saldo , int id)
        {
         
                var resultado = this.operacionesService.depositar(saldo, id);

                return Ok(resultado);

        }

        [HttpPut("retirar/{id}")]
        public ActionResult<string> retirar(double saldo, int id)
        {

            var resultado = this.operacionesService.retirar(saldo, id);

            return Ok(resultado);


        }

    }
}
