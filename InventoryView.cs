using System;
using Services;

namespace Views
{
    public class InventoryView
    {
        private InventoryService service = new InventoryService();

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Inventory Menu ===");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Reset Inventory");
                Console.WriteLine("4. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewInventory();
                        break;

                    case "2":
                        UpdateStock();
                        break;

                    case "3":
                        service.ResetStock();
                        Console.WriteLine("Inventory reset successfully.");
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void ViewInventory()
        {
            string[,] products = service.GetProducts();

            Console.WriteLine("\nCurrent Inventory:");
            for (int i = 0; i < products.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]} - Stock: {products[1, i]}");
            }
        }

        private void UpdateStock()
        {
            ViewInventory();
            Console.Write("Select product number: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Enter new stock quantity: ");
            string newStock = Console.ReadLine();

            service.UpdateStock(index, newStock);
            Console.WriteLine("Stock updated successfully.");
        }
    }
}
