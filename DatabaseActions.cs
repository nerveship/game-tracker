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
        Console.WriteLine("Insert records page");
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
