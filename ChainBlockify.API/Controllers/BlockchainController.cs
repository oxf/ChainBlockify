using ChainBlockify.Application.UseCases.Blockchain.Queries.GetAllBlockchain;
using ChainBlockify.Application.UseCases.BlockchainInfo;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo;
using ChainBlockify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var result = await _mediator.Send(new GetBlockchainListQuery());
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Blockchain>> GetById(int Id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("{Id}/fetch")]
        public async Task<ActionResult<BaseBlockchainInfo>> FetchBlockchainInfoById(int Id)
        {
            var result = await _mediator.Send(new FetchBlockchainInfoCommand(Id));
            return Created("/", result);
        }
    }
}
