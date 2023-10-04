namespace HabitLogger;

internal static class MainMenu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(@"Habit Logger
============

1. Insert Record
2. Manage Records
0. Quit

------------
Press a number to select.");
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    InsertRecordScreen.Show();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ManageRecordsMenu.Show();
                    break;
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
