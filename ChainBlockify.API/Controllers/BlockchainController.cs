using ChainBlockify.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ChainBlockify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockchainController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blockchain>>> Get()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Blockchain>> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
