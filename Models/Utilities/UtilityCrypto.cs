using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using dotnet_pos_blockchain.Models.Transaction;

namespace dotnet_pos_blockchain.Models.Utilities
{
    public static class UtilityCrypto
    {
        public static string Hash(long timestamp, string lastHash, List<ITransaction> data)
        {
            using (SHA256 uSHA256 = SHA256.Create())
            {
                return uSHA256.ComputeHash(Encoding.ASCII.GetBytes($"{timestamp}{lastHash}{data}")).ToString();
            }
        }

        public static string BlockHash(Block block)
        {
            long timestamp = block.Timestamp;
            string lastHash = block.LastHash;
            List<ITransaction> data = block.Transactions;

            return Hash(timestamp, lastHash, data);
        }

        public static Block GenerateBlock(IBlock previusBlock, List<ITransaction> transactions, string publicKey, string signature)
        {
            long timestamp = DateTime.Now.Ticks;
            string hash = UtilityCrypto.Hash(timestamp, previusBlock.LastHash, transactions);
            return new()
            {
                Timestamp = timestamp,
                LastHash = previusBlock.Hash, 
                Hash = hash,
                Transactions = transactions,
                Validator = publicKey,
                Signature = signature
            };
        }

    }
}