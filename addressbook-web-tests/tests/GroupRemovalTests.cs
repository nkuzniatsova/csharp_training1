using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsAnyGroupExist())
            {
                GroupData group = new GroupData("AddFirstGroup");
                group.Header = "FirstGroupHeader";
                group.Footer = "FirstGroupFooter";
                app.Groups.Create(group);
            }
            app.Groups.Remove(1);            
        }
    }
}
