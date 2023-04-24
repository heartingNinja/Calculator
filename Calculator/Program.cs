using CalculatorLibrary;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int timesUsed = 0;
            bool endApp = false;
            bool backToMenu = true;
            bool useResultNumbers = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();

            while (!endApp)
            {
                if (backToMenu)
                {
                    Console.WriteLine($"Times the calculator was used {timesUsed}");
                    Console.WriteLine("\tS - Start");
                    Console.WriteLine("\tR - Results");
                    Console.Write("Your option? ");

                    string option = Console.ReadLine();

                    if (option.ToLower() == "s")
                    {
                        backToMenu = false;
                        continue;
                    }
                    if (option.ToLower() == "r")
                    {
                        calculator.PrintResults();
                        Console.Write("Press 'b' and Enter to return to the menu, press 'c' and Enter to clear the results, or press 'r' to use results for your number inputs\n");
                        string input = Console.ReadLine();
                        if (input == "b")
                        {
                            continue;
                        }
                        else if (input == "c")
                        {
                            calculator.ClearResults();
                        }
                        else if (input == "r")
                        {
                            Console.Write("choose numbers from list of results");
                            if(calculator.results.Count >= 2)
                            {
                                useResultNumbers = true;
                            }
                            else
                            {
                                Console.Write("need more than two results");
                            }
                        }
                        else if (option.ToLower() != "s" || option.ToLower() != "r")
                        {
                            Console.Write("choose Start or Results");
                        }


                    }
                }

                if (!useResultNumbers)
                {
                    // Declare variables and set to empty.
                    string numInput1 = "";
                    string numInput2 = "";
                    double result = 0;

                    // Ask the user to type the first number.
                    Console.Write("Type a number, and then press Enter: ");
                    numInput1 = Console.ReadLine();

                    double cleanNum1 = 0;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput1 = Console.ReadLine();
                    }

                    // Ask the user to type the second number.
                    Console.Write("Type another number, and then press Enter: ");
                    numInput2 = Console.ReadLine();

                    double cleanNum2 = 0;
                    while (!double.TryParse(numInput2, out cleanNum2))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput2 = Console.ReadLine();
                    }

                    // Ask the user to choose an operator.
                    Console.WriteLine("Choose an operator from the following list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.WriteLine("\tb - Back to Menu");
                    Console.Write("Your option? ");

                    string op = Console.ReadLine();

                    if (op.ToLower() == "b")
                    {
                        backToMenu = true;
                        continue;
                    }

                    try
                    {
                        result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                    }

                    // Wait for the user to respond before continuing.
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    Console.WriteLine("\n"); // Friendly linespacing.
                    timesUsed++;
                }
                // this uses so much on part above, should have better way to combine them
                else
                {
                    // Declare variables and set to empty.
                    string numInput1 = "";
                    string numInput2 = "";
                    double result = 0;


                    // Display the list of strings
                    Console.WriteLine("List of previous results:");
                    for (int i = 0; i < calculator.results.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i + 1, calculator.results[i]);
                    }

                    // Ask the user to choose the index of the result to use as the first number
                    Console.Write("Choose the index of the result to use as the first number: ");
                    string indexInput = Console.ReadLine();

                    int index = calculator.results.Count;
                    while (!int.TryParse(indexInput, out index) || index < 1 || index > calculator.results.Count)
                    {
                        Console.Write("Invalid input. Please enter a number between 1 and {0}: ", calculator.results.Count);
                        indexInput = Console.ReadLine();
                    }

                    // Retrieve the chosen result string and convert it to a double
                    numInput1 = calculator.results[index - 1];
                    double cleanNum1 = 0;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("This is not valid input. Please enter a number: ");
                        numInput1 = Console.ReadLine();
                    }

                    // Display the list of strings
                    //Console.WriteLine("List of previous results:");
                    for (int i = 0; i < calculator.results.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i + 1, calculator.results[i]);
                    }

                    // Ask the user to choose the index of the result to use as the first number
                    Console.Write("Choose the index of the result to use as the second number: ");
                    indexInput = Console.ReadLine();

                    index = 0;
                    while (!int.TryParse(indexInput, out index) || index < 1 || index > calculator.results.Count)
                    {
                        Console.Write("Invalid input. Please enter a number between 1 and {0}: ", calculator.results.Count);
                        indexInput = Console.ReadLine();
                    }

                    // Retrieve the chosen result string and convert it to a double
                    numInput2 = calculator.results[index - 1];
                    double cleanNum2 = 0;
                    while (!double.TryParse(numInput2, out cleanNum2))
                    {
                        Console.Write("This is not valid input. Please enter a number: ");
                        numInput1 = Console.ReadLine();
                    }

                    // Ask the user to choose an operator.
                    Console.WriteLine("Choose an operator from the following list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.WriteLine("\tb - Back to Menu");
                    Console.Write("Your option? ");

                    string op = Console.ReadLine();

                    if (op.ToLower() == "b")
                    {
                        backToMenu = true;
                        continue;
                    }

                    try
                    {
                        result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                    }

                    // Wait for the user to respond before continuing.
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    Console.WriteLine("\n"); // Friendly linespacing.
                    timesUsed++;
                    useResultNumbers = false;
                }
            }

            calculator.Finish();
            return;
        }
    }

}


