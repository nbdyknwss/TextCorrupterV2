// Method Declarations
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ZalgoText
{
    static Random rand = new Random(); 
// List of assorted Unicode characters that will be placed at random throughout your input text.
    static List<string> zalgoUp = new List<string> { "̍", "̎", "̄", "̅", "̿", "̑", "̆", "̐", "͒", "͗", "͑", "̇", "̈", "̊", "͂", "̓", "̈", "͊", "͋", "͌", "̃", "̂", "̌", "͐", "̀", "́", "̋", "̏", "̒", "̓", "̔", "̽", "̉", "ͣ", "ͤ", "ͥ", "ͦ", "ͧ", "ͨ", "ͩ", "ͪ", "ͫ", "ͬ", "ͭ", "ͮ", "ͯ", "̾", "͛", "͆", "̚" };
    static List<string> zalgoMid = new List<string> { "̕", "̛", "̀", "́", "͘", "̡", "̢", "̧", "̨", "̴", "̵", "̶", "͜", "͝", "͞", "͟", "͠", "͢", "̸", "̷", "͡", " ҉" };
    static List<string> zalgoDown = new List<string> { "̖", "̗", "̘", "̙", "̜", "̝", "̞", "̟", "̠", "̤", "̥", "̦", "̩", "̪", "̫", "̬", "̭", "̮", "̯", "̰", "̱", "̲", "̳", "̹", "̺", "̻", "̼", "ͅ", "͇", "͈", "͉", "͍", "͎", "͓", "͔", "͕", "͖", "͙", "͚", "̣" };

    public static string MakeZalgo(string input)
    {
        var output = new StringBuilder();

        foreach (var c in input)
        {
            output.Append(c);

            // Made to add fewer Unicode characters for legibility-sake.
            int numUp = rand.Next(4);
            int numMid = rand.Next(1);
            int numDown = rand.Next(4);

            for (int i = 0; i < numUp; i++) output.Append(zalgoUp[rand.Next(zalgoUp.Count)]);
            for (int i = 0; i < numMid; i++) output.Append(zalgoMid[rand.Next(zalgoMid.Count)]);
            for (int i = 0; i < numDown; i++) output.Append(zalgoDown[rand.Next(zalgoDown.Count)]);
        }

        return output.ToString();
    }
    [STAThread] // Allows the Clipboard.SetText() to run and interact correctly with your system.
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Enter the text you want to corrupt:");
        string input = Console.ReadLine();
        string zalgoText = MakeZalgo(input);

        Console.WriteLine(zalgoText);
        Clipboard.SetText(zalgoText); //Sets your clipboard with the modified text.
        Console.WriteLine("Text copied to clipboard!");
        Console.WriteLine("Press any key to exit!");
        Console.ReadKey(); //Ends the program once you make a key input.
    }
}
