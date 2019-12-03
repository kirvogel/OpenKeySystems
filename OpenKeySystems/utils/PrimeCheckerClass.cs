using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenKeySystems
{
    public class PrimeCheckerClass
    {
        public static bool isPrime(int number)
        {
            if (number <= 0) 
                return false;
            if (number == 1)
                return false;
            if (number == 2) 
                return true;

            var boundary = Convert.ToInt32(Math.Ceiling(Math.Sqrt(number)));
            var primesList = FillList(boundary);
            return !primesList.Any(i => number % i == 0);
        }
        
        private static ICollection<int> FillList(int boundary)
        {
            var list = new List<int> {2};
            switch (boundary)
            {
                case 2:
                    return list;
                case 3:
                    list.Add(3);
                    return list;
            }
            for (var i = 3; i < boundary; ++i)
            {
                addIfNotDivides(i, list);
            }

            return list;
        }

        private static void addIfNotDivides(int number, ICollection<int> primeslist)
        {
            if (primeslist.Any(i => number % i == 0))
            {
                return;
            }
            primeslist.Add(number);
        }

        public static bool isPrimitiveRoot(int g, int p)
        {
            var moduloP = FillList(p).Count;
            return MulModClass.MulMod(moduloP, g, p) == 1;
        }
    }
}