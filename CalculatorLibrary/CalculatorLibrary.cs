using Newtonsoft.Json;

namespace CalculatorLibrary;

public class Calculator
{
   // JsonWriter writer;
    public List<string> results = new List<string> { };

    public Calculator()
    {
        StreamWriter logFile = File.CreateText("calculatorlog.json");
        logFile.AutoFlush = true;
        //writer = new JsonTextWriter(logFile);
        //writer.Formatting = Formatting.Indented;
        //writer.WriteStartObject();
        //writer.WritePropertyName("Operations");
        //writer.WriteStartArray();
    }

    public double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
        //writer.WriteStartObject();
        //writer.WritePropertyName("Operand1");
        //writer.WriteValue(num1);
        //writer.WritePropertyName("Operand2");
        //writer.WriteValue(num2);
        //writer.WritePropertyName("Operation");
        // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                result = num1 + num2;
                //writer.WriteValue("Add");
                break;
            case "s":
                result = num1 - num2;
               // writer.WriteValue("Subtract");
                break;
            case "m":
                result = num1 * num2;
               // writer.WriteValue("Multiply");
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                //writer.WriteValue("Divide");
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        //writer.WritePropertyName("Result");
        //writer.WriteValue(result.ToString());
        //writer.WriteEndObject();
        AddToHistory(result.ToString());
        return result;
    }

    void AddToHistory(string result)
    {
        results.Add(result);
    }

    public void PrintResults()
    {
        Console.Clear();
        Console.WriteLine("Results");
        Console.WriteLine("-----------------------");
        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {results[i]}");
        }
        Console.WriteLine("-----------------------\n");
    }

    public void ClearResults()
    {
        results.Clear();
        Console.WriteLine("Results cleared.");
    }

    public void Finish()
    {
        //writer.WriteEndArray();
        //writer.WriteEndObject();
        //writer.Close();
    }
}
