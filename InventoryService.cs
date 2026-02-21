namespace Services
{
    public class InventoryService
    {
        private string[,] products =
        {
            { "Apples", "Milk", "Bread" },
            { "10", "5", "20" }
        };

        private string[] initialStock = { "10", "5", "20" };

        public string[,] GetProducts()
        {
            return products;
        }

        public void UpdateStock(int index, string newStock)
        {
            products[1, index] = newStock;
        }

        public void ResetStock()
        {
            for (int i = 0; i < initialStock.Length; i++)
            {
                products[1, i] = initialStock[i];
            }
        }
    }
}
