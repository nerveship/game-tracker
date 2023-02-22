using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Menu
{
    internal static void MainMenu()
        {
            Console.Clear();
            bool closeApp = false;
            DatabaseActions databaseActions = new DatabaseActions();

            while (closeApp == false)
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
                        databaseActions.ViewRecords();
                        break;

                    case "2":
                        databaseActions.InsertRecords();
                        break;

                    case "3":
                        databaseActions.DeleteRecords();
                        break;

                    case "4":
                        databaseActions.UpdateRecords();
                        break;
                }
            }
        }
    }
