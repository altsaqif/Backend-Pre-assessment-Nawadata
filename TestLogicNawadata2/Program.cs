using System;
using System.Linq;

namespace TestLogicNawadata2
{
    public class Program
    {
        // Method Calculate Minimum Bus
        public static int CalculateMinimumBus(int n, int[] familyMembers)
        {
            if (familyMembers.Length != n)
            {
                Console.WriteLine("Input must be equal with count of family");
                return -1;
            }

            Array.Sort(familyMembers);

            int bus = 0;
            int i = 0;
            int j = n - 1;

            while (i <= j)
            {
                if (familyMembers[i] + familyMembers[j] <= 4)
                {
                    i++;
                }
                j--;
                bus++;
            }

            return bus;
        }

        // Method Main
        public static void Main(string[] args)
        {
            Console.Write("Input the number of family : ");
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Input must be equal with count of family");
                return;
            }

            Console.Write("Input the number of members in the family (separated by a space) : ");

            string input = Console.ReadLine() ?? string.Empty;

            int[] familyMembers = input.Split(' ').Select(int.Parse).ToArray();

            int result = CalculateMinimumBus(n, familyMembers);
            if (result != -1)
            {
                Console.WriteLine($"Minimum bus required is : {result}");
            }
        }
    }
}