using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace TestsWestPac
{
    class HomePage
    {
        public IWebElement FXTravelMigrant()
        {
            IWebElement fxTravel= DriverInitializer.Driver.FindElement(By.XPath("//*[@id='ubermenu-section-link-fx-travel-and-migrant-ps']"));
            return fxTravel;
        }
        public IWebElement Converter()
        {
            IWebElement convertCurrency = DriverInitializer.Driver.FindElement(By.XPath("//a[contains(text(),'Currency converter')]"));
            return convertCurrency;
        }
        public void NavigateToConvertCurrencyPage()
        {
            Actions _action = new Actions(DriverInitializer.Driver);
            Thread.Sleep(3000);
            _action.MoveToElement(FXTravelMigrant()).Build().Perform();
            Thread.Sleep(3000);
            _action.MoveToElement(Converter()).Click().Build().Perform();
            Thread.Sleep(30000);
        }
        
    }
}
