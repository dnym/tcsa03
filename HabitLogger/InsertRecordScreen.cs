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
        string userInput = "";
        bool stayInMenu = true;
        bool keepReadingKeys = true;
        while (stayInMenu && keepReadingKeys)
        {
            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                stayInMenu = false;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                keepReadingKeys = false;
            }
            else
            {
                userInput += keyInfo.KeyChar;
                Console.Write(keyInfo.KeyChar);
            }
        }
        return new(stayInMenu, userInput);
    }
}
