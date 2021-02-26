﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.IsAnyGroupExist())
            {
                GroupData group = new GroupData("AddFirstGroup");
                group.Header = "FirstGroupHeader";
                group.Footer = "FirstGroupFooter";
                app.Groups.Create(group);
            }
            GroupData newData = new GroupData("Edit group1");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Modify(1, newData);
        }
    }
}
