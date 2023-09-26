namespace HangMan; // here use name of your project

class Program
{
    // No variable declarations in this area!!
    static void Main(string[] args)
    {
        // Variable declarations allowed here
       
        while (true)                     // The game repeats until finished by player 1
        {
            // Variable declarations allowed here
            ReadSecretWord();            // Player 1: Enter the secret word to be guessed by player 2
            HangTheMan();                // Screen output for a good start
            while (true)                 // Player 2: Make your guesses
            {
                ReadOneChar();           // Handle input of one char. 
                EvaluateTheSituation();  // Game Logic goes here
                HangTheMan();            // Screen output goes here
            }
            QuitOrRestart(); // Ask if want to quit or start new game
        }
    }

    static void ReadSecretWord() // Modification of method declaration recommended: Add return value and parameters
                                 // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
    {
        // Variable declarations allowed here
        // Console.Write() etc. allowed here!

    }

    static void ReadOneChar() // Modification of method declaration recommended: Add return value and parameters
                              // If there are rules and constraints on allowed secrets (e.g. no digits), make sure the input is allowed
    {
        // Variable declarations allowed here
        // Console.Write() etc. allowed here!
    }

    static void EvaluateTheSituation() // Modification of method declaration recommended: Add return value and parameters
                                       // In here, evaluate the char entered: Is it part of the secret word?
                                       // Calculate and return the game status (Hit or missed? Where? List and number of missed chars?...)
    {
        // Variable declarations allowed here
        // NO Console.Write() etc. in here!
    }

    static void QuitOrRestart() // Modification of method declaration recommended: Add return value and parameters
                                // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
    {
        // Variable declarations allowed here
        // Console.Write() etc. allowed here!
    }

    static void HangTheMan() // Modification of method declaration recommended: Add return value and parameters
                             // In here, clear the screen and redraw everything reflecting the actual game status
    {
        // Variable declarations allowed here
        // all Console.Write() etc. go here
    }
}

//using System.Threading.Channels;

//namespace Hangman
//{
//    internal class Program
//    {

//        static void Main(string[] args)

//        {  

//            while (true)
//            {   
//                Console.WriteLine("write your secret word");
//                string secretWord = ReadTheSecretWord();
//                Console.WriteLine( "This is your word: " + secretWord );
//                while (true)
//                {
//                    Console.WriteLine("enter your guest letter");
//                     char letter = ReadOneChar();
//                    Console.WriteLine("This is your char: " + letter);
//                    //EvaluateTheSituation();
//                }
//            }


//        }


//        static string ReadTheSecretWord()
//        {
//            string word = Console.ReadLine();
//            return word.ToUpper();
//        }

//        static char ReadOneChar()
//        {
//            char c = Console.ReadKey().KeyChar;
//            string s = c.ToString().ToUpper();
//            char bigC = Convert.ToChar(s);
//            return bigC;

//        }

//    }
//}