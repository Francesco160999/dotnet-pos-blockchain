using System.Collections.Generic;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using dotnet_pos_blockchain.Models.Transaction;

namespace dotnet_pos_blockchain.Models
{
    public class Block : IBlock {
        public long Timestamp { get; private set; }
        public string LastHash { get; private set; }
        public string tHash { get; private set; } 
        public List<ITransaction> Transactions { get; private set; }
        public string Validator { get; private set; }
        public string Signature { get; private set; }

        public Block(
            long    timestamp,
            string  lastHash,
            string  hash,
            List<ITransaction>  transactions,
            string  validator,
            string  signature ){
                Timestamp = timestamp;
                LastHash = lastHash;
                tHash = hash;
                Transactions = transactions;
                Validator = validator;
                Signature = signature;
            } 
        
        /*static Block Genesis() {
            return new Block("genesis time", "----", "genesis-hash", []);
        }*/

        public static byte[] Hash(long timestamp, string lastHash, List<ITransaction> data){
            using (SHA256 uSHA256 = SHA256.Create()){
                return uSHA256.ComputeHash(Encoding.ASCII.GetBytes($"{timestamp}{lastHash}{data}"));
            }
        }

        public static byte[] BlockHash(Block block){
            long timestamp = block.Timestamp;
            string lastHash = block.LastHash;
            List<ITransaction> data = block.Transactions;

            return Hash(timestamp, lastHash, data);
        }

        public override string ToString(){
            return $"";
        }

    }
}