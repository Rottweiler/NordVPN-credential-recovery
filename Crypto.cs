using System.Security.Cryptography;
using System.Text;

namespace recv
{
    public static class Crypto
    {
        public static byte[] EncryptAES(string data, byte[] key)
        {
            return Crypto.EncryptAES(Encoding.UTF8.GetBytes(data), key);
        }

        // Token: 0x06000F76 RID: 3958 RVA: 0x0003A350 File Offset: 0x00038750
        public static byte[] EncryptAES(byte[] data, byte[] key)
        {
            byte[] result;
            using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider
            {
                Key = key.ToSha256(),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            })
            {
                result = aesCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
                aesCryptoServiceProvider.Clear();
            }
            return result;
        }

        // Token: 0x06000F77 RID: 3959 RVA: 0x0003A3B8 File Offset: 0x000387B8
        public static string DecryptAES(byte[] data, byte[] key)
        {
            AesCryptoServiceProvider expr_05 = new AesCryptoServiceProvider();
            expr_05.Key = key.ToSha256();
            expr_05.Mode = CipherMode.ECB;
            expr_05.Padding = PaddingMode.PKCS7;
            byte[] bytes = expr_05.CreateDecryptor().TransformFinalBlock(data, 0, data.Length);
            expr_05.Clear();
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
