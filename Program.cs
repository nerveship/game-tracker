using System;
using Microsoft.Data.Sqlite;

string connectionString = @"Data Source=GameTracker.db";
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
}

Menu menu = new Menu();

menu.MainMenu();
