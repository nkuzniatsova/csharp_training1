using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Edit group1");
            newData.Header = "Edit header1";
            newData.Footer = "Edit footer1";
            app.Groups.Modify(1, newData);
        }
    }
}
