using System;
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
            ContactData newData = new ContactData("Firstname modified");
            newData.Middlename = "Middlename modified";
            newData.Nickname = "Nickname modified";
            newData.Lastname = "Lastname modified";
            newData.Title = "Title modified";
            newData.Company = "Company modified";
            newData.Address = "Test street 200";
            newData.Home = "0111111112";
            newData.Mobile = "0222222223";
            newData.Work = "03333333334";
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
            app.Contacts.Modify(1, newData);
        }
    }
}
