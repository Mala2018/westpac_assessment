using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestsWestPac
{
    class DriverInitializer
    {
        public static IWebDriver Driver;
        public static void Initialize(string Browsername)
        {
            switch (Browsername)
            {
                case "firefox":
                    Driver = new FirefoxDriver();
                    break;
                case "iexplore":
                    Driver = new InternetExplorerDriver();
                    break;
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
            options.AddArguments("always-authorize-plugins");
            options.AddArguments("test-type");
            options.AddArgument("enable-automation");
            options.AddArgument("--disable-infobars");
            Driver = new ChromeDriver(options);
            Thread.Sleep(2000);
            Driver.Manage().Window.Maximize();
                    break;
            }
        }
        
    }
}
