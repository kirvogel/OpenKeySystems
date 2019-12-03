using System.Numerics;

namespace OpenKeySystems
{
    public class MulModClass
    {
        public static int MulMod(int num  ,int pow, int mod)
        {
            int res = 1;
            while(pow > 0)
            {
                if (pow % 2 == 1) res =(res * num) % mod;
                num = (num * num)%mod;
                pow >>= 1;
            }
 
            return res;
        }
    }
}