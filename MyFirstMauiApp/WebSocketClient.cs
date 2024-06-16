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
            Console.WriteLine("CONNECTION TO SERVER");
            string serverUri = "http://84.235.235.229:3000/";

            try
            {
                var client = new SocketIOClient.SocketIO(serverUri);

                await client.ConnectAsync();
                Console.WriteLine("client = "+client);

                //Envoi du message "Talk To Me" au serveur
                await client.EmitAsync("talktome", new { message = "Je suis connecté !" });

                //Ecoute la réponse "hi" du serveur
                client.On("hi", response =>
                {
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
