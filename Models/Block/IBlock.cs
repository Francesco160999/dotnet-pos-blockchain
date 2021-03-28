using System.Collections.Generic;
using dotnet_pos_blockchain.Models.Transaction;

namespace dotnet_pos_blockchain.Models
{
    public interface IBlock
    {
        long Timestamp { get; }
        string LastHash { get; }
        string Hash { get; }
        List<ITransaction> Transactions { get; }
        string Validator { get; }
        string Signature { get; }
    }
}