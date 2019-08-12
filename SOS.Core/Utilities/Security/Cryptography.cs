using SOS.Core.Utilities.ConverterExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Core.Utilities.Security
{
    public class Cryptography
    {
        public static string GenerateHash(string value)
        {
            byte[] hashBytes = ComputeHash(value);
            byte[] saltBytes = GetRandomSalt();

            byte[] hashWithSaltBytes = GenerateHashWithSalt(hashBytes, saltBytes);
            string hash = ConverterUtilities.ByteArrayToString(hashWithSaltBytes);
            string salt = ConverterUtilities.ByteArrayToString(saltBytes);
            return hash + "æ" + salt;
        }

        private static byte[] GenerateHashWithSalt(byte[] hashBytes, byte[] saltBytes)
        {
            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            return hashWithSaltBytes;
        }

        //validate
        public static bool ValidateHash(string hash, string salt, string value)
        {
            byte[] s1 = GenerateHashWithSalt(ComputeHash(value), ConverterUtilities.StringToByteArray(salt));
            byte[] s2 = ConverterUtilities.StringToByteArray(hash);
            return ConverterUtilities.ByteArrayToString(s1) == ConverterUtilities.ByteArrayToString(s2);
        }

        // hashing
        private static byte[] ComputeHash(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            HashAlgorithm hash = new SHA256Managed();
            return hash.ComputeHash(plainTextBytes);
        }

        //random salt generation
        private static byte[] GetRandomSalt()
        {
            int minSaltSize = 16;
            int maxSaltSize = 32;

            Random random = new Random();
            int saltSize = random.Next(minSaltSize, maxSaltSize);
            byte[] saltBytes = new byte[saltSize];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltBytes);
            return saltBytes;
        }

    }
}
