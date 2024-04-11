using ChainBlockify.Application.UseCases.BlockchainInfo;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo;
using ChainBlockify.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChainBlockify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockchainController(
        IMediator _mediator
        ): ControllerBase
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
        [HttpPost("{Id}/fetch")]
        public async Task<ActionResult<BaseBlockchainInfo>> FetchBlockchainInfoById(int Id)
        {
            return Ok(_mediator.Send(new FetchBlockchainInfoCommand(Id)));
        }
    }
}
