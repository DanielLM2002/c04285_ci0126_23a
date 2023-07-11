using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;



namespace SeleniumCore
{
    [TestClass]
    public class HomePageFeature
    {
        [TestMethod]
        public void ReadData()
        {
            var outputDirectory = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(outputDirectory);
            driver.Navigate().GoToUrl("https://saucedemo.com");

        }
    }
}

