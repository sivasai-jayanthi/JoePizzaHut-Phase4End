namespace JoePizzaHut.Models
{
    // Models/OrderConfirmationViewModel.cs
    public class OrderConfirmationViewModel
    {
        public Guid OrderId { get; set; }
        public string PizzaType { get; set; }
        public decimal Amount { get; set; }
    }
}
