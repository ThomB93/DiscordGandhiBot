using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
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

            //TODO - Get mention of user being passed, else respond with user doesnt exist

            // get user info from the Context
            var users = Context.Guild.Users;
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
            await Context.Channel.SendFileAsync(@"C:\Users\thomb\Documents\VSStudio2019\DiscordGandhiBot\Resources\nuke.gif");
        }
    }
}
