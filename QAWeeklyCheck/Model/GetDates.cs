using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QAWeeklyCheck.Model;

namespace QAWeeklyCheck.Model
{
    public class GetDates
    {
        private string values;
        private string v1;
        private string v2;
        private int count1;
        private int count2;
        private string _id;
        private string lastDate;
       
        FixedElement el = new FixedElement();
        Log log = new Log();
        WaitForDataLoad wfdl = new WaitForDataLoad();
        

        public void LastDate(IWebDriver driver, string id, string Plantname)
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            el.ID = id;

            var count1 = wait.Until(x => x.FindElement(By.XPath(el.Values))).GetAttribute("value").Count();

            v1 = wait.Until(x => x.FindElement(By.XPath(el.Values))).GetAttribute("value");
            //WaitForDataLoad.DataLoad(driver);
            //var dataLoaded = wait.Until(x =>
            //{
            //    bool isAjaxFinished = (bool)((IJavaScriptExecutor)driver).
            //        ExecuteScript("return jQuery.active == 0");
            //    bool isLoaderHidden = (bool)((IJavaScriptExecutor)driver).
            //        ExecuteScript("return $('.roll-bg').is(':visible') == false");
            //    return isAjaxFinished & isLoaderHidden;
            //});

            if(WaitForDataLoad.DataLoad(driver))
                driver.FindElement(By.XPath(el.Update)).Click();// Click on Update Button

            Thread.Sleep(5000);

            var count2 = wait.Until(x => x.FindElement(By.XPath(el.Values))).GetAttribute("value").Count(); // Get count of resulte beffor clicking update button
            v2 = wait.Until(x => x.FindElement(By.XPath(el.Values))).GetAttribute("value");

            if (count1 != count2 || v1 != v2)
                values = wait.Until(x => x.FindElement(By.XPath(el.Values))).GetAttribute("value"); // Count of resulte after ckicking update

            values = ReplaceCharecters.Clean(values);
            var splitedValues = values.Split(',');
            var gld = new GetLastDate(splitedValues.ToList());
            lastDate = gld.Date();

            if (lastDate == null)
            {
                Console.WriteLine(@"    {0} : No data for year", Plantname);
                log.Data("No data for year", Plantname);
            }

            else
            {
                Console.WriteLine(@"    {0} : {1}", Plantname, lastDate);
                log.Data(lastDate, Plantname);
            }
                

           
        }

        public static void WaitForData(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                bool isAjaxFinished = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0");
                bool isLoaderHidden = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return $('.roll-bg').is(':visible') == false");
                return  isLoaderHidden;
            });
        }


    }
}
