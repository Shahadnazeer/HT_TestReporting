using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestContext = NUnit.Framework.TestContext;
using NUnit.Framework.Interfaces;

namespace HT_Design_Pattern
{
    public abstract class BaseTest
    {
        [TestCleanup]
        public void Cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Driver.captureSS();
            }
            Driver.Close();
        }
    }
}
