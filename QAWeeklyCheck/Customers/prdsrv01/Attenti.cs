using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAWeeklyCheck.Model;
using QAWeeklyCheck.Customers;
using System.Threading;


namespace QAWeeklyCheck
{
    [TestFixture]
    public class Attenti
    {
        IWebDriver driver = new Driver().driver;
        IWebElement ele;
        FixedElement el = new FixedElement();
        private string Plantname;
        private string lastDate;

        [SetUp]
        public void StartBrowser()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "https://prdsrv01.quality-line.org/sign-in/";

            new SignIn(driver);

            driver.Url = "https://prdsrv01.quality-line.org/3m/";

            AttentiWeb();
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        [Test]
        public void AttentiWeb()
        {
            new Log().Data(string.Empty, "Attenti");

            #region Assemblies Dashboard
            // Get id of class "filterfrom"
            el.ID = driver.FindElement(By.ClassName("filterform")).GetAttribute("id").ToString();

            Console.WriteLine("Attenti:");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            // Maximiz dashboard
            wait.Until(x => x.FindElement(By.XPath("//*[@id=\"chartDB\"]/div[1]/div[1]/div[1]/div[1]/div/span[7]"))).Click();

            driver.FindElement(By.XPath(el.Resolution)).Click();

            // Choose resoluution Day
            driver.FindElement(By.XPath(el.Day)).Click();

            var idOfFilters = el.ID.Split('_');

            var valOfPlants = driver.FindElement(By.Id("fd_plants_" + idOfFilters[1] + "")).GetAttribute("data-original-val").Replace("\"", "");
            

            valOfPlants = ReplaceCharecters.Clean(valOfPlants);

            var plants = valOfPlants.Split(',');

            var i = 1;

            foreach (var pl in plants)
            {
                Thread.Sleep(5000);

                // Click to open list of plants
                driver.FindElement(By.XPath(el.Plant)).Click();

                // Deselect all
                driver.FindElement(By.XPath(el.DeselectAllPlants)).Click();
                Thread.Sleep(5000);

                // Choosing Plant
                driver.FindElement(By.XPath("//*[@id=\"" + el.ID + "\"]/div[2]/div[1]/div/div/ul/li[" + i + "]/a/span[1]")).Click();

                // Plant name
                Plantname = pl;
                

                Thread.Sleep(5000);
                new GetDates().LastDate(driver, el.ID, Plantname);
                i++;
            }
            #endregion

            #region Repairs
            // Click on My Dashboards in menu 
            driver.FindElement(By.XPath("//*[@id=\"menu-item-77\"]/a/i")).Click();

            // Choosing Repairs on menu
            driver.FindElement(By.XPath("//*[@id=\"menu-item-105\"]/a/i")).Click();

            // Get id of class "filterfrom"
            el.ID = driver.FindElement(By.ClassName("filterform")).GetAttribute("id").ToString();

            // Maximize repairs dashboard
            driver.FindElement(By.XPath(el.MaximizeFirstDashboard)).Click();
            Thread.Sleep(5000);

            // Open resolution list

            driver.FindElement(By.XPath(el.RepairResolution)).Click();
            Thread.Sleep(5000);

            // Choosing resolution Day
            driver.FindElement(By.XPath(el.RepairResolutionDay)).Click();
            Thread.Sleep(5000);
            Plantname = "Repairs";
            

            new GetDates().LastDate(driver, el.ID, Plantname);


            // Need to set on commect when run only on test
            CloseBrowser();
            #endregion
        }

        [TearDown]
        public void CloseBrowser()
        {

            driver.Quit();
        }
    }
}
