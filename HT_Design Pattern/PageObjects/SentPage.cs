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


namespace HT_Design_Pattern.PageObjects
{

    public class SentPage : BasePage
    {
        public SentPage() : base("")
        {
        }

        public IWebElement SentField => Driver.GetInstance().FindElement(By.XPath("//a[contains(text(),'Sent')]"));

        public IWebElement SentMail => Driver.GetInstance().FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public WebDriverWait wait = new WebDriverWait(Driver.GetInstance(), TimeSpan.FromSeconds(50));


        public IWebElement AccountField => Driver.GetInstance().FindElement(By.CssSelector("img.gb_Ca.gbii"));

        public IWebElement SignOut => Driver.GetInstance().FindElement(By.XPath("//div[text()='Sign out']"));


        public void SendMails()
        {
            //SentField.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentField));
            var SentButton = new Button(SentField);
            SentButton.Click();
            //SentMail.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentMail));
            var SentMailButton = new Button(SentMail);
            SentMailButton.Click();
        }


        public void LogOut()
        {
            //AccountField.Click();
            var AccountButton = new Button(AccountField);
            AccountButton.Click();
            Driver.GetInstance().SwitchTo().Frame("account");
            //SignOut.Click();
            var SignOutButton = new Button(SignOut);
            SignOutButton.Click();
            Driver.GetInstance().SwitchTo().ParentFrame();
        }


    }

}
