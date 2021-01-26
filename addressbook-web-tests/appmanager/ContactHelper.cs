using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
           public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);          
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);            
            Type(By.Name("byear"), contact.Byear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);            
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper Modify(int i, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            if (! IsAnyContactExist())
            {
                Create(CreateContactData());
            }            
            SelectContact(i);
            InitContactModification(i);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        private ContactData CreateContactData()
        {
            ContactData contact = new ContactData("FirstContact");
            contact.Middlename = "Middlename1";
            contact.Nickname = "Nickname1";
            contact.Lastname = "Lastname1";
            contact.Title = "Title1";
            contact.Company = "Company1";
            contact.Address = "Test street 100";
            contact.Home = "0111111111";
            contact.Mobile = "0222222222";
            contact.Work = "03333333333";
            contact.Fax = "04444444444";
            contact.Email = "Email1";
            contact.Email2 = "Email2";
            contact.Email3 = "Email3";
            contact.Homepage = "http://Homepage.nl";
            contact.Bday = "10";
            contact.Bmonth = "January";
            contact.Byear = "2001";
            contact.Aday = "20";
            contact.Amonth = "June";
            contact.Ayear = "2021";
            contact.Address2 = "Address2";
            contact.Phone2 = "0222222222";
            contact.Notes = "Notes create Contact1";
            return contact;
        }

        private bool IsAnyContactExist()
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'][1])"));
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
            return this;
        }

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        private ContactHelper InitContactModification(int index)
        {
            int contactId = Convert.ToInt32(driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).GetAttribute("id"));
            driver.FindElement(By.XPath("(//a[@href='edit.php?id=" + contactId + "'])")).Click();
            return this;
        }       

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper Remove(int i)
        {
            manager.Navigator.GoToHomePage();
            if (!IsAnyContactExist())
            {
                Create(CreateContactData());
            }
            SelectContact(i);
            RemoveContact();
            return this;
        }

        private ContactHelper RemoveContact()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

    }
}
