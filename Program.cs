using System;

namespace recv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Decrypted username: " + NordVPN.recoverUsername());
            Console.WriteLine("Decrypted password: " + NordVPN.recoverPassword());
            Console.Read();
        }
    }
}
