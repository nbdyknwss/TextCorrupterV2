using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ZalgoText
{
    static Random rand = new Random();

    static List<string> zalgoUp = new List<string> { "̍", "̎", "̄", "̅", "̿", "̑", "̆", "̐", "͒", "͗", "͑", "̇", "̈", "̊", "͂", "̓", "̈", "͊", "͋", "͌", "̃", "̂", "̌", "͐", "̀", "́", "̋", "̏", "̒", "̓", "̔", "̽", "̉", "ͣ", "ͤ", "ͥ", "ͦ", "ͧ", "ͨ", "ͩ", "ͪ", "ͫ", "ͬ", "ͭ", "ͮ", "ͯ", "̾", "͛", "͆", "̚" };
    static List<string> zalgoMid = new List<string> { "̕", "̛", "̀", "́", "͘", "̡", "̢", "̧", "̨", "̴", "̵", "̶", "͜", "͝", "͞", "͟", "͠", "͢", "̸", "̷", "͡", " ҉" };
    static List<string> zalgoDown = new List<string> { "̖", "̗", "̘", "̙", "̜", "̝", "̞", "̟", "̠", "̤", "̥", "̦", "̩", "̪", "̫", "̬", "̭", "̮", "̯", "̰", "̱", "̲", "̳", "̹", "̺", "̻", "̼", "ͅ", "͇", "͈", "͉", "͍", "͎", "͓", "͔", "͕", "͖", "͙", "͚", "̣" };

    public static string MakeZalgo(string input)
    {
        var output = new StringBuilder();

        foreach (var c in input)
        {
            output.Append(c);

            // Add fewer zalgo characters for legibility
            int numUp = rand.Next(4);
            int numMid = rand.Next(1);
            int numDown = rand.Next(4);

            for (int i = 0; i < numUp; i++) output.Append(zalgoUp[rand.Next(zalgoUp.Count)]);
            for (int i = 0; i < numMid; i++) output.Append(zalgoMid[rand.Next(zalgoMid.Count)]);
            for (int i = 0; i < numDown; i++) output.Append(zalgoDown[rand.Next(zalgoDown.Count)]);
        }

        return output.ToString();
    }
    [STAThread]
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Enter the text you want to corrupt:");
        string input = Console.ReadLine();
        string zalgoText = MakeZalgo(input);
        // Clipboard.SetText(zalgoText);


        Console.WriteLine(zalgoText);
        Clipboard.SetText(zalgoText);
        Console.WriteLine("Text copied to clipboard!");
        Console.WriteLine("Press any key to exit!");
        Console.ReadKey();
    }
}