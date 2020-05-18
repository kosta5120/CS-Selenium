using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAWeeklyCheck.Customers;
using QAWeeklyCheck.Customers.prdsrv02;
using QAWeeklyCheck.Customers.prdsrv03;

namespace QAWeeklyCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            new Attenti().StartBrowser();
            new Stanley().StartBrowser();
            new Servotronix().StartBrowser();
            new Gilat().StartBrowser();
            new Invenco().StartBrowser();
        }
    }
}
