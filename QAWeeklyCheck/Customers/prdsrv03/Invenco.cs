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
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace QAWeeklyCheck.Customers.prdsrv03
{
    
    public class Invenco
    {
        IWebDriver driver = new Driver().driver;
        IWebElement ele;
        FixedElement el = new FixedElement();
        private string Plantname;
        [SetUp]
        public void StartBrowser()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "https://prdsrv03.quality-line.org/sign-in/";

            new SignIn(driver);

            driver.Url = "https://prdsrv03.quality-line.org/invenco/";

            InvencoWeb();
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        [Test]
        public void InvencoWeb()
        {

            new Log().Data(string.Empty, "Invenko");

            // Get id of class "filterfrom"
            el.ID = driver.FindElement(By.ClassName("filterform")).GetAttribute("id").ToString();

            Console.WriteLine("Invenco:");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            #region Assemblies Dashboard
            wait.Until(x => x.FindElement(By.XPath("//*[@id=\"chartDB\"]/div[1]/div[1]/div[1]/div[1]/div/span[7]"))).Click(); // Maximiz dashboard

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
                Thread.Sleep(5000);

                // Deselect CRT from Process filter
                try
                {
                    var process = driver.FindElement(By.Name("fd_processes[]"));
                    var selectElement = new SelectElement(process);
                    selectElement.DeselectByValue("CRT station ");
                }
                catch { }


                // Plant name
                Plantname = pl;

                Thread.Sleep(5000);
                new GetDates().LastDate(driver, el.ID, Plantname);
                i++;
            }
            #endregion

            #region Check CRT process in testins Station
            // Click on My Dashboards in menu 
            driver.FindElement(By.XPath("//*[@id=\"menu-item-77\"]/a/i")).Click();

            // Click on Testing Stations
            driver.FindElement(By.XPath("//*[@id=\"menu-item-152\"]/a/i")).Click();

            // Get id of class "filterfrom"
            el.ID = driver.FindElement(By.ClassName("filterform")).GetAttribute("id").ToString();

            // Maximize repairs dashboard
            driver.FindElement(By.XPath(el.MaximizeFirstDashboard)).Click();
            Thread.Sleep(5000);

            // Open Resolution list
            driver.FindElement(By.XPath(el.Resolution)).Click();

            // Choosing Day
            driver.FindElement(By.XPath(el.Day)).Click();
            Thread.Sleep(5000);

            // Open Dropdown list of Processes
            driver.FindElement(By.XPath("//*[@data-id=\"fd_processes_17609\"]")).Click();

            // Deselect All 
            driver.FindElement(By.XPath(el.DeselectAllProcessesTS)).Click();

            // Input process name in search box
            driver.FindElement(By.XPath(el.SearchTBProcess)).SendKeys("CRT station");
            // Chosing the process from search
            Thread.Sleep(5000);

            driver.FindElement(By.XPath(el.SearchTBProcess)).SendKeys(Keys.Enter);
            Thread.Sleep(500);
            // Click on buten Filter
            driver.FindElement(By.XPath(el.Update));
            Thread.Sleep(5000);

            Plantname = "CRT Manual Testing";
            new GetDates().LastDate(driver, el.ID, Plantname);
            #endregion

            #region AOI

            // Click on My Dashboards in menu 
            driver.FindElement(By.XPath("//*[@id=\"menu-item-77\"]/a/i")).Click();

            // Click on AOI
            driver.FindElement(By.XPath("//*[@id=\"menu-item-1503\"]/a/i")).Click();

            // Get id of class "filterfrom"
            el.ID = driver.FindElement(By.ClassName("filterform")).GetAttribute("id").ToString();

            // Maximize repairs dashboard
            driver.FindElement(By.XPath(el.MaximizeFirstDashboard)).Click();
            Thread.Sleep(5000);

            // Open Resolution list
            driver.FindElement(By.XPath(el.Resolution)).Click();

            // Choosing Day
            driver.FindElement(By.XPath(el.Day)).Click();
            Thread.Sleep(5000);

            // Click on buten Filter
            driver.FindElement(By.XPath(el.Update));
            Thread.Sleep(5000);
            Plantname = "AOI";
            new GetDates().LastDate(driver, el.ID, Plantname);

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

            #endregion

            #region RMA

            // Click on My Dashboards in menu 
            driver.FindElement(By.XPath("//*[@id=\"menu-item-77\"]/a/i")).Click();

            // Choosing Repairs on menu
            driver.FindElement(By.XPath("//*[@id=\"menu-item-1480\"]/a/i")).Click();

            // Get id of class "filterfrom"
            el.ID = driver.FindElement(By.ClassName("filterform")).GetAttribute("id").ToString();

            // Maximize repairs dashboard
            driver.FindElement(By.XPath(el.MaximizeFirstDashboard)).Click();
            Thread.Sleep(5000);

            driver.FindElement(By.XPath(el.RepairResolution)).Click();
            Thread.Sleep(5000);

            // Choosing resolution Day
            driver.FindElement(By.XPath(el.RmaDay)).Click();
            Thread.Sleep(5000);
            Plantname = "RMA";

            new GetDates().LastDate(driver, el.ID, Plantname);

            #endregion

            // Need to set on commect when run only on test
            CloseBrowser();
        }

        [TearDown]
        public void CloseBrowser()
        {

            driver.Quit();
        }
    }
}
