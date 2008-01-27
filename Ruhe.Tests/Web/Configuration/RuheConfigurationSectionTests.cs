using System.Globalization;
using System.Threading;
using NUnit.Framework;
using Ruhe.Web.Configuration;

namespace Ruhe.Tests.Web.Configuration {
    [TestFixture]
    public class RuheConfigurationSectionTests {
        [Test]
        public void AlwaysHasValidatorConfiguratorElement() {
            Assert.IsNotNull(new RuheConfigurationSection().ValidatorConfiguratorElement);
        }

        [Test]
        public void DateFormatDefaultsToCurrentUIThreadShortDate() {
            CultureInfo cultureInfo = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Assert.AreEqual(cultureInfo.DateTimeFormat.ShortDatePattern, new RuheConfigurationSection().DateFormat.Value);
        }
    }
}