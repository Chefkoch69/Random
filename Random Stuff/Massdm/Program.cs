using Discord;
using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Massdm
{
    class Program
    {
        static void Main(string[] args)
        {
            DiscordSocketClient client = new DiscordSocketClient();

            Console.Write(" token : ");

            string token = Console.ReadLine();


            client.OnLoggedIn += Client_OnLoggedIn;

            Thread.Sleep(-1);
        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Console.Write(" Guild : ");

            string guild = Console.ReadLine();



            foreach(var idk in client.GetGuildMembers(Convert.ToUInt64(guild)))
            {

            }


        }
    }
}
