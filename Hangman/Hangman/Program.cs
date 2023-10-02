using System.ComponentModel.Design;
using System.Threading.Channels;

namespace HangMan; 

class Program
{
    // No variable declarations in this area!!
    static string secretWord = "";
    static char[] validCharachters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    static int hangmanIndex = 0; 
    static string[] hangman = new string[] {@" 
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
    static string kelime = "";
    static void Main(string[] args)
    {
        // Variable declarations allowed here
        
       
        //int tahminHakkin = 6;
        List<char> denenenHarfler = new List<char>();
          
        

        while (true)                     // The game repeats until finished by player 1
        {
            // Variable declarations allowed here
            ReadSecretWord();  // Player 1: Enter the secret word to be guessed by player 2
            if(secretWord == "")
            {
                continue;
            }

            HangTheMan();                // Screen output for a good start
            while (true)                 // Player 2: Make your guesses
            { 
               char yourChar = ReadOneChar(); // Handle input of one char. 
                if(yourChar == ' ')
                {
                    continue;

                }

                if (EvaluateTheSituation(secretWord, yourChar)) // Game Logic goes here
                {
                    denenenHarfler.Add(yourChar);
                    var olusanKelime =kelimeOlusturma(denenenHarfler);
                    Console.WriteLine("");
                    Console.WriteLine(olusanKelime);
                }
                else
                {
                   HangTheMan(); // Screen output goes here
                }
                
                
                           
            }

            if (!QuitOrRestart())  // Ask if want to quit or start new game
            {
                break;
            }; 
        }
        
    }

    static void ReadSecretWord() 
    { 
        Console.WriteLine("enter your secret word");
        string word = Console.ReadLine();
         
        if(word.Length < 3)
        {
            Console.WriteLine("3 karakterden az kelime girmeyiniz!");
            return;
        }
        for(int i = 0;  i < word.Length; i++)
        {
            if (!validCharachters.Contains(word[i]))
            {
                Console.WriteLine("gecersiz karakter girdiniz , lütfen büyük karakter girin ve noktali harfleri kullanmayiniz");
                return;
            }
        }
        secretWord = word;
      
        
    }

    static string kelimeOlusturma(List<char> tahminEdilenHarfler)
    {  
        kelime = "";
        for(int i = 0; i < secretWord.Length; i++)
        {
            if (tahminEdilenHarfler.Contains(secretWord[i]))
            {
                kelime +=  secretWord[i];
            }
            else
            {
               kelime += " _ ";
            }
            
        }
        return kelime;
    }
    
    static char ReadOneChar() 
    {
        
        Console.WriteLine(" harf dene");

        char c = Console.ReadKey().KeyChar.ToString().ToUpper().ToCharArray()[0];
        if (!validCharachters.Contains(c)){
            Console.WriteLine("gecersiz karakter girdiniz , lütfen büyük karakter girin ve noktali harfleri kullanmayiniz");
            return ' ';
        }
        return c;
        
    }
    
    static bool  EvaluateTheSituation(string word, char harf) 
    {
        
       for(int i = 0; i < word.Length; i++)
        {
            if (word[i] == harf)
            {
                return true;
            }

        }
        return false;
    }
    
    static bool QuitOrRestart() 
    {
        Console.WriteLine("devam edecek misin ?");
        string cevap = Console.ReadLine();
        if(cevap == "evet")
        {
            return true;

        }
        return false;
    }

    static void HangTheMan() 

    {
        Console.Write(hangman[hangmanIndex]);
        hangmanIndex++;

    }
} 