namespace HangMan;

class Program
{
    static void Main(string[] args)
    {
        // Variable declarations allowed here
        char[] validCharachters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
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
        while (true)                     // The game repeats until finished by player 1
        {
            // Variable declarations allowed here
            // resetting variables
            int hangmanIndex = 0;
            List<char> triedChar = new List<char>();
            string secretWord = ReadSecretWord(validCharachters);  // Player 1: Enter the secret word to be guessed by player 2
            //HangTheMan(hangmanIndex, hangman);       Screen output for a good start

            while (true)                 // Player 2: Make your guesses
            {
                char yourChar = ReadOneChar(validCharachters); // Handle input of one char. 
                int gameStatus = EvaluateTheSituation(secretWord, yourChar, ref triedChar, ref hangmanIndex, hangman);  // Game Logic goes here
                if (gameStatus == 2)
                {
                    Console.WriteLine("You won!");
                    break;
                }
                else if(gameStatus == 1)
                {
                    Console.WriteLine("You lost!");
                    break;
                }
                HangTheMan(ref hangmanIndex, hangman);            // Screen output goes here
            }
            bool AreYouContinue = QuitOrRestart(); // Ask if want to quit or start new game
            if (!AreYouContinue)
            {
                break;
            }
        }

        static string ReadSecretWord(char[] validChar)
        {
            while (true)
            {
                Console.WriteLine("Enter your secret word");
                string word = Console.ReadLine();
                bool valid = true;
                word = word.ToUpper();
                if (word.Length < 3)
                {
                    Console.WriteLine("Do not enter words of less than 3 characters");
                    valid = false;
                }
                for (int i = 0; i < word.Length; i++)
                {
                    if (!validChar.Contains(word[i]))
                    {
                        Console.WriteLine("Invalid character!");
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
            Console.WriteLine("Guess a letter");
            char c = Console.ReadKey().KeyChar.ToString().ToUpper().ToCharArray()[0];
            if (!validChar.Contains(c))
            {
                Console.WriteLine("Invalid character!");
                return ' ';
            }
            return c;
        }

        static int EvaluateTheSituation(string word, char letter, ref List<char> triedCharachter, ref int indexHangman, string[] Man)
        {
            string recreatedWord = "";
            triedCharachter.Add(letter);
            for (int i = 0; i < word.Length; i++)
            {
                if (triedCharachter.Contains(word[i]))
                {
                    recreatedWord += word[i];
                }
                else
                {
                    recreatedWord += " _ ";
                }
            }
            if (word.Contains(letter))
            {
                Console.WriteLine(" ");
                Console.WriteLine(recreatedWord);
            }
            else
            {
                indexHangman++;
            }
            if (indexHangman >= Man.Length)
            {
                return 1;
            }
            if (word == recreatedWord)
            {
                return 2;
            }
            return 0;
        }

        static void HangTheMan(ref int indexHangman, string[] Man)
        {
            Console.Write(Man[indexHangman]);
        }

        static bool QuitOrRestart()
        {
            Console.WriteLine("Do you want to continue ? Y or N");
            string answer;
            while (true)
            {
                answer = Console.ReadKey().KeyChar.ToString().ToUpper();
                if (answer != "Y" && answer != "N")
                {
                    Console.WriteLine("Invalid character, please just write Y or N !");
                }
                else
                {
                    break;
                }
            }
            if (answer == "Y")
            {
                return true;
            }
            return false;
        }
    }
}

