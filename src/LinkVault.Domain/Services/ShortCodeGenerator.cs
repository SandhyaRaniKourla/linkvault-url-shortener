using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LinkVault.Domain.Services
{
    public static class ShortCodeGenerator
    {
        private const string Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private const int codeLength = 7;

        public static string Generate()
        {
            Span<char> shortCode = stackalloc char[codeLength];
           
            for(int i = 0; i < codeLength; i++)
            {
                int index = RandomNumberGenerator.GetInt32(Characters.Length);
                shortCode[i] = Characters[index];
            }
            return new string(shortCode);
        }
        //public static string GenerateShortCode(int length = 8)
        //{
        //    var random = new Random();
        //    var shortCode = new StringBuilder();

        //    for (int i = 0; i < length; i++)
        //    {
        //        shortCode.Append(Characters[random.Next(Characters.Length)]);
        //    }

        //    return shortCode.ToString();
        //}
    }
}
