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
    public class DraftPage : BasePage
    {
        public DraftPage() : base("")
        {
        }

        public IWebElement DraftField => Driver.GetInstance().FindElement(By.XPath("//a[contains(text(),'Drafts')]"));

        public IWebElement DraftMail => Driver.GetInstance().FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public WebDriverWait wait = new WebDriverWait(Driver.GetInstance(), TimeSpan.FromSeconds(50));

        public IWebElement SendMail => Driver.GetInstance().FindElement(By.XPath("//div[text()='Send']"));

        public void DraftMails()
        {
            //DraftField.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DraftField));
            var Draftbutton = new Button(DraftField);
            Draftbutton.Click();
            //DraftMail.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DraftMail));
            var DraftMailbutton = new Button(DraftMail);
            DraftMailbutton.Click();
            Assert.AreEqual(true, DraftMail.Displayed); // Verify, that the mail presents in ‘Drafts’ folder.

            //WebElement checkSenderMail = (WebElement)Driver.GetInstance().FindElement(By.XPath("//div[@class='aoD hl']"));
            WebElement checkSubject = (WebElement)Driver.GetInstance().FindElement(By.CssSelector("input[name=subjectbox]"));
            WebElement checkTextbox = (WebElement)Driver.GetInstance().FindElement(By.XPath("//div[@role='textbox']"));

            // Verify the draft content(addressee, subject and body – should be the same as in 3).
            //Assert.AreEqual(checkSenderMail.Text, "shas8571@gmail.com");
            Assert.AreEqual(checkSubject.GetAttribute("value"), "Sample Subject");
            Assert.AreEqual(checkTextbox.Text, "Shahad Mail");

            //SendMail.Click();
            var SendMailbutton = new Button(SendMail);
            SendMailbutton.Click();
        }

        

    }

}
