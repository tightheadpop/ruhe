using System;
using Ruhe.Web.UI;

namespace Ruhe.Web.Configuration {
    public class ValidatorConfiguratorFactory {
        public static IValidatorConfigurator Create() {
            RuheConfigurationSection section = RuheConfigurationSection.GetCurrent();
            return (IValidatorConfigurator) Activator.CreateInstance(Type.GetType(section.ValidatorConfiguratorElement.Type));
        }
    }
}