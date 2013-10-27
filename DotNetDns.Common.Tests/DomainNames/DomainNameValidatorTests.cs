using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetDns.Common.DomainNames;
using DotNetDns.TestHelpers;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.DomainNames
{
    [TestFixture]
    public class DomainNameValidatorTests
    {
        private Mocker<ITopLevelDomains> _topLevelDomainsMock;
        private DomainNameValidator _validator;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            SetupValidator(
                SetupTopLevelDomainsMock());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [ExpectedException(typeof(Exception), ExpectedMessage = "A domain name cannot be null or empty.")]
        public void Null_Or_Empty_Domain_Names_Throw(string domainName)
        {
            _validator.ValidateDomainName(domainName);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "The label 'Thisisareallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallylonglabel' is too long. Labels may only be upto 63 characters in length.")]
        public void Labels_Exceeding_63_Characters_Throw()
        {
            _validator.ValidateDomainName("Thisisareallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallyeallyreallyreallylonglabel.com");
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "The domain name 'Thisisareallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.longdomainname.com' is too long. Domain names may only be upto 253 characters in length.")]
        public void Domain_Names_Exceeding_253_Characters_Throw()
        {
            _validator.ValidateDomainName("Thisisareallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.reallyreallyreallyeallyreallyreally.longdomainname.com");
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "The top level domain 'xyz' is invalid.")]
        public void Domain_Names_With_Invalid_Top_Level_Domains_Throw()
        {
            _topLevelDomainsMock.With(mock => mock.IsNotKnown("xyz"), true);
            _validator.ValidateDomainName("domainname.xyz");
        }

        [Test]
        [TestCase("domainname.com")]
        [TestCase("subdomain.domainname.com")]
        public void Valid_Domain_Names_Do_Not_Throw(string domainName)
        {
            _validator.ValidateDomainName(domainName);
        }

        private Mocker<ITopLevelDomains> SetupTopLevelDomainsMock()
        {
            _topLevelDomainsMock = new Mocker<ITopLevelDomains>();
            return _topLevelDomainsMock;
        }

        private void SetupValidator(Mocker<ITopLevelDomains> mocker)
        {
            _validator = new DomainNameValidator(mocker.ToEntity());
        }
    }
}