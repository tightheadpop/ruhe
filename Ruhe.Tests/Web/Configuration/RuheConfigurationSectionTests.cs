using System.Globalization;
using System.Threading;
using NUnit.Framework;
using Ruhe.Configuration;

namespace Ruhe.Tests.Web.Configuration {
    [TestFixture]
    public class RuheConfigurationSectionTests {
        [Test]
        public void AlwaysHasValidatorConfiguratorElement() {
            Assert.IsNotNull(RuheConfiguration.ValidatorConfigurator);
        }

        [Test]
        public void DateFormatDefaultsToCurrentUIThreadShortDate() {
            CultureInfo cultureInfo = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Assert.AreEqual(cultureInfo.DateTimeFormat.ShortDatePattern, RuheConfiguration.DateFormat);
        }
    }
}