﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
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
            ContactData newData = new ContactData("Firstname modified", "Lastname modified");
            newData.Middlename = "Middlename modified";
            newData.Nickname = "Nickname modified";
            newData.Lastname = "Lastname modified";
            newData.Title = "Title modified";
            newData.Company = "Company modified";
            newData.Address = "Test street 200";
            newData.HomePhone = "0111111112";
            newData.MobilePhone = "0222222223";
            newData.WorkPhone = "03333333334";
            newData.Fax = "04444444445";
            newData.Email = "Email11";
            newData.Email2 = "Email21";
            newData.Email3 = "Email31";
            newData.Homepage = "Homepage Edited";
            newData.Bday = "11";
            newData.Bmonth = "February";
            newData.Byear = "2002";
            newData.Aday = "21";
            newData.Amonth = "July";
            newData.Ayear = "2022";
            newData.Address2 = "Address21";
            newData.Phone2 = "0222222221";
            newData.Notes = "Notes create Contact2";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }
    }
}
