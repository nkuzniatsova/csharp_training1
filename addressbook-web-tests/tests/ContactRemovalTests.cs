﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsAnyContactExist())
            {
                ContactData contact = new ContactData("FirstContact", "Lastname1");
                contact.Middlename = "Middlename1";
                contact.Nickname = "Nickname1";
                contact.Lastname = "Lastname1";
                contact.Title = "Title1";
                contact.Company = "Company1";
                contact.Address = "Test street 100";
                contact.HomePhone = "0111111111";
                contact.MobilePhone = "0222222222";
                contact.WorkPhone = "03333333333";
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
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(1);
            //Thread.Sleep(500);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
