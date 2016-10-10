using System;
using System.IO;
using System.Security.Cryptography;

namespace recv
{
    public static class Extensions
    {
        /// <summary>
        /// Compute the SHA256 hash of a byte array
        /// </summary>
        /// <param name="bytes">The byte array to be computed</param>
        /// <returns>string (SHA256 hash)</returns>
        public static byte[] ToSha256(this byte[] bytes)
        {
            return SHA256.Create().ComputeHash(bytes);
        }

        /// <summary>
        /// Convert a hex value to the corresponding byte array
        /// </summary>
        /// <param name="value">The hex value to be converted</param>
        /// <returns>The byte array</returns>
        public static byte[] ToBytes(this string value)
        {
            int num = value.Length / 2;
            byte[] array = new byte[num];
            using (StringReader stringReader = new StringReader(value))
            {
                for (int i = 0; i < num; i++)
                {
                    array[i] = Convert.ToByte(new string(new char[]
                    {
                        (char)stringReader.Read(),
                        (char)stringReader.Read()
                    }), 16);
                }
            }
            return array;
        }
    }
}
