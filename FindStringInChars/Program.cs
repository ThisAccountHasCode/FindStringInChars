class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a random jumble of text and numbers:");
        string UserInput = Console.ReadLine() ?? "";
        long sum = 0;

        for (int i = 0; i < UserInput.Length; i++)
        {
            if (!char.IsDigit(UserInput[i]))
                continue;

            for (int j = i + 1; j < UserInput.Length && char.IsDigit(UserInput[j]); j++)
            {
                if (UserInput[i] != UserInput[j])
                    continue;

                sum += long.Parse(UserInput.Substring(i, j - i + 1));

                PrintSequence(UserInput, i, j);
                break;
            }
        }
        Console.WriteLine($"Summa: {sum}");
    }

    static void PrintSequence(string text, int start, int end)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        // Console.Write(text[..start]);    // This is prettier, newer syntax, but it's less explicit in what we are doing
        Console.Write(text.Substring(0, start));

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(text.Substring(start, end - start + 1));

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text.Substring(end + 1));

        Console.ResetColor();
    }
}
