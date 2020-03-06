using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordGandhiBot.Modules
{
    public class HelperModule : ModuleBase<SocketCommandContext>
    {
        //gets list of current user in the channel


        [Command("help")]
        public async Task HelpCommand(string searchTerm = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("I help you help yourself. Type !help [command] for help on a specific command.");

            
            sb.AppendLine("See below for list of commands:");
            sb.AppendLine();
            sb.AppendLine("------------------------------------");
            //Add new commands here
            sb.AppendLine("?nuke");
            sb.AppendLine("?pizzatime");
            sb.AppendLine("?anime");

            var embed = new EmbedBuilder
            {
                // Embed property can be set within object initializer
                Title = "Help",
                Description = sb.ToString()
            };

            Random rnd = new Random();
            Color randomColor = new Color(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));

            switch (searchTerm)
            {
                case "nuke":
                    embed.WithColor(randomColor)
                         .WithTitle("?nuke [username]")
                         .WithDescription("Nukes the user passed in as a parameter (Sends a @mention). Must be a valid username.");
                    break;
                case "pizzatime":
                    embed.WithColor(randomColor)
                        .WithTitle("?pizzatime [username] (optional)")
                        .WithDescription("IT'S PIZZA TIME!");
                    break;
                case "anime":
                    embed.WithColor(randomColor)
                        .WithTitle("?anime [searchTerm] (optional)")
                        .WithDescription("Displays general information about an anime based on search term. ");
                    break;
                default:
                    break;
            }

            //Your embed needs to be built before it is able to be sent
            await ReplyAsync(embed: embed.Build());
        }
    }
}
