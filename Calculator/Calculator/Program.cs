
using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaring variables

            //Calculation Variables
            decimal num01;
            decimal num02;
            string? input01;
            string? input02;
            string? opvalue;
            decimal result = 0;
            
            //Program Variables to prevent fail(except for inputredo)
            string err = "";
            bool fail = false;
            bool redo = false;
            string[] optypes = { "+", "-", "*", "/" };
            string? inputredo;
            
            //Restarts Program
            do
            {
                //Getting user input -  TryParse is to check if something that was not a number was entered
                Console.WriteLine("Welcome to the calculator!");
            
                Console.Write("Please input the first number: ");
                input01 = Console.ReadLine();
                if (!decimal.TryParse(input01, out num01))
                {
                    err = "Something that was not a number was entered.";
                    fail = true;
                }
            
                Console.Write("Please input the operator(+,-,*,/): ");
                opvalue = Console.ReadLine();
                if (!optypes.Contains(opvalue))
                {
                    err = "You did not type an operator";
                    fail = true;
                }
            
                Console.Write("Please input the second number: ");
                input02 = Console.ReadLine();
                if (!decimal.TryParse(input02, out num02))
                {
                    err = "Something that was not a number was entered.";
                    fail = true;
                }
            
                //Skips over if an error has occurred
                if (fail == false)
                {
                    //Switch instead of multiple if statement
                    switch (opvalue)
                    {
                        case "+":
                            result = num01 + num02;
                            break;
            
                        case "-":
                            result = num01 - num02;
                            break;
            
                        case "*":
                            result = num01 * num02;
                            break;
            
                        case "/":
                            if (num02 == 0)
                            {
                                err = "A number was divided by 0";
                                fail = true;
                            }
                            else
                            {
                                result = num01 / num02;
                            }
                            break;
                    }
                    Console.WriteLine($"\nThe equation {num01} {opvalue} {num02} = {result}.");
                }
            
            
                //If there is an error in the code
                do
                {
                    if (fail == true)
                    {
                        Console.WriteLine($"\nAn error has been detected.\nReason: {err}");
                    }
            
                    Console.Write("Would you like to restart the program? (Y/N): ");
                    inputredo = Console.ReadLine();
                    switch (inputredo)
                    {
                        case "Y":
                            redo = true;
                            fail = false;
                            break;
            
                        case "N":
                            redo = false;
                            fail = false;
                            break;
            
                        default:
                            err = "You did not specify if you wanted to end or restart the program";
                            fail = true;
                            break;
                    }
                } while (fail == true);
            } while (redo == true);
            
            //Wait before closing
            Console.WriteLine("Program is now closing. Press any key to close the program.");
            Console.ReadKey();
            }
        }
    }


