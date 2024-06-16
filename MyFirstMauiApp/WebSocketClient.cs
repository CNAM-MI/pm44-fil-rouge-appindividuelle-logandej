using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using SocketIOClient;


namespace MyFirstMauiApp
{
    public class WebSocketClient
    {
        public WebSocketClient() {

            Task.Run(() => Task.FromResult(Start()));       
        
        }
        private async Task Start()
        {
            Console.WriteLine("CONNECTion TO SERVER");
            string serverUri = "http://84.235.235.229:3000/"; // Remplacez ceci par votre adresse IP et port

            try
            {
                
                var client = new SocketIOClient.SocketIO(serverUri);
                Console.WriteLine("Start WAIt");

                
                Console.WriteLine("CONNECTED TO SERVER");

                client.OnConnected += async (sender, e) =>
                {
                    Console.WriteLine("ForSureConnected");
                    await Task.Delay(0);
                };

                await client.ConnectAsync();
                Console.WriteLine("client = "+client);

                await client.EmitAsync("talktome", new { message = "Retourne dans ton pays sale  arabe !" });

                client.On("hi", response =>
                {
                    // You can print the returned data first to decide what to do next.
                    // output: ["hi client"]
                    Console.WriteLine(response);

                    string text = response.GetValue<string>();

                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed"+ex.Message);
            }
        }
    }
}
