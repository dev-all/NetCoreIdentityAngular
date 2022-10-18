using System;
using System.Security.Cryptography;
using System.Text;

namespace allshop.api.Tools
{
    public class Encrypt
    {


        public static string ObtenerMD5(string Source)
        {
            byte[] Bytes;
            StringBuilder sb = new StringBuilder();

            // Check for empty string.
            if (string.IsNullOrEmpty(Source))
                throw new ArgumentNullException();

            // Get bytes from string.
            Bytes = Encoding.Default.GetBytes(Source);

            // Get md5 hash
            Bytes = System.Security.Cryptography.MD5.Create().ComputeHash(Bytes);

            // Loop though the byte array and convert each byte to hex.
            for (int x = 0; x <= Bytes.Length - 1; x++)
                sb.Append(Bytes[x].ToString("x2"));

            // Return md5 hash.
            return sb.ToString();
        }
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}
