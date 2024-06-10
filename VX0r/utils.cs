using System;
using System.Linq;
using System.Text;

namespace VX0r
{
    internal class utils
    {
        public utils() { }

        public string FromHex(string hex)
        {
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            byte[] anon = raw;
            string slin = Encoding.ASCII.GetString(anon, 0, anon.Length);

            return slin;
        }

        public string Enc(string plaintext, string pad)
        {
            char[] data = plaintext.ToCharArray();
            char[] key = pad.ToCharArray();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (char)(data[i] ^ key[i % key.Length]);
            }
            return bytes(new string(data));
        }

        public string Dec(string enctext, string pad)
        {
            var data = FromHex(enctext);
            char[] key = pad.ToCharArray();
            return Encoding.UTF8.GetString(data.Select((b, i) => (byte)(b ^ key[i % key.Length])).ToArray());
        }

        public string bytes(string inse)
        {
            string decString = inse;
            byte[] bytes = Encoding.Default.GetBytes(decString);
            string hexString = BitConverter.ToString(bytes);
            hexString = hexString.Replace("-", "");
            return hexString.ToLower();
        }
    }
}
