namespace HabitLogger;

internal static class InsertRecordScreen
{
    public static void Show()
    {
        const string header = @"Insert Record
=============
";

        const string footer = @"

-------------
Press [Esc] to cancel insertion.";

        const string datePrompt = @"Enter a time and date for this record,
or leave empty for current time: ";

        const string quantityPrompt = "Enter the quantity for this occasion: ";

        string userDate = "";
        string userQuantity = "";

        bool stayInMenu = true;
        while (stayInMenu && string.IsNullOrWhiteSpace(userDate))
        {
            Console.Clear();
            Console.WriteLine(header);
            Console.Write(datePrompt);
            var currentPositionX = Console.CursorLeft;
            var currentPositionY = Console.CursorTop;
            Console.WriteLine(footer);

            Console.SetCursorPosition(currentPositionX, currentPositionY);

            (stayInMenu, userDate) = ReadInput();
        }

        while (stayInMenu && string.IsNullOrWhiteSpace(userQuantity))
        {
            Console.Clear();
            Console.WriteLine(header);
            Console.Write(datePrompt);
            Console.WriteLine(userDate);
            Console.WriteLine();
            Console.Write(quantityPrompt);
            var currentPositionX = Console.CursorLeft;
            var currentPositionY = Console.CursorTop;
            Console.WriteLine(footer);

            Console.SetCursorPosition(currentPositionX, currentPositionY);
            (stayInMenu, userQuantity) = ReadInput();
        }
    }

    private static Tuple<bool, string> ReadInput()
    {
        int cursorStartX = Console.CursorLeft;
        string userInput = "";
        int inputPosition = 0;
        bool stayInMenu = true;
        bool keepReadingKeys = true;
        while (stayInMenu && keepReadingKeys)
        {
            var keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.Escape:
                    stayInMenu = false;
                    break;
                case ConsoleKey.Enter:
                    keepReadingKeys = false;
                    break;
                case ConsoleKey.Backspace:
                    if (inputPosition > 0)
                    {
                        inputPosition--;
                        userInput = userInput.Remove(inputPosition, 1);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        ClearRestOfLine();
                        Console.Write(userInput[inputPosition..]);
                        Console.SetCursorPosition(cursorStartX + inputPosition, Console.CursorTop);
                    }
                    break;
                case ConsoleKey.Home:
                    inputPosition = 0;
                    Console.SetCursorPosition(cursorStartX, Console.CursorTop);
                    break;
                case ConsoleKey.End:
                    inputPosition = userInput.Length;
                    Console.SetCursorPosition(cursorStartX + inputPosition, Console.CursorTop);
                    break;
                case ConsoleKey.LeftArrow:
                    if (inputPosition > 0)
                    {
                        inputPosition--;
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (inputPosition < userInput.Length)
                    {
                        inputPosition++;
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    }
                    break;
                case ConsoleKey.Delete:
                    if (inputPosition < userInput.Length)
                    {
                        userInput = userInput.Remove(inputPosition, 1);
                        ClearRestOfLine();
                        Console.Write(userInput[inputPosition..]);
                        Console.SetCursorPosition(cursorStartX + inputPosition, Console.CursorTop);
                    }
                    break;
                default:
                    userInput = userInput.Insert(inputPosition, $"{keyInfo.KeyChar}");
                    inputPosition++;
                    Console.Write(keyInfo.KeyChar);
                    ClearRestOfLine();
                    Console.Write(userInput[inputPosition..]);
                    Console.SetCursorPosition(cursorStartX + inputPosition, Console.CursorTop);
                    break;
            }
        }
        return new(stayInMenu, userInput);
    }

    private static void ClearRestOfLine()
    {
        var currentLine = Console.CursorTop;
        var currentColumn = Console.CursorLeft;
        Console.Write(new string(' ', Console.WindowWidth - currentColumn));
        Console.SetCursorPosition(currentColumn, currentLine);
    }
}
