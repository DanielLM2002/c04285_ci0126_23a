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

            var vehiculosModificarButtonLocator = By.Id("EditButton-ChiquiMovilPlus");

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


        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
