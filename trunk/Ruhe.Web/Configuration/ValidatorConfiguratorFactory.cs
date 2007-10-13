using System;
using System.Configuration;
using Ruhe.Web.Configuration;
using Ruhe.Web.UI;

namespace Ruhe.Web.Configuration {
    public class ValidatorConfiguratorFactory {
        public static IValidatorConfigurator Create() {
            RuheConfigurationSection section = (RuheConfigurationSection) (ConfigurationManager.GetSection("ruhe") ?? new RuheConfigurationSection());
            return (IValidatorConfigurator) Activator.CreateInstance(Type.GetType(section.ValidatorConfiguratorElement.Type));
        }
    }
}