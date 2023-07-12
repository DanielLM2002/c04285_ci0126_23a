using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.IO;
using System.Reflection;



namespace SeleniumCore
{
    [TestClass]
    public class HomePageFeature
    {
        IWebDriver _driver;
        [TestMethod]
        public void ReadData()
        {
            var outputDirectory = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputDirectory);
            _driver.Navigate().GoToUrl("https://localhost:7227");

            var vehiculosButtonLocator = By.Id("goToVehiculos");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(vehiculosButtonLocator));

            var vehiculosButton = _driver.FindElement(vehiculosButtonLocator);
            vehiculosButton.Click();

            Assert.IsTrue(_driver.Url.Contains("https://localhost:7227/Vehiculos"));


        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}

