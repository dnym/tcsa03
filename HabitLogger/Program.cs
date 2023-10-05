using HabitLogger.Database;

namespace HabitLogger;

internal static class Program
{
    internal static IDatabase _database = new MemoryStorage();

    static void Main()
    {
        var mainMenu = new MainMenu(_database);
        mainMenu.Show();
    }
}