
using Microsoft.AspNetCore.Mvc;
using JoePizzaHut.Controllers;
using JoePizzaHut.Models;

namespace JoePizzaHut
{
    [TestFixture]
    public class PizzaControllerTests
    {
        [Test]
        public void PizzaSelection_ReturnsViewResult()
        {
            // Arrange
            var controller = new PizzaController();

            // Act
            var result = controller.PizzaSelection();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void PizzaSelection_ViewResultHasCorrectViewName()
        {
            // Arrange
            var controller = new PizzaController();

            // Act
            var result = controller.PizzaSelection() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == nameof(controller.PizzaSelection));
        }



        [Test]
        public void PizzaSelection_ViewResultModelIsNull()
        {
            // Arrange
            var controller = new PizzaController();

            // Act
            var result = controller.PizzaSelection() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }

        

       


        [Test]
        public void CalculateAmount_ReturnsCorrectAmount()
        {
            // Arrange
            var pizzaOrder = new PizzaOrder { PizzaType = "Margherita", Quantity = 2 };

            // Act
            var amount = PizzaOrder.CalculateAmount(pizzaOrder.PizzaType, pizzaOrder.Quantity);

            // Assert
            Assert.AreEqual(20.00m, amount); // Assuming CalculateAmount works correctly
        }




    }
}

