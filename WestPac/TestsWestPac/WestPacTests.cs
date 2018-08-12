using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace TestsWestPac
{
    [TestClass]
    public class WestPacTests
    {
        FXTravelAndMigrantsPage fxtravel = new FXTravelAndMigrantsPage();
        HomePage home = new HomePage();
        
        [TestInitialize]
        public void InitializeTest()
        {
            DriverInitializer.Initialize("chrome");
            DriverInitializer.Driver.Navigate().GoToUrl("http://www.westpac.co.nz/");
        }
        [TestMethod]
        public void Test_VerifyIfTheAmountIsNullTheErrorMessageShouldDisplayOnceYouclickOnCovert()
        {
            home.NavigateToConvertCurrencyPage();
            fxtravel.ClickOnConvertButton();
            Console.WriteLine("Convert Clicked");
            fxtravel.VerifyTheErrorMessageIsDisplayed();
            fxtravel.VerifyTheErrorText();
        }
        [TestMethod]
        public void Test_VerifyTheUserCanConvertTheCurrencyfromAnyCurrencyAnyOtherCurrencyInGivenList()
        {
            home.NavigateToConvertCurrencyPage();
            List<string> fromCurrency = new List<string>(new string[] { "New Zealand Dollar", "United States Dollar", "Pound Sterling", "Swiss Franc" });
            List<string> toCurrency = new List<string>(new string[] { "United States Dollar", "New Zealand Dollar", "New Zealand Dollar", "Euro" });
            List<string> amount = new List<string>(new string[] { "10", "15", "20", "30" });
            for(int i=0;i<=fromCurrency.Count-1;i++)
            {
                if(i==0)
                {
                    fxtravel.EnterAmount().Clear();
                    fxtravel.EnterAmountValue().SendKeys(amount[i]);
                }
                if(i>0)
                {
                    fxtravel.EnterAmountValue().Clear();
                    fxtravel.EnterAmountValue().SendKeys(amount[i]);
                }
                fxtravel.SelectTheCurreny(fxtravel.ConvertFrom(), fromCurrency[i]);
                fxtravel.SelectTheCurreny(fxtravel.ConvertTo(), toCurrency[i]);
                fxtravel.ClickOnCovert();
                Console.WriteLine(amount[i] + " " + fromCurrency[i] + " " + "is equal to "+fxtravel.GetCovertedAmount() + toCurrency[i]);
            }
            
        }
        [TestCleanup]
        public void CleanTest()
        {
            DriverInitializer.Driver.Quit();
        }
    }
}
