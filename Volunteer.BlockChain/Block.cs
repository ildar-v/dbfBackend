using System;
using System.Security.Cryptography;
using System.Text;

namespace Volunteer.BlockChain
{
    public class Block
    {
        #region private members

        private DateTime timeStamp;
        private string previousHash;
        private string hash;
        private object data;
        private int nonce = 0;

        #endregion

        public Block(DateTime timeStamp, string previousHash, object data)
        {
            this.Index = 0;
            this.timeStamp = timeStamp;
            this.previousHash = previousHash;
            this.data = data;
        }

        public int Index { get; set; }

        public DateTime TimeStamp { get { return timeStamp; } }

        public string PreviousHash { get { return previousHash; } }

        public string Hash { get { return hash; } }

        public object Data { get { return data; } }

        public string CalculateHash()
        {
            var sha256 = SHA256.Create();
            byte[] input = Encoding.ASCII.GetBytes($"{TimeStamp} - {previousHash ?? string.Empty} - {data} - {nonce}");
            byte[] output = sha256.ComputeHash(input);
            return Convert.ToBase64String(output);
        }

        public void Mine(int difficulty)
        {
            var leadingZeros = new string('0', difficulty);
            while (this.Hash == null || this.Hash.Substring(0, difficulty) != leadingZeros)
            {
                nonce++;
                hash = this.CalculateHash();
            }
        }
    }
}
