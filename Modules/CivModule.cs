using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordGandhiBot.Modules
{
    public class CivModule : ModuleBase<SocketCommandContext>
    {
        //gets list of current user in the channel
        

        [Command("nuke")]
        public async Task NukeCommand(string user)
        {
            // initialize empty string builder for reply
            var sb = new StringBuilder();
            List<string> mentions = new List<string>();

            // get user info from the Context
            var users = Context.Guild.Users;

            //foreach (var u in users)
            //{
            //    Console.WriteLine(u.Username);
            //}

            string mention = string.Empty;
            var embed = new EmbedBuilder();

            foreach (var item in users)
            {
                if(item.Username == user)
                {
                    mention = item.Mention;
                    sb.AppendLine(mention + " has been nuked!");

                    break;
                }
            }

            if(mention == string.Empty)
            {
                sb.AppendLine("User does not exist.");
                return;
            }

            // send simple string reply
            await ReplyAsync(sb.ToString(), false);
            await Context.Channel.SendFileAsync(@"C:\Users\thomb\Source\Repos\DiscordGandhiBot\Resources\nuke.gif");
        }

        //Helper Command
        [Command ("listUsers")]

        public async Task ListUsersCommand()
        {
            var users = Context.Guild.Users;
            var sb = new StringBuilder();

            foreach (var u in users)
            {
                sb.AppendLine(u.Username);
            }
            await ReplyAsync(sb.ToString(), false);
        }
        [Command("randomUser")]

        public async Task RandomUserCommand()
        {
            var users = Context.Guild.Users;
            var sb = new StringBuilder();

            Random r = new Random();
            int randomUserIndex = r.Next(0, users.Count);
            string randomUser = users.ElementAtOrDefault(randomUserIndex).Username;
            await ReplyAsync(randomUser, false);
        }
    }
}
