using System.Collections.Generic;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using dotnet_pos_blockchain.Models.Transaction;

namespace dotnet_pos_blockchain.Models
{
    public class Block : IBlock
    {
        public long Timestamp { get; init; }
        public string LastHash { get; init; }
        public string Hash { get; init; }
        public List<ITransaction> Transactions { get; init; }
        public string Validator { get; init; }
        public string Signature { get; init; }

        public override string ToString()
        {
            return $"";
        }

    }
}