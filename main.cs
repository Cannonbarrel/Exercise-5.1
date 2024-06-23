using System;
namespace HomeSalesApp {
class HomeSales {
  public static void Main (string[] args) {
    string[] salespersonNames = { "Danielle (D)", "Edward (E)", "Francis (F)" };
        char[] allowedInitials = { 'D', 'E', 'F' };
        double[] salesTotals = { 0, 0, 0 };

        while (true)
        {
            Console.Write("Enter the salesperson's initial (D, E, F) or 'Z' to quit: ");
            string initialInput = Console.ReadLine().ToUpper();

            if (initialInput == "Z")
            {
                break;
            }

            char initialChar = initialInput.Length == 1 ? initialInput[0] : '\0';

            int index = Array.IndexOf(allowedInitials, initialChar);

            if (index == -1)
            {
                Console.WriteLine("Error, Invalid initial entered. Please enter D, E, F, or Z.");
                continue;
            }

            Console.Write("Enter the amount of sale: ");
            if (!double.TryParse(Console.ReadLine(), out double saleAmount) || saleAmount < 0)
            {
                Console.WriteLine("Error, Invalid sale amount entered. Please enter a positive number.");
                continue;
            }

            salesTotals[index] += saleAmount;
        }

        double grandTotal = 0;
        for (int i = 0; i < salesTotals.Length; i++)
        {
            grandTotal += salesTotals[i];
        }

        Console.WriteLine("\nSales Summary:");
        for (int i = 0; i < salespersonNames.Length; i++)
        {
            Console.WriteLine($"Total sales by {salespersonNames[i]}: {salesTotals[i]:C}");
        }
        Console.WriteLine($"Grand total sales: {grandTotal:C}");

        int highestIndex = 0;
        for (int i = 1; i < salesTotals.Length; i++)
        {
            if (salesTotals[i] > salesTotals[highestIndex])
            {
                highestIndex = i;
            }
        }

        Console.WriteLine($"Salesperson with the highest total: {salespersonNames[highestIndex]} with {salesTotals[highestIndex]:C}");
    }
  }
}