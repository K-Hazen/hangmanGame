using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerGameChallenge
{
    class Hangman
    {
        static void Main(string[] args)
        {
            bool whilePlaying = true;
            int round = 0;
          
            while (whilePlaying)
            {
                if (round != 0)
                {
                   
                    Console.WriteLine("Would you like to play again? y/n");
                    string userInput = Console.ReadLine();
                    Console.Clear();
                    
                    if (userInput == "y")
                    {
                        round = 0;
                        continue;
                    }
                    else if (userInput == "n")
                    {
                        whilePlaying = false;
                        break; 
                    }
                }

                Console.WriteLine("Welcome to Hangman!!!");
                Console.WriteLine();
                Console.WriteLine("Pick one letter at a time to try to figure out the word.");
                Console.WriteLine("Capital letters and numbers are not accepted at this time! Unless you want to die.");
                Console.WriteLine();

                string[] listwords = new string[10];
                listwords[0] = "green";
                listwords[1] = "blue";
                listwords[2] = "eleven";
                listwords[3] = "fifty";
                listwords[4] = "academy";
                listwords[5] = "phone";
                listwords[6] = "shoe";
                listwords[7] = "notebook";
                listwords[8] = "coffee";
                listwords[9] = "snow";

                Random randWordGenerator = new Random(); //this is creating a new instance of the Random Class

                
                var randWord = randWordGenerator.Next(0, 9); //this is randomly generating the word from the list 
                string wordToGuess = listwords[randWord];  // this is assigning the random word selected to "wordToGuess"

                //Next is creating the guess funciton 
                char[] userGuess = new char[wordToGuess.Length]; //this lets us know how long the word is 

                //Console.WriteLine(wordToGuess);
                Console.WriteLine("Guess a letter!");
           

                for (int charLength = 0; charLength < wordToGuess.Length; charLength++) //this is creating the **** length 
                {
                    userGuess[charLength] = '*';
                }

                int win = 0;
                int death = 7;
                bool playing = true;

                List<char> guessedLetter = new List<char>();

                while (playing)
                {
                    char playerGuess = char.Parse(Console.ReadLine()); //this is taking the user input and converting it to "char Array"
                    Console.Clear();
                    //below the for statement runs the loop as long as the number of characters we guess then the if                    statement within
                    //the for loop evaluates if the character guessed is in the word 
                    guessedLetter.Add(playerGuess); //used a "char" list to match the same type of playerGuess 

                    if (wordToGuess.Contains(playerGuess))
                    {

                        for (int charArrayIndex = 0; charArrayIndex < wordToGuess.Length; charArrayIndex++)
                        {
                            if (playerGuess == wordToGuess[charArrayIndex])
                            {
                                userGuess[charArrayIndex] = playerGuess;
                                win++;
                            }
                        }
                    }
                    else
                    {
                        death--;
                        Console.WriteLine($"Nope... now you have one less life. Your Life Total is now {death}");
                        Console.WriteLine();

                    }
                    Console.WriteLine(userGuess);


                    Console.Write("Guessed Letters: ");
                    foreach (char x in guessedLetter)
                    {
                        Console.Write($"{x}, ");
                    }

                    Console.WriteLine();
                    if (death == 6)
                    {
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                    }
                    else if (death == 5)
                    {
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                    }
                    else if (death == 4)
                    {
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |    \\|");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                    }
                    else if (death == 3)
                    {
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |    \\|/");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");

                    }
                    else if (death == 2)
                    {
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |    \\|/");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                    }
                    else if (death == 1)
                    {
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |    \\|/");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |    /");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                    }
                    else if (death == 0)
                    {
                        Console.WriteLine("   _____");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |     O");
                        Console.WriteLine("  |    \\|/");
                        Console.WriteLine("  |     |");
                        Console.WriteLine("  |    / \\");
                        Console.WriteLine("  |");
                        Console.WriteLine("__|__");
                    }
                    
                    if (death > 0 && death <= 7 && win < wordToGuess.Length)
                    { 
                        Console.WriteLine();
                        Console.Write("Guess Another Letter:");
                    }

                    if (win == wordToGuess.Length) //keeping track of correct guesses 
                    {
                        Console.WriteLine();
                        Console.WriteLine("CONGRATS, YOU WON!!!");
                        round++;
                        playing = false;
                    }
                    else if (death == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("YOU ARE DEAD...SUCK IT!!!");
                        round++;
                        playing = false;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
