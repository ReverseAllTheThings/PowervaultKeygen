using System;
using System.Linq;

namespace DellPowerVaultFeatureKeygen
{
    public static class Utility
    {
        public static byte[] ReverseEndian(int value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }

        public static byte[] ReverseEndian(short value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            int length = hex.Length / 2;
            byte[] data = new byte[length];

            for (int i = 0; i < length; i++)
            {
                data[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return data;
        }
    }
}
