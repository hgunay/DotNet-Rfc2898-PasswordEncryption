namespace DotNet_Rfc2898_PasswordEncryption
{
    using System;

    /// <summary>The program.</summary>
    public static class Program
    {
        /// <summary>The main.</summary>
        public static void Main()
        {
            Console.WriteLine("RFC2898 Password Encryption");
            Console.WriteLine("---------------------------");

            Console.Write("Input your password : ");
            var password = Console.ReadLine();

            var saltPassword    = PasswordHelper.CreateSaltPassword();
            var encodedPassword = PasswordHelper.EncodePassword(password, saltPassword);

            Console.WriteLine();
            Console.WriteLine($"Your password    : {password}");
            Console.WriteLine($"Salt password    : {saltPassword}");
            Console.WriteLine($"Encoded password : {encodedPassword}");
        }
    }
}