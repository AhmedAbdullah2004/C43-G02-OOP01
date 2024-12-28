using System;
using System.ComponentModel;

namespace EnumExamples
{
    // 1.
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    // 2.
    enum Seasons
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    // 3.
    [Flags]
    enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8
    }

    // 4. 
    enum Colors
    {
        Red,
        Green,
        Blue
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 1-Create an Enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this Enum.

            Console.WriteLine("Days of the Week:");
            foreach (var day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(day);
            }
            #endregion

            #region 2-Create an Enum called "Seas on" with the four seasons (Spring, Summer, Autumn, Winter) as its members. Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)
            Console.Write("Enter a season (Spring, Summer, Autumn, Winter): ");
            string seasonInput = Console.ReadLine();
            if (Enum.TryParse(seasonInput, true, out Seasons season))
            {
                switch (season)
                {
                    case Seasons.Spring:
                        Console.WriteLine("Spring: March to May");
                        break;
                    case Seasons.Summer:
                        Console.WriteLine("Summer: June to August");
                        break;
                    case Seasons.Autumn:
                        Console.WriteLine("Autumn: September to November");
                        break;
                    case Seasons.Winter:
                        Console.WriteLine("Winter: December to February");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid season entered.");
            }

            #endregion

            #region 3-Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum.Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission existed inside variable

            Permissions userPermissions = Permissions.None;
            Console.WriteLine("Adding Read and Write permissions.");
            userPermissions |= Permissions.Read | Permissions.Write;
            Console.WriteLine($"Current Permissions: {userPermissions}");

            Console.WriteLine("Removing Write permission.");
            userPermissions &= ~Permissions.Write;
            Console.WriteLine($"Current Permissions: {userPermissions}");

            Console.WriteLine("Checking if Execute permission exists:");
            bool hasExecute = (userPermissions & Permissions.Execute) == Permissions.Execute;
            Console.WriteLine(hasExecute ? "Execute permission exists." : "Execute permission does not exist.");
            #endregion

            #region 4-Create an Enum called "Colors" with the basic colors (Red, Green, Blue) as its members. Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.

            Console.Write("Enter a color (Red, Green, Blue): ");
            string colorInput = Console.ReadLine();
            if (Enum.TryParse(colorInput, true, out Colors color))
            {
                if (color == Colors.Red || color == Colors.Green || color == Colors.Blue)
                {
                    Console.WriteLine($"{color} is a primary color.");
                }
                else
                {
                    Console.WriteLine($"{color} is not a primary color.");
                }
            }
            else
            {
                Console.WriteLine("Invalid color entered.");
            }
            #endregion
        }
    }
}
