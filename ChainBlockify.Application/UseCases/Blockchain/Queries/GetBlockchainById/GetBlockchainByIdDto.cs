namespace ChainBlockify.Application.UseCases.Blockchain.Queries.GetBlockchainById
{
    public record GetBlockchainByIdDto(int Id,
        string Name,
        List<KeyValuePair<string, string>> Actions)
    {
        public GetBlockchainByIdDto(): this(0, "", null)
        {

        }
    }
}