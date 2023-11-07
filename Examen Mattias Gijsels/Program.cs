namespace Examen_Mattias_Gijsels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Running = true;
            decimal kamertemp = 15M;
            decimal gewenstetemp = 0;
            int luchtvochtigheid = 80;
            decimal keteldruk = 2.5M;
            double werkingstemperatuur = 21D;

            while (Running)
            {
                Console.WriteLine("Hallo gebruiker, wat wilt u doen?");
                Console.WriteLine("");
                string cmd = Console.ReadLine() ?? "";
                switch (cmd.ToLower())
                {

                    case "set":

                        Console.WriteLine("Typ de volgende waarden in de console");
                        gewenstetemp = GetWantedTemp();
                        kamertemp = GetCurrentTemp();
                        luchtvochtigheid = GetInputHumid();
                        keteldruk = GetPressKet();
                        OnOrOff(kamertemp, gewenstetemp, keteldruk, luchtvochtigheid);
                        break;

                    case "info":
                        Console.WriteLine("U heeft de volgende waarden ingegeven");
                        GetInfo(kamertemp, gewenstetemp, keteldruk, luchtvochtigheid);

                        break;

                    case "run":
                        Console.WriteLine("Hieronder volgt het resultaat");
                        CodeRun(kamertemp, gewenstetemp, keteldruk, luchtvochtigheid);
                        break;

                    case "default":
                        Reset(kamertemp, gewenstetemp, keteldruk, luchtvochtigheid);

                        break;

                    default:
                        Error($"Dit commando '{cmd}' is niet gekend");
                        break;

                }



            }

            static void GetInfo(decimal kamertemp, decimal gewenstetemp, decimal keteldruk, decimal luchtvochtigheid)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Huidige kamertemperatuur: " + kamertemp.ToString("F2") + "°");
                Console.WriteLine("Huidige gewenste temperatuur: " + gewenstetemp.ToString("F2") + "°");
                Console.WriteLine("Huidige luchtvochtigheid: " + luchtvochtigheid.ToString("F2") + "%");
                Console.WriteLine("Huidige keteldruk: " + keteldruk.ToString("F2") + " bar");
                Console.WriteLine("--------------------------------------------");
            }

            static void OnOrOff(decimal kamertemp, decimal gewenstetemp, decimal keteldruk, decimal luchtvochtigheid, string onMsg = "De Boiler wordt aangezet", string teWarm = "\"Vanwege veiligheids redenen sluit de boiler zichzelf af\"")
            {
                if (((kamertemp - 2) < gewenstetemp) && ((keteldruk >= 2) && (keteldruk <= 3)) && (luchtvochtigheid < 90) || (gewenstetemp < kamertemp))
                {
                    On(onMsg);
                }
                else
                {
                    Error(teWarm);
                }

            }

            static decimal GetPressKet(string msg = "Geef de keteldruk  in", string errorMsg = "Het ingegeven getal behoort niet tot de veiligheidsnormen, het toestel wordt afgesloten")
            {
                decimal userinput = 0;
                Console.Write($"{msg} : ");
                string input = Console.ReadLine() ?? "";
                if (decimal.TryParse(input, out userinput))

                {
                    return userinput;
                }

                Error(errorMsg);
                return 0;

            }

            static decimal GetCurrentTemp(string msg = "Wat is de huidige kamertemperatuur?", string errorMsg = "Dit is niet mogelijk")
            {
                decimal userinput = 0;
                Console.Write($"{msg} : ");
                string input = Console.ReadLine() ?? "";
                if (decimal.TryParse(input, out userinput))

                {
                    return userinput;
                }

                Error(errorMsg);
                return 0;

            }

            static int GetInputHumid(string msg = "Geef de luchtvochtigheid in", string errorMsg = "Dit getal kan niet kan niet over 100 zijn")
            {
                int userinput = 0;
                Console.Write($"{msg} : ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out userinput))
                {
                    return userinput;
                }
                Error(errorMsg);
                return 0;
            }

            static decimal GetWantedTemp(string msg = "De gewenste kamertemperatuur?", string errorMsg = "Dit is niet mogelijk")
            {
                decimal userinput = 0;
                Console.Write($"{msg} : ");
                string input = Console.ReadLine() ?? "";
                if (decimal.TryParse(input, out userinput))
                {
                    return userinput;
                }
                Error(errorMsg);
                return 0;

            }
            static void CodeRun(decimal kamertemp, decimal gewenstetemp, decimal keteldruk, decimal luchtvochtigheid)
            {

                decimal q = 0.2M;
                decimal x = 0.5M;
                for (decimal i = kamertemp; i <= gewenstetemp; i += q, luchtvochtigheid -= x)
                {
                    Console.WriteLine("De huidige temperatuur is: " + i.ToString("F2") + "° en deluchtvochtigheid is: " + luchtvochtigheid.ToString("F2") + "%");
                    if (i == gewenstetemp)
                    {
                        LetsGo("De gewenste temperatuur van " + gewenstetemp + "° is bereikt") ;
                    }
                }
            }


            static void Error(string message, ConsoleColor errorColor = ConsoleColor.Red)
            {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = errorColor;
                Console.WriteLine(message);
                Console.ForegroundColor = oldColor;
            }
            static void On(string message, ConsoleColor errorColor = ConsoleColor.Blue)
            {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = errorColor;
                Console.WriteLine(message);
                Console.ForegroundColor = oldColor;
            }
            static void LetsGo(string message, ConsoleColor errorColor = ConsoleColor.Green)
            {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = errorColor;
                Console.WriteLine(message);
                Console.ForegroundColor = oldColor;
            }

        }

        private static void Reset(decimal kamertemp, decimal gewenstetemp, decimal keteldruk, int luchtvochtigheid)
        {
            throw new NotImplementedException();
        }
    }
}

