using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace TestsWestPac
{
    class FXTravelAndMigrantsPage
    {
        public IWebElement ConvertFrom()
        {
            IWebElement rootElement = DriverInitializer.Driver.FindElement(By.XPath("//*[@id='container']/table[1]/tbody/tr/td/form"));
            IWebElement from = rootElement.FindElement(By.Name("ConvertFrom"));
            return from;
        }
        public IWebElement ConvertTo()
        {
            IWebElement rootElement = DriverInitializer.Driver.FindElement(By.XPath("//*[@id='container']/table[1]/tbody/tr/td/form"));
            IWebElement to = rootElement.FindElement(By.Name("ConvertTo"));
            return to;
        }
        public IWebElement Convert()
        {
            DriverInitializer.Driver.SwitchTo().Frame("westpac-iframe");
            IWebElement rootElement = DriverInitializer.Driver.FindElement(By.XPath("//*[@id='container']/table[1]/tbody/tr/td/form"));
            IWebElement convert = rootElement.FindElement(By.Name("submit"));
            return convert;
        }
        public void ClickOnCovert()
        {
            IWebElement rootElement = DriverInitializer.Driver.FindElement(By.XPath("//*[@id='container']/table[1]/tbody/tr/td/form"));
            rootElement.FindElement(By.Name("submit")).Click();
        }
        public IWebElement EnterAmount()
        {
            Thread.Sleep(5000);
            DriverInitializer.Driver.SwitchTo().Frame("westpac-iframe");
            IWebElement rootElement = DriverInitializer.Driver.FindElement(By.XPath("//*[@id='container']/table[1]/tbody/tr/td/form"));
            IWebElement amount = rootElement.FindElement(By.Name("Amount"));
            return amount;
        }
        public IWebElement EnterAmountValue()
        {
            Thread.Sleep(5000);
            IWebElement rootElement = DriverInitializer.Driver.FindElement(By.XPath("//*[@id='container']/table[1]/tbody/tr/td/form"));
            IWebElement amount = rootElement.FindElement(By.Name("Amount"));
            return amount;
        }
        public string GetCovertedAmount()
        {
            IWebElement rootElement = DriverInitializer.Driver.FindElement(By.XPath("//*[@id='container']/table[1]/tbody/tr/td/form"));
            IWebElement convert = rootElement.FindElement(By.XPath("//em/strong[2]"));
            string[] amount = convert.Text.Split('=');
            return amount[0];
        }
        public IWebElement ErrorMessage()
        {
            IWebElement erro = DriverInitializer.Driver.FindElement(By.XPath("//div[contains(@id,'errordiv')]//li"));
            return erro;
        }
        public void VerifyTheErrorMessageIsDisplayed()
        {
            Assert.IsTrue(ErrorMessage().Displayed, "Error Message Is not displayed");
        }
        public void VerifyTheErrorText()
        {
            Console.WriteLine("The Error message is: " + ErrorMessage().Text);
            Assert.IsTrue(ErrorMessage().Text.Equals("Please enter the amount you want to convert."), "The expected error message is not displayed");
        }
        public void ClickOnConvertButton()
        {
            Convert().Click();
            Thread.Sleep(3000);
        }
        public void SelectTheCurreny(IWebElement element,string currency)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByText(currency);
        }
    }
}
