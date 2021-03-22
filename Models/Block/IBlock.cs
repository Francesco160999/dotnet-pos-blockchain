namespace dotnet_pos_blockchain.Models
{
    public interface IBlock
    {
        long Timestamp { get; }
        string LastHash { get; }
        string tHash { get; }
        string Data { get; }
        string Validator { get; }
        string Signature { get; }
    }
}