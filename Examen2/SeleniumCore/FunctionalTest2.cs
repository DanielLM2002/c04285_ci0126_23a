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
    public class createVehicle
    {
        IWebDriver _driver;
        IWebDriver _driver2;
        [TestMethod]
        public void CreateVehicle()
        {
            var outputDirectory = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputDirectory);
            _driver.Navigate().GoToUrl("https://localhost:7227");
            _driver.Navigate().GoToUrl("https://localhost:7227/Vehiculos");

            var vehiculosAniadirButtonLocator = By.Id("Aniadir");
            var Aniadir = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            Aniadir.Until(ExpectedConditions.ElementIsVisible(
                         vehiculosAniadirButtonLocator));

            var vehiculosAniadirButton = _driver.FindElement(
                                         vehiculosAniadirButtonLocator);
            vehiculosAniadirButton.Click();

            var NombreFieldAniadir = _driver.FindElement(By.Id("NombreForm"));
            var TipoFieldAniadir = _driver.FindElement(By.Id("TipoForm"));
            var PopularidadAniadir = _driver.FindElement(By.Id("PopularidadForm"));
            var PrecioAniadir = _driver.FindElement(By.Id("PrecioForm"));
            var LicenciaAniadir = _driver.FindElement(By.Id("LicenciaForm"));
            var IdAniadir = _driver.FindElement(By.Id("IdForm"));

            NombreFieldAniadir.SendKeys("ChiquiMovilPlus");
            TipoFieldAniadir.SendKeys("Terrestre");
            PopularidadAniadir.SendKeys("Alta");
            PrecioAniadir.SendKeys("2550");
            LicenciaAniadir.Click();
            IdAniadir.SendKeys("777");

            var submitBtnLocator = By.Id("ButtonAniadirCrear");
            var submitBtn = _driver.FindElement(submitBtnLocator);
            Assert.IsTrue(submitBtn.Enabled);
            submitBtn.Click();

        }

        [TestMethod]
        public void EliminateVehicle()
        {
            var outputDirectory2 = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            _driver2 = new ChromeDriver
        }


        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}