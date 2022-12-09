using HT_Design_Pattern.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HT_Design_Pattern.PageObjects;
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
using Assert = NUnit.Framework.Assert;
using log4net.Config;
using log4net.Appender;
using log4net;
using NUnit.Framework.Interfaces;
using TestContext = NUnit.Framework.TestContext;


namespace HT_Design_Pattern
{
    [TestClass]
    public class UnitTest1 
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [TestMethod]
        public void TestMethod1()
        {
            log.Info("sample");
            var loginPage = new LoginPage();
            loginPage.Open();
            loginPage.Login("username", "password");
            var InboxPage = new InboxPage();
            InboxPage.Compose("sender_mail", "subject", "main objective");
            var DraftPage = new DraftPage();
            DraftPage.DraftMails();
            var SentPage = new SentPage();
            SentPage.SendMails();
            SentPage.LogOut();

        }

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