using System;
using Volanteer.BlockchainClient.P2P;
using Volunteer.BlockChain;

namespace Volanteer.BlockchainClient
{
    class Program
    {
        public static Blockchain blockchain = new Blockchain();

        static void Main(string[] args)
        {
            var server = new P2PServer();
            var client = new P2PClient();
            var resp = Console.ReadLine();
            if (Uri.IsWellFormedUriString(resp, UriKind.Absolute))
            {
                blockchain.AddGenesisBlock();
                client.Connect(resp);
            }
            else if (int.TryParse(resp, out var port))
            {
                server.Start(port);
            }
            Console.ReadLine();
        }
    }
}
