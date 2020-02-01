using Discord;
using Discord.Commands;
using Discord.WebSocket;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordGandhiBot.Modules
{
    public class TestModule : ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task TestCommand(string searchTerm = "")
        {
            // Initialize JikanWrapper
            IJikan jikan = new Jikan(true);

            // Send request to search anime with  key word
            AnimeSearchResult animeSearchResult = await jikan.SearchAnime(searchTerm);

            //create embed from the first result
            var embed = new EmbedBuilder
            {
                // Embed property can be set within object initializer
                Title = animeSearchResult.Results.First().Title,
                Description = animeSearchResult.Results.First().Description,
                ImageUrl = animeSearchResult.Results.First().ImageURL,
            };
            await ReplyAsync(embed: embed.Build());
        }
        }
}
