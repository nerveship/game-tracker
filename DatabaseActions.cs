using game_tracker;
using Microsoft.Data.Sqlite;

internal class DatabaseActions
{
    Program program = new Program();
    internal void ViewRecords(string connectionString)
    {
        Console.Clear();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var ViewAll = connection.CreateCommand();

            ViewAll.CommandText =
                @"SELECT * FROM games";

            ViewAll.ExecuteNonQuery();
        }
        
    }

    internal void InsertRecords(string connectionString)
    {
        Console.Clear();
        Console.WriteLine("Please insert valid input for each type.");
        Console.Write("Title: ");
        string Title = Console.ReadLine();

        Console.Write("Genre: ");
        string Genre = Console.ReadLine();

        Console.Write("Date Beat: ");
        string DateBeat = Console.ReadLine();

        int Hours = Helpers.GetHours();
        int Minutes = Helpers.GetMinutes();
        int Rating = Helpers.GetRating();

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var InsertRecord = connection.CreateCommand();

            InsertRecord.CommandText =
                $@"INSERT INTO games (Title, Genre, DateBeat, Hours, Minutes, Rating)
                VALUES (value1, value2, value3, ...)";
        }

    }

    internal void DeleteRecords()
    {
        Console.WriteLine("Delete records page");
    }

    internal void UpdateRecords()
    {
        Console.WriteLine("Update records page");
    }

}
