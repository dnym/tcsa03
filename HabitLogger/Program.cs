using HabitLogger.Database;
using HabitLogger.Models;

namespace HabitLogger;

internal static class Program
{
    internal static IDatabase Database = new MemoryStorage();

    static void Main()
    {
        MainMenu.Show();
    }
}