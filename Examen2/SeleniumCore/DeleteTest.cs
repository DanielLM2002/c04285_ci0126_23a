using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Reflection;


///<summary>
/// Esta prueba modifica el item creado en la prueba anterior, este hace un procedimiento
/// similar a la anterior de crear el objeto. Esta prueba le cambia el nombre a vehiculo y guarda los cambios.
///</summary>
namespace SeleniumCore
{
    [TestClass]
    public class DeleteVehicle
    {
        IWebDriver _driver;
        [TestMethod]
        public void DeleteVehicleTest()
        {
            var outputDirectory = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputDirectory);
            _driver.Navigate().GoToUrl("https://localhost:7227");
            _driver.Navigate().GoToUrl("https://localhost:7227/Vehiculos");

            var vehiculosBorrarrButtonLocator = By.Id("DeleteButton-ChiquiMovilPlus");

            var vehiculosBorrarButton = _driver.FindElement(
                vehiculosBorrarrButtonLocator);
            vehiculosBorrarButton.Click();
            _driver.SwitchTo().Alert().Accept();
        }


        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}