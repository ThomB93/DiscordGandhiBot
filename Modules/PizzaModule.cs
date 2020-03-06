using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordGandhiBot.Modules
{
    public class PizzaModule : ModuleBase<SocketCommandContext>
    {
        [Command("pizzatime")]
        public async Task PizzaTime([Remainder]string user) //optional parameter
        {
            Console.WriteLine(user);
            string currentTime = DateTime.Now.ToLongTimeString();
            var sb = new StringBuilder();

            string[] pizzaTimeGifUrls = new[]
            {
                "https://media1.tenor.com/images/220c7dae8b7c341110458d87acef7958/tenor.gif?itemid=14345580",
                "https://media1.tenor.com/images/87437507dd4c3d3921a2d7339b53e089/tenor.gif?itemid=9408677"
            };

            //StringBuilder builder = new StringBuilder();
            //foreach (string value in stringArray)
            //{
            //    builder.Append(value);
            //    builder.Append(' ');
            //}
            //string inputString = builder.ToString();
            //Console.Write(inputString);

            var users = Context.Guild.Users;

            string mention = string.Empty;

            if (user == "noUser")
            {
                sb.AppendLine("THE TIME IS " + currentTime + " AND IT´S PIZZA TIME!!!");
            }

            foreach (var item in users)
            {
                if (item.Username == user || item.Mention.ToString() == user || item.Nickname == user)
                {
                    mention = item.Mention;
                    sb.AppendLine(mention + "THE TIME IS " + currentTime + " AND IT´S PIZZA TIME!!!");

                    break;
                }
            }

            //select random gif from string array
            Random r = new Random();
            string randomGifUrl = pizzaTimeGifUrls[r.Next(0, pizzaTimeGifUrls.Length-1)];

            //sb.AppendLine("PIZZA TIME!");
            await ReplyAsync(sb.ToString(), false);
            await Context.Channel.SendMessageAsync(randomGifUrl);
        }
    }
}
