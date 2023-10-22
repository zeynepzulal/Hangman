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




        //int tahminHakkin = 6;
        List<char> triedChar = new List<char>();


        while (true)                     // The game repeats until finished by player 1
        {
            // Variable declarations allowed here
            secretWord = ReadSecretWord(validCharachters);  // Player 1: Enter the secret word to be guessed by player 2

            HangTheMan(hangmanIndex, hangman);                // Screen output for a good start
            while (true)                 // Player 2: Make your guesses
            {
                char yourChar = ReadOneChar(validCharachters); // Handle input of one char. 
                if (yourChar == ' ')
                {
                    continue;

                }
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
                    HangTheMan(hangmanIndex, hangman); // Screen output goes here
                }

            }

            if (QuitOrRestart())  // Ask if want to quit or start new game
            {
                continue;
            }
            else
            {
                Console.WriteLine("Güle güle...");
                break;
            }
        }

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


    static bool EvaluateTheSituation(string word, char harf)
    {

        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == harf)
            {
                return true;

            }
        }
        return false;

    }

    static string recreateTheWord(List<char> triedCharachter, string secWrd, int indexHangman, string[] Man)
    {
        string word = "";
        for (int i = 0; i < secWrd.Length; i++)
        {
            if (triedCharachter.Contains(secWrd[i]))
            {
                word += secWrd[i];
            }
            else
            {
                word += " _ ";
                while (indexHangman < Man.Length)
                {
                    indexHangman++;
                }

            }

        }
        Console.WriteLine(indexHangman);
        return word;
    }

    static void HangTheMan(int indexHangman, string[] Man)

    {
        Console.Write(Man[indexHangman]);

    }

    static bool DidYouWin(string newWrd, char[] validChar)
    {
        if (newWrd.All(c => validChar.Contains(c)))
        {
            Console.WriteLine("Congratulations, you won");
            return true;
        }
        return false;
    }

    static bool QuitOrRestart()
    {
        Console.WriteLine("Do you want to continue?");
        string cevap = Console.ReadLine();
        if (cevap == "yes")
        {
            return true;

        }
        if (cevap == "no")
        {
            return false;
        }
        return false;

    }




}

