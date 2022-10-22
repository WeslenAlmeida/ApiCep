using ApiCep.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public AddressController()
        {
             //Como no método GetAddress já temos a requisição HTTP, podemos deixar o método construtor vazio
        }

        [HttpGet("{cep}")]
        public ActionResult<string> Get(string cep)
        {
            var address = new AddressService().Main(cep); 

            if (address == null)
                return NotFound();

            return Ok(address.Result);
        }
    }
}
