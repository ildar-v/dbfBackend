using Newtonsoft.Json;
using System;
using Volunteer.BlockChain;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Volanteer.BlockchainClient.P2P
{
    public class P2PServer : WebSocketBehavior
    {
        private WebSocketServer wss = null;
        private bool chainSynched = false;

        public void Start(int port)
        {
            wss = new WebSocketServer($"ws://127.0.0.1:{port}");
            wss.AddWebSocketService<P2PServer>("/Blockchain");
            wss.Start();
            Console.WriteLine($"Started server at ws://127.0.0.1:{port}");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.Data == "Hi Server")
            {
                Console.WriteLine(e.Data);
                Send("Hi Client");
            }
            else
            {
                Blockchain newChain = JsonConvert.DeserializeObject<Blockchain>(e.Data);

                if (newChain.Validation() && newChain.Chain.Count > Program.blockchain.Chain.Count)
                {
                    Program.blockchain = newChain;
                }

                if (!chainSynched)
                {
                    Send(JsonConvert.SerializeObject(Program.blockchain));
                    chainSynched = true;
                }
            }
        }

    }
}
