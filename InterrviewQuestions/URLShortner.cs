using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace InterviewQuestions
{
    public class URLShortner
    {
        private static URLShortnerService shortnerService = new URLShortnerService();

        public static void Driver()
        {
            AskUserOptioins();
            var keyEntered = Console.ReadLine();
            while (keyEntered.ToLower() != "q")
            {
                if (keyEntered == "1")
                {
                    GenerateShortURL();
                }
                else if (keyEntered == "2")
                {
                    GetLongURL();
                }
                AskUserOptioins();
                keyEntered = Console.ReadLine();
            }
        }

        private static void AskUserOptioins()
        {
            Console.WriteLine($"Press 1 for Generating new Short URL");
            Console.WriteLine($"Press 2 for Retrieving Long URL");
            Console.WriteLine($"Press Q to exit");
        }

        private static void GetLongURL()
        {
            Console.WriteLine($"\nPlease enter the shortened URL you want to get the long URL of");
            var shortURL = Console.ReadLine();
            var longURL = shortnerService.GetLongURL(shortURL);
            Console.WriteLine($"Original long URL is : \n{longURL} ");
            Console.WriteLine();
        }

        private static void GenerateShortURL()
        {
            Console.WriteLine($"Please enter the URL you want to Shorten");
            var urlEntered = Console.ReadLine();
            var shortURL = shortnerService.GetShortURL(urlEntered);
            Console.WriteLine($"Shortned URL is : \n{shortURL} ");
            Console.WriteLine();
        }
    }

    public interface IURLShortner
    {
        string GetShortURL(string longURL);
        string GetLongURL(string shortURL);
    }

    public class URLShortnerService : IURLShortner
    {
        private const string Prefix = "https://shr.tn/";
        private const int ShortnerLength = 7;

        public string GetLongURL(string shortURL)
        {
            var code = shortURL.Remove(0, Prefix.Length);
            if (!URLDataBase.URLs.ContainsValue(code))
                return null;
            return URLDataBase.URLs.FirstOrDefault(x => x.Value == code).Key;
        }

        public string GetShortURL(string longURL)
        {
            if (URLDataBase.URLs.ContainsKey(longURL))
                return string.Concat(Prefix, URLDataBase.URLs[longURL]);
            return string.Concat(Prefix, GenerateShortURL(longURL));
        }

        private string GenerateShortURL(string longURL)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var hash = MD5HashAlgo.GetMd5Hash(md5Hash, longURL);
                var encodedString = Base64Encoding(hash.Substring(0, ShortnerLength)).Replace('\\', '_').Replace('+', '-');
                URLDataBase.URLs.Add(longURL, encodedString);
                return encodedString;
            }
        }

        private string Base64Encoding(string md5Hash)
        {
            var plainBytes = Encoding.UTF8.GetBytes(md5Hash);
            return Convert.ToBase64String(plainBytes).TrimEnd('=');
        }
    }

    public class URLDataBase
    {
        /// <summary>
        /// URL Data base consisting of Long and Short URL's
        /// </summary>
        /// <typeparam name="Long URL"></typeparam>
        /// <typeparam name="Short URL"></typeparam>
        public static Dictionary<string, string> URLs = new Dictionary<string, string>();
    }

    public class MD5HashAlgo
    {
        public static void Driver(string[] args)
        {
            string source = "Hello World!";
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);

                Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");

                Console.WriteLine("Verifying the hash...");

                if (VerifyMd5Hash(md5Hash, source, hash))
                {
                    Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    Console.WriteLine("The hashes are not same.");
                }
            }



        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
