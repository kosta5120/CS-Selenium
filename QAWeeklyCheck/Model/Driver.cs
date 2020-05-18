using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAWeeklyCheck.Model
{
    
    public class Driver
    {
        public IWebDriver driver;
        public Driver()
        {
            driver = new ChromeDriver();
        }
        //public IWebDriver driver { get { return new ChromeDriver(); }}
    }
}
