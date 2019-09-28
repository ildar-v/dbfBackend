using System;
using System.Collections.Generic;
using System.Linq;

namespace Volunteer.BlockChain
{
    public class Blockchain
    {
        public Blockchain()
        {
            chain = new List<Block>();
        }

        private List<Block> chain;
        private const int difficulty = 2;

        public List<Block> Chain { get { return chain; } }

        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public void AddGenesisBlock()
        {
            if (Chain.Any(b => string.IsNullOrWhiteSpace(b.PreviousHash)))
            {
                return;
            }
            Chain.Add(new Block(DateTime.Now, null, null));
        }

        public void AddBlock(Block block)
        {
            block.Index = Chain[Chain.Count - 1].Index + 1;
            block.Mine(difficulty);
            Chain.Add(block);
        }

        public bool Validation()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                var currentBlock = Chain[i];
                var previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }
                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
