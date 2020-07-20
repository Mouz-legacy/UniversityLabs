using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace Bot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        private int _countMembers = 0;
        [Command("ping")]//Команды для бота
        public async Task Ping()
        {
            await ReplyAsync("Pong").ConfigureAwait(false) ;
        }

        [Command("cuntsearch")]
        public async Task Fool()
        {

            await ReplyAsync("You are fool").ConfigureAwait(false);
        }

        //Tempban
        //Slay(kick)
        //!play(music from youtube)
        //rshit(random shit with server)
        //Надо придумать новое название(name will be : multitool


    }
}
