namespace ChainBlockify.Application.UseCases.Blockchain.Queries.GetAllBlockchain
{
    public record GetBlockchainListDto(int Id, string Name, List<KeyValuePair<string, string>> Actions)
    {
        public GetBlockchainListDto() : this(0, "", new List<KeyValuePair<string, string>>())
        {
        }
    }
}