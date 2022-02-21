using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
Console.WriteLine($"Key Vault Name: {keyVaultName}");

var kvUri = $"https://{keyVaultName}.vault.azure.net";
Console.WriteLine($"Key Vault URI: {kvUri}");

var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

Console.WriteLine("Secrets:");
foreach (var prop in client.GetPropertiesOfSecrets())
{
    var secret = client.GetSecret(prop.Name);
    Console.WriteLine($"\t{prop.Name}: {secret.Value.Id}");
}