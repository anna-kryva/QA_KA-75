using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTest
{
    [TestFixture]
    public class compairerTests
    {
        [Test]
        public void differentSizes()
        {
            var res = versionCompairer.compareVersion("1.1.1.1.1", "1.1");
            Assert.AreEqual(1, res);
            res = versionCompairer.compareVersion("1.1", "1.1.1.1.1");
            Assert.AreEqual(-1, res);
        }
        [Test]
        public void differentSizes2()
        {
            var res = versionCompairer.compareVersion("1.1.1.1.1", "1.2");
            Assert.AreEqual(-1, res);
            res = versionCompairer.compareVersion("1.2", "1.1.1.1.1");
            Assert.AreEqual(1, res);
        }
        [Test]
        public void equal()
        {
            var res = versionCompairer.compareVersion("1.1", "1.1");
            Assert.AreEqual(0, res);
            res = versionCompairer.compareVersion("1", "1.0");
            Assert.AreEqual(0, res);
        }
        [Test]
        public void compare()
        {
            var res = versionCompairer.compareVersion("1.1.2", "1.1.1");
            Assert.AreEqual(1, res);
            res = versionCompairer.compareVersion("1.1.1", "1.1.2");
            Assert.AreEqual(-1, res);
        }
    }
}
