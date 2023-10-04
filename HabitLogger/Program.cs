using HabitLogger.Models;

namespace HabitLogger;

internal static class Program
{
    internal static List<HabitRecord> Records = new();

    static void Main()
    {
        MainMenu.Show();
    }
}