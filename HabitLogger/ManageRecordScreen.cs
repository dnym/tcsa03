using HabitLogger.Models;

namespace HabitLogger;

internal static class ManageRecordScreen
{
    public static bool Show(HabitRecord record)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(@$"Viewing Record
==============

Date: {record.Date}
Quantity: {record.Quantity}

--------------
Press [M] to modify the record,
[D] to delete,
or [Esc] to go back to the main menu.");
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.M:
                    ModifyRecordScreen.Show(record);
                    break;
                case ConsoleKey.D:
                    Program.Records.Remove(record);
                    return true;
                case ConsoleKey.Escape:
                    return false;
            }
        }
    }
}
