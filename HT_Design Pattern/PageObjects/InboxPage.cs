﻿using Nest;
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
    public class InboxPage : BasePage
    {
        public InboxPage() : base("")
        {
        }

        //TODO long and autogenerated xpath
        public IWebElement CommposeBoxField => Driver.GetInstance().FindElement(By.XPath("//div[@jscontroller='eIu7Db']"));
        
        public WebDriverWait wait = new WebDriverWait(Driver.GetInstance(), TimeSpan.FromSeconds(50));
        public IWebElement SenderMailField => Driver.GetInstance().FindElement(By.CssSelector("input[role=combobox]"));
        public IWebElement SubjectField => Driver.GetInstance().FindElement(By.Name("subjectbox"));
        public IWebElement TextBoxField => Driver.GetInstance().FindElement(By.XPath("//div[@aria-label='Message Body']"));
        public IWebElement SaveCloseField => Driver.GetInstance().FindElement(By.XPath("//img[@alt='Close']"));


        public void Compose(string senderMail, string subject, string textbox)
        {
            senderMail = "shahadnaz807@gmail.com";
            subject = "Sample Subject";
            textbox = "Shahad Mail";

            //CommposeBoxField.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(CommposeBoxField));
            var CommposeBox = new Button(CommposeBoxField);
            CommposeBox.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SenderMailField));
            SenderMailField.SendKeys(senderMail); 
            SubjectField.SendKeys(subject); 
            TextBoxField.SendKeys(textbox); 
            //SaveCloseField.Click();
            var SaveCloseButton = new Button(SaveCloseField);
            SaveCloseButton.Click();
        }



    }
}
