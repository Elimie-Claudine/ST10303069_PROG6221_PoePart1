using NAudio.Wave;

namespace ST10303069_PoePart1_PROG6221
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
                                                                 
                                                                               
  .--.--.       ,---,.                            ,---,.               ___     
 /  /    '.   ,'  .' |                          ,'  .'  \            ,--.'|_   
|  :  /`. / ,---.'   |                   ,--, ,---.' .' |   ,---.    |  | :,'  
;  |  |--`  |   |   .'                 ,'_ /| |   |  |: |  '   ,'\   :  : ' :  
|  :  ;_    :   :  |-,   ,---.    .--. |  | : :   :  :  / /   /   |.;__,'  /   
 \  \    `. :   |  ;/|  /     \ ,'_ /| :  . | :   |    ; .   ; ,. :|  |   |    
  `----.   \|   :   .' /    / ' |  ' | |  . . |   :     \'   | |: ::__,'| :    
  __ \  \  ||   |  |-,.    ' /  |  | ' |  | | |   |   . |'   | .; :  '  : |__  
 /  /`--'  /'   :  ;/|'   ; :__ :  | : ;  ; | '   :  '; ||   :    |  |  | '.'| 
'--'.     / |   |    \'   | '.'|'  :  `--'   \|   |  | ;  \   \  /   ;  :    ; 
  `--'---'  |   :   .'|   :    ::  ,      .-./|   :   /    `----'    |  ,   /  
            |   | ,'   \   \  /  `--`----'    |   | ,'                ---`-'   
            `----'      `----'                `----'                           
                                                                               
                                                                             
                                                                                           

     ");
            Console.ResetColor();


            using (var audioFile = new AudioFileReader("greetings.wav"))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(100); // wait for audio to finish
                }

            }

            Console.WriteLine("Before we start, enter your name please >> ");
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
          _________________________________");
            Console.WriteLine(@" <  Welcome, " + name + "!                >");
            Console.WriteLine(@" <  Nice meeting you, I'm SecuBot.     >
        <  I will be your guide            >
        <  through this cybersecurity     >
        <  journey. Just ask if you need help ! >
         ---------------------------------
         \     
          \    [SecuBot_2025]
           \   \_/
            .-(_)-.
           | 0   0 |
           |   ^   | 
           |  '-'  |
           +-------+
        ");

            Console.ResetColor();



            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                ColoredText("╭─────────────────────────────╮", ConsoleColor.Green);
                ColoredText("│ Ask your cybersecurity question │", ConsoleColor.Yellow);
                ColoredText("╰─────────────────────────────╯", ConsoleColor.DarkBlue);
                Console.Write("Your question : ");

                string input = Console.ReadLine();

                input = input.ToLower();

                if (input.Contains("exit"))
                {
                    TypeEffect("Thank you for reaching out. Goodbye!", ConsoleColor.Magenta);
                    break;
                }
                Responses(input);


            }




            static void Responses(string input)
            {
                Dictionary<string, string> responses = new Dictionary<string, string>()
        {
            { "how are you", "I'm doing great, and I hope you too ! Let me know if you need advices to stay protected online." },
            { "what's your purpose", "My role is to teach you how to stay safe online." },
            { "what can I ask you about", "You can ask me anything related to online safety." },
            { "password", "Use strong, unique passwords (more than 12 characters long, containing alphanumerics and symbols." },
            { "phishing", "Stay safe online by being cautious with links, never sharing personal information on untrusted websites, ignoring pop-up messages, and avoiding opening suspicious files." },
            { "browsing", "Use secure connections (HTTPS), be careful with links, especially from unknown sources. Don't share personal info on websites you don't trust. Ignore pop-ups and be wary of suspicious documents. Use strong passwords and keep your software updated." }
        };

                List<string> keys = new List<string>(responses.Keys);
                bool validInput = false;

                for (int i = 0; i < keys.Count; i++)
                {
                    if (input.Contains(keys[i]))
                    {
                        Console.WriteLine("SecuBot: " + responses[keys[i]], ConsoleColor.Magenta);
                        validInput = true;
                        break;
                    }
                }

                if (!validInput)
                {
                    ColoredText("SecuBot: I didn't quite understand that. Please, rephrase or type 'exit' to close SecuBot.", ConsoleColor.Red);
                }
            }
        }

        static void TypeEffect(string text, ConsoleColor color = ConsoleColor.White, int delay = 25)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        static void ColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

    }
}
