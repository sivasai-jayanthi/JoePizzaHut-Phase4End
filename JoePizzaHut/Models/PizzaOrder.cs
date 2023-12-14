namespace JoePizzaHut.Models
{

    public class PizzaOrder
    {
        public string PizzaType { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        // Dictionary to store base prices for each pizza type
        private static readonly Dictionary<string, decimal> BasePrices = new Dictionary<string, decimal>
    {
        { "Margherita", 10.00m },
        { "Pepperoni", 12.00m },
        { "Vegetarian", 11.50m },
        { "BBQChicken", 20.0m }
        // Add more pizza types and their respective prices
    };

        // Pricing logic
        public static decimal CalculateAmount(string pizzaType, int quantity)
        {
            // Check if the pizza type is in the dictionary; if not, use a default price
            decimal basePrice = BasePrices.TryGetValue(pizzaType, out var price) ? price : 10.00m;

            // Calculate the amount based on the base price and quantity
            return basePrice * quantity;
        }
    }


}
