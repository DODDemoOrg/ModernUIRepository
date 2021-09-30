using LaunchDarkly.Client;
using Microsoft.Extensions.Configuration;

namespace ModernUIApp.Services {
    public class FeatureFlagService : IFeatureFlagService {
        string _ldkey;
        LdClient _ldClient;
        User _ldUser;
       public FeatureFlagService(IConfiguration configuration)
       {
            _ldkey = configuration.GetValue<string> ("LaunchDarklyKey");
            _ldClient = new LdClient(_ldkey);
       }
        public bool ViewFeature (string Username) {
            _ldUser = new LaunchDarkly.Client.User(Username);
            var viewFeature = _ldClient.BoolVariation("ff-customer-management", _ldUser, false);
            return viewFeature;
        }
    }
}