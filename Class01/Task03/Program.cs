using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> options = new List<string> { "rock", "paper", "scissors" };
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("gamesPlayed", 0);
            dictionary.Add("userWins", 0);
            dictionary.Add("computerWins", 0);
            dictionary.Add("userLoses", 0);
            
            while (true)
            {
                Console.WriteLine("Welcome to Main Menu");
                Console.WriteLine("Please select one of the three options");
                Console.WriteLine("1.Play 2.Stats 3.Exit");


                string pickedFromMenu = Console.ReadLine();
                if (!int.TryParse(pickedFromMenu, out int number) || number > 3 || number < 1)
                {
                    Console.WriteLine("Wrong number selected");
                }
                else
                {
                    
                    switch (number)
                    {
                        case 1:

                            string userOption = UserPickOption(options);
                            string computerOption = ComputerOption(options);

                            Console.WriteLine($"The user choice {userOption} vs computer's {computerOption}");

                            string score = Battle(options, userOption, computerOption);
                            Console.WriteLine(score);
                            ScoreSheet(score,dictionary);

                            break;

                        case 2:
                            Stats(dictionary);
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                    
                }
            }
            
        }

        public static string UserPickOption(List<string> options)
        {
            Console.WriteLine("Please pick: rock, paper or scissors");
            string input = Console.ReadLine();

            while (true)
            {
                if(options.Contains(input))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                    input = Console.ReadLine();
                } 
            }

            return input;
        }

        public static string ComputerOption(List<string> options)
        {
            var random = new Random();
            int comOption = random.Next(options.Count);
            return options[comOption];
        }


        public static string Battle(List<string> options, string userOption, string computerOption)
        {
            string rock = options.First(rockOption => rockOption == "rock");
            string paper = options.First(paperOption => paperOption == "paper");
            string scissors = options.First(scissorsOption => scissorsOption == "scissors");


            if ((userOption == scissors && computerOption == paper) || (userOption == paper && computerOption == rock) || (userOption == rock && computerOption == scissors))
            {
                return $"User is the winner";
            }
            else if ((computerOption == scissors && userOption == paper) || (computerOption == paper && userOption == rock) || (computerOption == rock && userOption == scissors))
            {
                return $"Computer is the winner";
            }
            else
            {
                return $"It's a draw";
            }
        }

        public static void ScoreSheet(string score, Dictionary<string, int> dictionary)
        {

            if (score == "User is the winner")
            {
                dictionary["gamesPlayed"] += 1;
                dictionary["userWins"] += 1;
            }
            else if (score == "Computer is the winner")
            {
                dictionary["gamesPlayed"] += 1;
                dictionary["computerWins"] += 1;
                dictionary["userLoses"] += 1;
            }
            else
            {
                dictionary["gamesPlayed"] += +1;
            }
        }

        public static void Stats(Dictionary<string, int> dictionary)
        {

            Console.WriteLine("Select an option: 1.Win Stats 2.Win/Lose percetage stats 3.Back to menu");
            string secondChoiseFromMenu = Console.ReadLine();
            if (!int.TryParse(secondChoiseFromMenu, out int number2) || number2 > 3 || number2 < 1)
            {
                Console.WriteLine("Wrong number selected.Please Try Again");
            }
            else
            {
                switch (number2)
                {
                    case 1:

                        Console.WriteLine(statsWin(dictionary["userWins"], dictionary["computerWins"]));
                        break;
                    case 2:
                        Console.WriteLine(percentageStats(dictionary["gamesPlayed"], dictionary["userWins"], dictionary["userLoses"]));
                        break;
                    case 3:
                        break;
                }
            }
        }

        public static string statsWin(int userScore, int computerScore)
        {
            return $"User has {userScore} wins; Computer has {computerScore} wins";
        }

        public static string percentageStats(int gamesPlayed, int userWins, int userLoses)
        {

            double winScore = (userWins * 100) / gamesPlayed;
            double loseScore = (userLoses * 100) / gamesPlayed;

            return $"User wins: {winScore}%      User loses: {loseScore}%";
        }
    }
}
