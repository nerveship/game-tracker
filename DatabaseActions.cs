using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        int Hours = GetHours();
        int Minutes = GetMinutes();
        int Rating = GetRating();

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var InsertRecord = connection.CreateCommand();

            InsertRecord.CommandText =
                $@"INSERT INTO games (Title, Genre, DateBeat, Hours, Minutes, Rating)
                VALUES (value1, value2, value3, ...)";
        }

    }

    internal static int GetHours()
    {
        Console.Write("Hours: ");
        string StringHours = Console.ReadLine();
        int Hours;
        while (!int.TryParse(StringHours, out Hours))
        {
            Console.WriteLine("Please input numbers");
            StringHours = Console.ReadLine();
        }
        return Hours;
    }

    internal static int GetMinutes()
    {
        Console.Write("Minutes: ");
        string StringMinute = Console.ReadLine();
        int minutes;

        while (!int.TryParse(StringMinute, out minutes))
        {
            Console.WriteLine("Please input numbers");
            StringMinute = Console.ReadLine();
        }

        while (minutes > 59 || minutes < 1)
        {
            Console.WriteLine("Please input an no. of minutes between 1 and 59");
            Console.Write("Minutes: ");
            minutes = Convert.ToInt32(Console.ReadLine());
        }
        return minutes;
    }
        
    internal static int GetRating()
    {
        Console.Write("Rating: ");
        string StringRating = Console.ReadLine();
        int rating;

        while (!int.TryParse(StringRating, out rating))
        {
            Console.WriteLine("Please input numbers");
            StringRating = Console.ReadLine();
        }

        while (rating > 5 || rating < 1)
        {
            Console.WriteLine("Please input a rating between 1 and 5");
            Console.Write("Rating: ");
            rating = Convert.ToInt32(Console.ReadLine());
        }
        return rating;
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
