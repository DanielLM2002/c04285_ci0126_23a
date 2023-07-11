using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

            //var goToData = _driver.FindElement(By.Name("Vehiculos"));

        }
        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}

