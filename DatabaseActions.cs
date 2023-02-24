using game_tracker;
using Microsoft.Data.Sqlite;
using System.Globalization;

internal class DatabaseActions
{
    Program program = new Program();
    Menu menu = new Menu();

    internal void ViewRecords(string connectionString)
    {
        Console.Clear();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var ViewAll = connection.CreateCommand();

            ViewAll.CommandText =
                $"SELECT * FROM games ";

            List<games> tableData = new();

            SqliteDataReader reader = ViewAll.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tableData.Add(
                        new games
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Genre = reader.GetString(2),
                            DateBeat = reader.GetString(3),
                            Hours = reader.GetInt32(4),
                            Minutes = reader.GetInt32(5),
                            Rating = reader.GetInt32(6),
                        });
                }
            }
            else
            {
                Console.WriteLine("No rows found");
                Console.ReadKey();
                Menu.MainMenu();
            }

            connection.Close();

            foreach (var ent in tableData)
            {
                Console.WriteLine($"ID: {ent.Id}\n" +
                    $"Title: {ent.Title}\n" +
                    $"Genre: {ent.Genre}\n" +
                    $"Date beat: {ent.DateBeat}\n" +
                    $"Hours: {ent.Hours}\n" +
                    $"Minutes: {ent.Minutes}\n" +
                    $"Rating: {ent.Rating}\n");
            }
            Console.ReadKey();
        }
    }

    internal void InsertRecords(string connectionString)
    {
        Console.Clear();
        Console.WriteLine("Please insert valid input for each type, or enter 0 to return to the main menu.");
        Console.Write("Title: ");
        string Title = Console.ReadLine();

        if (Title == "0")
        {
            Menu.MainMenu();
        }

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
                "INSERT INTO games(Title, Genre, DateBeat, Hours, Minutes, Rating)" +
                $"VALUES('{Title}', '{Genre}', '{DateBeat}', {Hours}, {Minutes}, {Rating})";

            InsertRecord.ExecuteNonQuery();
            connection.Close();
        }

    }

    internal void DeleteRecords()
    {
        Console.Clear();
        ViewRecords(Program.connectionString);
        var recordID = Helpers.GetNumberInput("Enter a number for which record you wish to delete, or enter 0 to go back to the main menu");

        if (recordID == 0)
        {
            Menu.MainMenu();
        }
        
        using (var connection = new SqliteConnection(Program.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = $"DELETE from games WHERE id = '{recordID}'";

            int rowCount = tableCmd.ExecuteNonQuery();

            if (rowCount == 0)
            {
                Console.WriteLine($"Record with the Id {recordID} does not exist.");
                DeleteRecords();
            }
        }
    }

    internal void UpdateRecords()
    {
        Console.Clear();
        ViewRecords(Program.connectionString);

        int IdChoice = Helpers.GetNumberInput("Which record would you like to update?");

        Console.WriteLine("Write the updated values accordingly");

        Console.Write("Title: ");
        string Title = Console.ReadLine();

        if (Title == "0")
        {
            Menu.MainMenu();
        }

        Console.Write("Genre: ");
        string Genre = Console.ReadLine();

        Console.Write("Date Beat: ");
        string DateBeat = Console.ReadLine();

        int Hours = Helpers.GetHours();
        int Minutes = Helpers.GetMinutes();
        int Rating = Helpers.GetRating();

        using (var connection = new SqliteConnection(Program.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = $"UPDATE games SET Title = '{Title}', Genre = '{Genre}', DateBeat = '{DateBeat}', Hours = {Hours}, Minutes = {Minutes}, Rating = {Rating} WHERE Id = {IdChoice}";

            tableCmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}

internal class games
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string DateBeat { get; set; }
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Rating { get; set; }
}
