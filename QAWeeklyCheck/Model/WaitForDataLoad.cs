using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QAWeeklyCheck.Model
{
    class WaitForDataLoad
    {
        public static bool DataLoad(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var dataLoaded = wait.Until(x =>
            {
                bool isAjaxFinished = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0");
                bool isLoaderHidden = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return $('.roll-bg').is(':visible') == false");
                return isAjaxFinished & isLoaderHidden;
            });

            return dataLoaded;
        }
    }
}
