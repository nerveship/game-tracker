namespace game_tracker
{
    internal class Helpers
    {
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

        internal static int GetNumberInput(string Prompt)
        {
            Console.WriteLine(Prompt);
            string Input = Console.ReadLine();
            int ConvertedInput;

            while (!int.TryParse(Input, out ConvertedInput))
            {
                Console.WriteLine("Please input numbers");
                ConvertedInput = Convert.ToInt32(Input);
            }
            return ConvertedInput;
        }
    }
}
