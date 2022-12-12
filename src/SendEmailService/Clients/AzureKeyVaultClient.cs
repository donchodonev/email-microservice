using System;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Options;
using SendEmailService.Settings;

namespace SendEmailService.Clients
{
    public class AzureKeyVaultClient
    {
        private readonly SecretClient _secretClient;

        public AzureKeyVaultClient(IOptions<KeyVaultSettings> settings)
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                }
            };

            _secretClient = new SecretClient(new Uri("https://" + settings.Value.VaultName + ".vault.azure.net"), new DefaultAzureCredential(), options);
        }

        public Response<KeyVaultSecret> GetSecret(string secretName) => _secretClient.GetSecret(secretName);
    }
}
