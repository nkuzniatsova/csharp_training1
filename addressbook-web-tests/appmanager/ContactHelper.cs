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
        private List<ContactData> contactCache = null;
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

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table/tbody/tr[@name='entry']"));
                //ICollection<IWebElement> elements = driver.FindElements(By.XPath("//input[@name='selected[]']"));             
                int i = 0;
                foreach (IWebElement element in elements)
                {
                    string firstName = driver.FindElements(By.XPath("//table/tbody/tr[@name='entry']/td[3]"))[i].Text;
                    string lastName = driver.FindElements(By.XPath("//table/tbody/tr[@name='entry']/td[2]"))[i].Text;
                    
                    ContactData contact = new ContactData(firstName, lastName)
                    {
                        Id = driver.FindElements(By.XPath("//table/tbody/tr[@name='entry']/td[1]/input"))[i].GetAttribute("value")

                    };
                    contactCache.Add(contact);
                    i++;
                }
            }
           
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//table/tbody/tr[@name='entry']")).Count;
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
            SelectContact(i);
            InitContactModification(i);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }        

        public bool IsAnyContactExist()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.XPath("(//input[@name='selected[]'][1])"));
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index) + "]")).Click();
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
            contactCache = null;
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
            SelectContact(i);
            RemoveContact();         
            return this;
        }

        private ContactHelper RemoveContact()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            contactCache = null;
            return this;
        }

    }
}
