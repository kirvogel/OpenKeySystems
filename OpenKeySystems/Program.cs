using System;
using System.Net.Security;

namespace OpenKeySystems
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = 42089;
            int g = 3;
            Console.WriteLine("P: " + p);
            Console.WriteLine("G: " + g);
            DiffieHellmanProtocol protoA = new DiffieHellmanProtocol(p, g, 979727);
            DiffieHellmanProtocol protoB = new DiffieHellmanProtocol(p, g, 458346);
            protoA.CountSharedSecret(protoB.OpenKey);
            protoB.CountSharedSecret(protoA.OpenKey);
            Console.WriteLine("Side A parameters: private " + protoA.PrivateKey + ", public " + protoA.OpenKey + ", shared " + protoA.SharedPrivateKey);
            Console.WriteLine("Side B parameters: private " + protoB.PrivateKey + ", public " + protoB.OpenKey + ", shared " + protoB.SharedPrivateKey);
        }
    }
}