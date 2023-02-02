using System.Security.Cryptography;

namespace JMTopUpBackend.Application.Services
{
    public interface ICryptographyService
    {
        Task<string> DecryptAsync(string encryptedText, CancellationToken cancellationToken);
        Task<string> EncryptAsync(string plainText);
    }
    public class CryptographyService : ICryptographyService
    {
        public readonly byte[] _Key;
        public readonly byte[] _IV;
        public CryptographyService(IConfiguration configuration)
        {
            _Key = Convert.FromBase64String(configuration.GetValue<string>("Keys:KEY")!);
            _IV = Convert.FromBase64String(configuration.GetValue<string>("Keys:IV")!);
        }
        public async Task<string> DecryptAsync(string encryptedText, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(encryptedText))
                throw new ArgumentNullException(nameof(encryptedText));
            string plaintext = string.Empty;
            using (Aes aes = Aes.Create())
            {
                aes.Key = _Key;
                aes.IV = _IV;
                using (ICryptoTransform cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(encryptedText)))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader(cryptoStream))
                            {
                                plaintext = await streamReader.ReadToEndAsync(cancellationToken);
                            }
                        }
                    }
                }
            }
            return plaintext;
        }
        public async Task<string> EncryptAsync(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                throw new ArgumentNullException(nameof(plainText));
            byte[] encryptedBytes;
            using (Aes aes = Aes.Create())
            {
                aes.Key = _Key;
                aes.IV = _IV;
                using (ICryptoTransform cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                            {
                                await streamWriter.WriteAsync(plainText);
                            }
                            encryptedBytes = memoryStream.ToArray();
                        }
                    }
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }
    }
}