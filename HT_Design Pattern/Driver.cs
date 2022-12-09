using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using log4net.Appender;
using log4net;

namespace HT_Design_Pattern
{
    public class Driver
    {
        private static IWebDriver? _driver;

        public static IWebDriver GetInstance()
        {
            if (_driver == null)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                _driver = new ChromeDriver(chromeOptions);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return _driver;
        }

        public static void captureSS()
        {
            Screenshot ss = ((ITakesScreenshot)GetInstance()).GetScreenshot();
            ss.SaveAsFile(Path.Combine(Environment.CurrentDirectory,"scr" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".png"));
        }

        public static void Close()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
