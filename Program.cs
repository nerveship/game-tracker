using System;
using Microsoft.Data.Sqlite;

namespace GameTracker
{
    class Program
    {
        static void Main()
        {
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

            GetUserInput();
        }

        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;

            while(closeApp == false)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. View all records");
                Console.WriteLine("2. Insert record");
                Console.WriteLine("3. Delete record");
                Console.WriteLine("4. Update record");
                Console.WriteLine("----------------------------------");

                string commandInput = Console.ReadLine();

                switch (commandInput)
                {
                    case "0":
                        Console.WriteLine("Goodbye!");
                        closeApp = true;
                        break;

                    case "1":
                        Console.WriteLine("View record screen");
                        //ViewRecords();
                        break;

                    case "2":
                        Console.WriteLine("Insert record screen");
                        //InsertRecord();
                        break;

                    case "3":
                        Console.WriteLine("Delete record screen");
                        //DeleteRecord();
                        break;

                    case "4":
                        Console.WriteLine("Update record screen");
                        //UpdateRecord();
                        break;
                }
            }
        }
    }
}