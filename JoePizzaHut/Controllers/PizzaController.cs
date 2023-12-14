using JoePizzaHut.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JoePizzaHut.Controllers
{

    public class PizzaController : Controller
    {
        public IActionResult PizzaSelection()
        {
            return View();
        }


        [HttpPost]
        public IActionResult OrderCheckout(PizzaOrder pizzaOrder)
        {
            // Calculate the amount using the updated pricing logic
            pizzaOrder.Amount = PizzaOrder.CalculateAmount(pizzaOrder.PizzaType, pizzaOrder.Quantity);

            // Serialize PizzaOrder to JSON and store in TempData
            TempData["PizzaOrder"] = JsonConvert.SerializeObject(pizzaOrder);

            return View("OrderCheckout", pizzaOrder);
        }





        public IActionResult OrderConfirmation()
        {
            // Retrieve the serialized PizzaOrder from TempData
            var pizzaOrderJson = TempData["PizzaOrder"] as string;

            if (!string.IsNullOrEmpty(pizzaOrderJson))
            {
                // Deserialize PizzaOrder from JSON
                var pizzaOrder = JsonConvert.DeserializeObject<PizzaOrder>(pizzaOrderJson);

                // Generate order confirmation logic (e.g., order ID)

                // Pass necessary data to the view
                var orderConfirmationViewModel = new OrderConfirmationViewModel
                {
                    OrderId = Guid.NewGuid(), // Example: Generate a unique order ID
                    PizzaType = pizzaOrder.PizzaType,
                    Amount = pizzaOrder.Amount
                };

                return View(orderConfirmationViewModel);
            }

            // Handle the case where TempData is null or doesn't contain PizzaOrder
            return RedirectToAction("PizzaSelection");
        }


    }

}
