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
            int isGameOn = 2;
            while (true)                 // Player 2: Make your guesses
            {
                char yourChar = ReadOneChar(validCharachters); // Handle input of one char. 
                string recreatedWord = EvaluateTheSituation(secretWord, yourChar, ref triedChar, ref hangmanIndex, hangman, ref isGameOn);  // Game Logic goes here
                HangTheMan(ref hangmanIndex, hangman,  ref isGameOn, recreatedWord, secretWord);            // Screen output goes here
                if(isGameOn == 1 || isGameOn == 0)
                {
                    break;
                }
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

        static string EvaluateTheSituation(string word, char letter, ref List<char> triedCharachter, ref int indexHangman, string[] Man, ref int Status)
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

            if (!word.Contains(letter))
            {
                indexHangman++;
            }
            if (Man[indexHangman] == Man[Man.Length-1])
            {
                Status = 0;
            }
            if (word == recreatedWord)
            {
                Status = 1;
            }
            return recreatedWord;
        }

        static void HangTheMan(ref int indexHangman, string[] Man, ref int Status, string recreatedWord, string word)
        {
            if (Status == 1)
            {
                Console.WriteLine("You won!");
            }
            if (Status == 0)
            {
                Console.WriteLine("You lost! Secret word was " + word);
            }
            Console.WriteLine(Man[indexHangman]);
            Console.WriteLine(recreatedWord);
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

