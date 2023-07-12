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
    public class ModifyVehicle
    {
        IWebDriver _driver;
        [TestMethod]
        public void ModifyVehicleTest()
        {
            var outputDirectory = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputDirectory);
            _driver.Navigate().GoToUrl("https://localhost:7227");
            _driver.Navigate().GoToUrl("https://localhost:7227/Vehiculos");

            var vehiculosModificarButtonLocator = By.Id("EditButton");
            var Aniadir = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            Aniadir.Until(ExpectedConditions.ElementIsVisible(
                         vehiculosModificarButtonLocator));

            var vehiculosModificarButton = _driver.FindElement(
                vehiculosModificarButtonLocator);
            vehiculosModificarButton.Click();
            _driver.SwitchTo().Alert().Accept();

            var NombreFieldModify = _driver.FindElement(By.Id("NombreForm"));
            NombreFieldModify.Clear();
            NombreFieldModify.SendKeys("ChiquiMovilMinus");


            var saveBtnLocator = By.Id("modifyButton");
            var submitBtn = _driver.FindElement(saveBtnLocator);
            Assert.IsTrue(submitBtn.Enabled);
            submitBtn.Click();
        }


        //[TestCleanup]
        //public void CleanUp()
        //{
        //    _driver.Quit();
        //}
    }
}
