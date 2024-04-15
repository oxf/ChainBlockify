using ChainBlockify.Application.UseCases.Blockchain.Queries.GetAllBlockchain;
using ChainBlockify.Application.UseCases.Blockchain.Queries.GetBlockchainById;
using ChainBlockify.Application.UseCases.BlockchainInfo;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.ResolveBlockchainInfo;
using ChainBlockify.Application.UseCases.BlockchainInfo.Queries.GetBlockchainInfoListByBlockchainId;
using ChainBlockify.Domain.Entities;
using ChainBlockify.Domain.Exceptions;
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
        /// <summary>
        /// Get list of available blockchains
        /// </summary>
        /// <returns>List of blockchains</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blockchain>>> Get()
        {
            var result = await _mediator.Send(new GetBlockchainListQuery());
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Blockchain>> GetById(int Id)
        {
            try
            {
                var result = await _mediator.Send(new GetBlockchainByIdQuery(Id));
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Page"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet("{Id}/info")]
        public async Task<ActionResult<List<BaseBlockchainInfo>>> GetBlockchainInfoListByBlockchainId(int Id, [FromQuery] int PageNumber = 0, [FromQuery] int PageSize = 10)
        {
            try
            {
                var result = await _mediator.Send(new GetResolveBlockchainInfoListByBlockchainIdQuery(Id, PageNumber, PageSize));
                return Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Fetch blockchain info and save it into database
        /// </summary>
        /// <param name="Id">Blockchain Id</param>
        /// <returns>The created BlockchainInfo entity</returns>
        [HttpPost("{Id}/fetch")]
        public async Task<ActionResult<BaseBlockchainInfo>> FetchBlockchainInfoById(int Id)
        {
            try
            {
                var result = await _mediator.Send(new ResolveBlockchainInfoCommand(Id));
                return Created($"/{result.Id}", result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
