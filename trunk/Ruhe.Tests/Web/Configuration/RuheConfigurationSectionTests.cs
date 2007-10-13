using NUnit.Framework;
using Ruhe.Web.Configuration;

namespace Ruhe.Tests.Web.Configuration {
    [TestFixture]
    public class RuheConfigurationSectionTests {
        [Test]
        public void AlwaysHasValidatorConfiguratorElement() {
            Assert.IsNotNull(new RuheConfigurationSection().ValidatorConfiguratorElement);
        }
    }
}