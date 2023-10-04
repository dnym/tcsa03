namespace HabitLogger;

internal static class ManageRecordsMenu
{
    public static void Show()
    {
        const string headerBase = @"Records{}
==================
";
        string header;

        const string pgUp = @"[PgUp] to go to the previous page,
";

        const string pgDown = @"[PgDown] to go to the next page,
";

        const string esc = "[Esc] to go back to the main menu";

        const string footerBase = @"

------------------
Press {}.";
        string footer;

        const string prompt = "Select a record to manage: ";
        const string noRecords = "No records to manage.";

        int skipped = 0;
        int perPage = Math.Max(1, Console.WindowHeight - 11);
        Helpers.Signal? signal;

        bool pressedEscape = false;
        while (!pressedEscape)
        {
            var subset = Program.Records.Skip(skipped).Take(perPage).ToList();
            int left = Program.Records.Count - skipped - subset.Count;
            var quantityWidth = 0;
            if (subset.Count > 0)
            {
                quantityWidth = subset.Max(r => r.Quantity.ToString().Length);
            }

            Console.Clear();
            {
                if (skipped == 0 && left == 0)
                {
                    footer = footerBase.Replace("{}", esc);
                }
                else if (skipped == 0)
                {
                    footer = footerBase.Replace("{}", $"{pgDown}or {esc}");
                }
                else if (left == 0)
                {
                    footer = footerBase.Replace("{}", $"{pgUp}or {esc}");
                }
                else
                {
                    footer = footerBase.Replace("{}", $"{pgUp}{pgDown}or {esc}");
                }
            }
            {
                if (Program.Records.Count <= perPage)
                {
                    header = headerBase.Replace("{}", "");
                }
                else
                {
                    var totalPages = (int)Math.Ceiling(Program.Records.Count / (double)perPage);
                    var currentPage = (int)Math.Ceiling((skipped + 1) / (double)perPage);
                    header = headerBase.Replace("{}", $" (page {currentPage}/{totalPages})");
                }
                Console.WriteLine(header);
            }

            if (subset.Count > 0)
            {
                for (int i = 0; i < subset.Count; i++)
                {
                    var record = subset[i];
                    var number = i + 1;
                    var numberString = number.ToString().PadLeft(perPage.ToString().Length);
                    var quantityString = record.Quantity.ToString().PadLeft(quantityWidth);
                    Console.WriteLine($"{numberString}. {quantityString} @ {record.Date}");
                }
            }
            else
            {
                Console.Write(noRecords);
            }

            int currentPositionX = 0;
            int currentPositionY = 0;
            if (subset.Count > 0)
            {
                Console.WriteLine();
                Console.Write(prompt);
                currentPositionX = Console.CursorLeft;
                currentPositionY = Console.CursorTop;
            }

            Console.WriteLine(footer);

            if (subset.Count > 0)
            {
                Console.SetCursorPosition(currentPositionX, currentPositionY);
            }
            (pressedEscape, _, signal) = Helpers.ReadInput();
            if (signal == Helpers.Signal.PG_UP && skipped > 0)
            {
                skipped = Math.Max(0, skipped - perPage);
            }
            else if (signal == Helpers.Signal.PG_DOWN && left > 0)
            {
                skipped = Math.Min(Program.Records.Count - 1, skipped + perPage);
            }
        }
    }
}
