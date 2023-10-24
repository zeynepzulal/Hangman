using System.ComponentModel.Design;
using System.Threading.Channels;

namespace HangMan;

class Program
{


    static void Main(string[] args)
    {
        // Variable declarations allowed here
        string secretWord = "";
        char[] validCharachters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        int hangmanIndex = 0;
        string[] hangman = new string[] {@" 
____
|/   |
|   
|    
|    
|    
|
|_____
",
 @"
 ____
|/   |
|
|
|
|
|
|_____
",
        @"
 ____
|/   |
|   (_)
|    
|    
|    
|
|_____
",
        @"
 ____
|/   |
|   (_)
|    |
|    |    
|    
|
|_____
",
        @"
 ____
|/   |
|   (_)
|   \|
|    |
|    
|
|_____
",
        @"
 ____
|/   |
|   (_)
|   \|/
|    |
|    
|
|_____
",
        @"
 ____
|/   |
|   (_)
|   \|/
|    |
|   / 
|
|_____
",
        @"
 ____
|/   |
|   (_)
|   \|/
|    |
|   / \
|
|_____
",
        @"
 ____
|/   |
|   (_)
|   /|\
|    |
|   | |
|
|_____
" };
        string newWord = "";
        List<char> triedChar = new List<char>();

        while (true)                     // The game repeats until finished by player 1
        {
            // Variable declarations allowed here
            secretWord = ReadSecretWord(validCharachters);  // Player 1: Enter the secret word to be guessed by player 2
            hangmanIndex = HangTheMan(hangmanIndex, hangman);      // Screen output for a good start

            while (true)                 // Player 2: Make your guesses
            {
                char yourChar = ReadOneChar(validCharachters); // Handle input of one char. 
                EvaluateTheSituation(secretWord, yourChar, triedChar,secretWord,hangmanIndex,hangman);  // Game Logic goes here
                HangTheMan(hangmanIndex, hangman);            // Screen output goes here

            }
            /*
            while (true)                 // Player 2: Make your guesses
            {
                Console.WriteLine("index: " + hangmanIndex);
                char yourChar = ReadOneChar(validCharachters); // Handle input of one char. 
                //if (yourChar == ' ')
                //{
                //    continue;
                //}
                if (EvaluateTheSituation(secretWord, yourChar)) // Game Logic goes here
                {

                    triedChar.Add(yourChar);
                    newWord = recreateTheWord(triedChar, secretWord, hangmanIndex, hangman);
                    Console.WriteLine("");
                    Console.WriteLine(newWord);
                    if (DidYouWin(newWord, validCharachters))
                    {
                        break;
                    }
                }
                else
                {
                    hangmanIndex = HangTheMan(hangmanIndex, hangman); // Screen output goes here
                }
            }
            */

            QuitOrRestart(); // Ask if want to quit or start new game
        }

        static string ReadSecretWord(char[] validChar)
        {
            while (true)
            {
                Console.WriteLine("enter your secret word");
                string word = Console.ReadLine();
                bool valid = true;
                word = word.ToUpper();

                if (word.Length < 3)
                {
                    Console.WriteLine("3 karakterden az kelime girmeyiniz!");
                    valid = false;
                }
                for (int i = 0; i < word.Length; i++)
                {
                    if (!validChar.Contains(word[i]))
                    {
                        Console.WriteLine("gecersiz karakter girdiniz , lütfen büyük karakter girin ve noktali harfleri kullanmayiniz");
                        valid = false;
                        break;
                    }
                }
                if (!valid)
                {
                    continue;
                }
                return word;
            }
        }

        static char ReadOneChar(char[] validChar)
        {

            Console.WriteLine(" harf dene");

            char c = Console.ReadKey().KeyChar.ToString().ToUpper().ToCharArray()[0];
            if (!validChar.Contains(c))
            {
                Console.WriteLine("gecersiz karakter girdiniz , lütfen büyük karakter girin ve noktali harfleri kullanmayiniz");
                return ' ';
            }

            return c;

        }

         
        static void EvaluateTheSituation(string word, char harf,List<char> triedCharachter, string secWrd, int indexHangman, string[] Man)
         {
            string recreatedWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (triedCharachter.Contains(secWrd[i]))
                {
                    recreatedWord += secWrd[i];
                }
                else
                {
                    recreatedWord += " _ ";
                    while (indexHangman < Man.Length - 1)
                    {
                        indexHangman++;
                    }

                }
                Console.WriteLine(indexHangman);
                Console.WriteLine(recreatedWord);
            }
        }

        

        static int HangTheMan(int indexHangman, string[] Man)

        {
            Console.Write(Man[indexHangman]);
            return indexHangman;

        }
        
        static void QuitOrRestart(){}
    }
}

