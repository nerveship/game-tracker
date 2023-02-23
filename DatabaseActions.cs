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

    internal void InsertRecords()
    {
        Console.Clear();
        Console.WriteLine("Please insert valid input for each type.");
        GetDataTypes();
    }

    private static void GetDataTypes()
    {
        Console.Write("Title: ");
        string Title = Console.ReadLine();

        Console.Write("Genre: ");
        string Genre = Console.ReadLine();

        Console.Write("Date Beat: ");
        string DateBeat = Console.ReadLine();

        Console.Write("Hours: ");
        string StringHours = Console.ReadLine();
        int Hours;
        while (!int.TryParse(StringHours, out Hours))
        {
            Console.WriteLine("Please input numbers");
            StringHours = Console.ReadLine();
        }


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
