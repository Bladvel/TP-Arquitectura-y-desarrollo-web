using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestHashSHA256
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string original = "admin";
            string hash = Hash256(original);

            Console.WriteLine(original);
            Console.WriteLine(hash);
            Console.ReadKey();


        }

        public static string Hash256(string input)
        {

            using (SHA256 hash = SHA256.Create())
            {
                var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }

        }

    }
}
