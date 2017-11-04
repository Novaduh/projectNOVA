using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNOVAE
{
    public class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();
        
        DiscordSocketClient _client;
        CommandService _commands;
        Random rand;
        string[] pics;

        public async Task MainAsync()
        {
            rand = new Random();
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _client.Log += Log;
            _client.MessageReceived += CommandReceived;
            
            string token = "Mzc1NDE0MzY2MDY3MjI4Njcz.DN0G3Q.wa6_2AiKmL1OZH5yTr1Sy1aVpn4";
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            
            await Task.Delay(-1);

        }
        private async Task CommandReceived(SocketMessage message)
        {
            if (message.Content == "a")
            {
                float rng = rand.Next(10);
                
                await message.Channel.SendMessageAsync("IM ALIVE");

            }
            string sentence = Console.ReadLine();
            await message.Channel.SendMessageAsync(sentence);

            if (message.Content == "deactivateNOVA")
            {
                await message.Channel.SendMessageAsync("SHUTTING DOWN");
            }
            
        }


        public Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            
            return Task.CompletedTask;
        }
    }
}
