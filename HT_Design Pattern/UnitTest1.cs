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
            log.Debug("Trying to send a mail");
            try
            {
                var loginPage = new LoginPage();
                loginPage.Open();
                loginPage.Login("shahadnaz807@gmail.com", "Epaam12345");
                Assert.AreEqual(loginPage.UsernameField.GetAttribute("value"), "shahadnaz807@gmail.com");
                Assert.AreEqual(loginPage.PasswordField.GetAttribute("value"), "Epaam12345");
                Assert.True(loginPage.MainPage.Displayed, "The login is successful");   //Assert for login is successful
                var InboxPage = new InboxPage();
                InboxPage.Compose("shas8571@gmail.com", "Sample Subject", "Shahad Mail");
                var DraftPage = new DraftPage();
                DraftPage.DraftMails();
                //Assert.AreEqual(true, DraftPage.DraftMail.Displayed); // Verify, that the mail presents in ?Drafts? folder.
                // Verify the draft content(addressee, subject and body ? should be the same as in 3).
                //Assert.AreEqual(checkSenderMail.Text, "shas8571@gmail.com");
                //Assert.AreEqual(DraftPage.checkSubject.GetAttribute("value"), "Sample Subject");
                //Assert.AreEqual(DraftPage.checkTextbox.Text, "Shahad Mail");
                var SentPage = new SentPage();
                SentPage.SendMails("Updated");
                SentPage.DeleteMail();
                //SentPage.LogOut();
            }
            catch (Exception ex)
            {
                log.Error("Error occured", ex);
            }
            log.Debug("Mail sent");

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