using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAWeeklyCheck.Customers
{
    class SignIn
    {
        public SignIn(IWebDriver driver)
        {
            driver.FindElement(By.Name("log")).SendKeys("UserName");
            driver.FindElement(By.Name("pwd")).SendKeys("Password");
            driver.FindElement(By.XPath("//*[@id=\"submit\"]")).Click();
        }
    }
}
