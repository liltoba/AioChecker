using System;
using System.Threading;
using Colorful;
using System.Drawing;
using System.Diagnostics;
using AuthGG;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text;
using AioChecker.UI;

namespace AioChecker
{
    class Program
    {



        static void Main(string[] args)
        {

            Design.UILogin();
            Colorful.Console.Write("-", Color.Purple);
            Colorful.Console.Write("1");
            Colorful.Console.Write("-", Color.Purple);
            Colorful.Console.Write(" Login");
            Colorful.Console.WriteLine();
            Colorful.Console.Write("-", Color.Purple);
            Colorful.Console.Write("2");
            Colorful.Console.Write("-", Color.Purple);
            Colorful.Console.Write(" Sign up");
            Colorful.Console.WriteLine();
            Colorful.Console.Write("-", Color.Purple);
            Colorful.Console.Write("3");
            Colorful.Console.Write("-", Color.Purple);
            Colorful.Console.Write(" Telegram Channel");
            Colorful.Console.WriteLine();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Option: ");
            string auth = Colorful.Console.ReadLine();

            if (auth == "1")
            {
                Colorful.Console.Clear();
                Program.Dash();

                //remove the program.dash code, then remove the "//" infront of the program.login
                //Program.Login();
            }
            else if (auth == "2")
            {
                Colorful.Console.Clear();
                Program.Signup();
            }
            else if (auth == "3")
            {
                Process.Start("https://t.me/ghoulblack");
            }
            Thread.Sleep(25000);


        }

        public static void Login()
        {
            Colorful.Console.WriteLine();
            Design.UILogin();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("username ");
            string username = Colorful.Console.ReadLine();
            Colorful.Console.WriteLine();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("password ");
            string password = Colorful.Console.ReadLine();
            if (API.Login(username, password))
            {
                Colorful.Console.WriteLine();
                Colorful.Console.Write("Logged in successfully!", Color.Purple);
                Thread.Sleep(1500);
                Program.Dash();

            }
        }

        public static void Signup()
        {
            Colorful.Console.WriteLine();
            Design.UISignup();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Username: ");
            string reguser = Colorful.Console.ReadLine();
            Colorful.Console.WriteLine();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Password: ");
            string regpass = Colorful.Console.ReadLine();
            Colorful.Console.WriteLine();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Email: ");
            string regemail = Colorful.Console.ReadLine();
            Colorful.Console.ReadLine();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("License: ");
            string reglicense = Colorful.Console.ReadLine();
            if (API.Register(reguser, regpass, regemail, reglicense))
            {
                Colorful.Console.WriteLine();
                Colorful.Console.Write("Registered Successfully!", Color.Purple);
                while (Colorful.Console.ReadKey().Key != ConsoleKey.X) { }
                try
                {
                    Program.Dash();
                }
                catch
                {
                    Program.Dash();
                }

            }
        }

        public static void Dash()
        {
            Colorful.Console.WriteLine();
            Design.UIDash();
            Colorful.Console.Write("[", Color.Purple);
            Colorful.Console.Write("1");
            Colorful.Console.Write("] ", Color.Purple);
            Colorful.Console.Write("Modules");
            Colorful.Console.WriteLine();
            Colorful.Console.Write("[", Color.Purple);
            Colorful.Console.Write("2");
            Colorful.Console.Write("] ", Color.Purple);
            Colorful.Console.Write("Proxy Checker");
            Colorful.Console.WriteLine();
            Colorful.Console.Write("[", Color.Purple);
            Colorful.Console.Write("3");
            Colorful.Console.Write("] ", Color.Purple);
            Colorful.Console.Write("Settings");
            Colorful.Console.WriteLine();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("option ");
            string opt = Colorful.Console.ReadLine();
            if (opt == "1")
            {
                Colorful.Console.Clear();
                Program.Modules();
            }
            else if (opt == "2")
            {
                Colorful.Console.Clear();
                Program.ProxyCheck();
            }
            else if (opt == "3")
            {
                Colorful.Console.Clear();
                Program.Settings();
            }




            Thread.Sleep(25000);
        }

        public static int Good { get; set; }
        public static int Bad { get; set; }
        public static void ProxyCheck()
        {
            Colorful.Console.WriteLine();
            Design.UIProxy();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Select a proxy.txt file");
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "txt files (*.txt)|*.txt";
            open.Title = "SexTape - Select a proxy file";
            open.ShowDialog();
            Colorful.Console.Clear();
            string[] proxies = File.ReadAllLines(open.FileName);
            Colorful.Console.WriteLine();
            Design.UIProxy();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Checking Proxies");
            Colorful.Console.WriteLine();
            Colorful.Console.Write("Good: " + Good);
            Colorful.Console.WriteLine();
            Colorful.Console.Write("Bad: " + Bad);
            foreach (string proxy in proxies)
            {
                if (Program.ProxyCheck1(proxy) == true)
                {
                    string append = File.ReadAllText("good_proxies.txt");
                    using (StreamWriter writer = new StreamWriter("good_proxies.txt"))
                    {
                        writer.WriteLine(append + proxy);
                    }
                    Good++;
                }
                else
                {
                    string append1 = File.ReadAllText("bad_proxies.txt");
                    using (StreamWriter writer1 = new StreamWriter("bad_proxies.txt"))
                    {
                        writer1.WriteLine(append1 + proxy);
                    }
                    Bad++;
                }

                Colorful.Console.Clear();
                Design.UIProxy();
                Colorful.Console.Write("- ", Color.Purple);
                Colorful.Console.Write("Checking Proxies");
                Colorful.Console.WriteLine();
                Colorful.Console.Write("Good: " + Good);
                Colorful.Console.WriteLine();
                Colorful.Console.Write("Bad: " + Bad);

            }
            Colorful.Console.Clear();
            Design.UIProxy();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Proxy Results");
            Colorful.Console.WriteLine();
            Colorful.Console.Write(Good + " good proxies saved to " + AppDomain.CurrentDomain.BaseDirectory + "good_proxies.txt");
            Colorful.Console.WriteLine();
            Colorful.Console.Write(Bad + " bad proxies saved to " + AppDomain.CurrentDomain.BaseDirectory + "bad_proxies.txt");
            Colorful.Console.WriteLine();
            Colorful.Console.Write("press X to go back");
            while (Colorful.Console.ReadKey().Key != ConsoleKey.X) { }
            try
            {
                Program.Dash();
            }
            catch
            {
                Program.Dash();
            }
        }

        public static bool ProxyCheck1(string ipAddressport)
        {
            string[] data = ipAddressport.Split(':');
            int port = 0;
            try
            {
                port = int.Parse(data[1]);
            }
            catch
            {
                return false;
            }
            try
            {
                IWebProxy proxy = new WebProxy(data[0], port);
                WebClient wc = new WebClient();
                wc.Timeout = 3500;
                wc.Proxy = proxy;
                wc.Encoding = Encoding.UTF8;
                string result = wc.DownloadString("http://ip-api.com/line/?fields=8192");
                return true;
            }
            catch
            {
                return false;
            }
        }

        private class WebClient : System.Net.WebClient
        {
            public int Timeout { get; set; }
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest lWebRequest = base.GetWebRequest(uri);
                lWebRequest.Timeout = Timeout;
                ((HttpWebRequest)lWebRequest).ReadWriteTimeout = Timeout;
                return lWebRequest;
            }
        }

        public static void Modules()
        {
            Colorful.Console.WriteLine();
            Design.UIModules();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Modules                            Type");

            Colorful.Console.WriteLine();

            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("1 ");
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("DisneyPlus                   [Streaming]");

            Colorful.Console.WriteLine();

            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("2 ");
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Hulu                         [Streaming]");

            Colorful.Console.WriteLine();

            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("3 ");
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Netflix                      [Streaming]");

            Colorful.Console.WriteLine();

            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("4 ");
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("HBO                          [Streaming]");

            Colorful.Console.WriteLine();

            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("5 ");
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("PornHub                      [Porn]");

            Colorful.Console.WriteLine();

            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("6 ");
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Brazzers                     [Porn]");

            Colorful.Console.WriteLine();

            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("7 ");
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("SquareUP                     [Shopping]");

            Colorful.Console.WriteLine();

            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("8 ");
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Venmo                        [Shopping]");

            Colorful.Console.WriteLine();

            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("9 ");
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("Yahoo                        [Mail Access]");

            Colorful.Console.WriteLine();

            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("option ");
            string moduleopt = Colorful.Console.ReadLine();

            if (moduleopt == "1")
            {

            }
            else if (moduleopt == "2")
            {

            }
            else if (moduleopt == "3")
            {

            }
            else if (moduleopt == "4")
            {

            }
            else if (moduleopt == "5")
            {

            }
            else if (moduleopt == "6")
            {

            }
            else if (moduleopt == "7")
            {

            }
            else if (moduleopt == "8")
            {

            }
            else if (moduleopt == "9")
            {

            }



            Thread.Sleep(25000);
        }

        public static void Settings()
        {
            Colorful.Console.WriteLine();
            Design.UIsetting();
            Colorful.Console.Write("- ", Color.Purple);
            Colorful.Console.Write("All User Information");
            Colorful.Console.WriteLine();
            Colorful.Console.WriteLine($"User ID -> {AuthGG.User.ID}");
            Colorful.Console.WriteLine($"Username -> {AuthGG.User.Username}");
            Colorful.Console.WriteLine($"Password -> {AuthGG.User.Password}");
            Colorful.Console.WriteLine($"Email -> {AuthGG.User.Email}");
            Colorful.Console.WriteLine($"User Rank -> {AuthGG.User.Rank}");
            Colorful.Console.WriteLine($"User IP -> {AuthGG.User.IP}");
            Colorful.Console.WriteLine($"Expiry -> {AuthGG.User.Expiry}");
            Colorful.Console.WriteLine($"Last Login -> {AuthGG.User.LastLogin}");
            Colorful.Console.WriteLine($"Register Date -> {AuthGG.User.RegisterDate}");
            Colorful.Console.WriteLine();
            Colorful.Console.Write("Press X to go back", Color.Purple);
            Colorful.Console.WriteLine();
            while (Colorful.Console.ReadKey().Key != ConsoleKey.X) { }
            try
            {
                Program.Dash();
            }
            catch
            {
                Program.Dash();
            }
        }
    }
}
