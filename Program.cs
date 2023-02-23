using System;
using Microsoft.Data.Sqlite;

class Program
{
    internal static string connectionString = @"Data Source=GameTracker.db";

    Menu menu = new Menu();

    static void Main()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS games (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Title TEXT,
                                Genre TEXT,
                                DateBeat TEXT,
                                Hours INTEGER,
                                Minutes INTEGER,
                                Rating INTEGER,
                                MaxRating INTEGER
                                )";
            tableCmd.ExecuteNonQuery();

            Menu.MainMenu();
        }
    }
}


