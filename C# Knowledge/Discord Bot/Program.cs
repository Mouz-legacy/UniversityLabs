using System;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Bot
{
    class Program
    {
        #region - FIELDS -

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        #endregion

        #region -DiscrodBot Methods-

        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();
        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();
            string token = "NzMwMTU4OTc5MTk5Nzk1MjYx.XwXx3g.LzneDPARkyj-B94Iy3r6s5NxHjo";
            _client.Log += _client_Log;
            await RegisterCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
         
        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot) return;

            int argPos = 0;
            if(message.HasStringPrefix("!", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if(!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }

        #endregion


    }
}
