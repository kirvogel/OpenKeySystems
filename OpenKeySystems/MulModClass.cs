namespace OpenKeySystems
{
    public class MulMod
    {
        public int mulMod(int input, int based, int mod)
        {
            int[] x2 = new int[30];
            int i = 0;
            while(input >= 1) // перевода в двоичную систему исчисления
            {
                x2[i] = input % 2;
                input /= 2;
                ++i;
            }
            int n = i;
            int[] arr = new int[n];
            
            arr[0] = based;
            
            for(i = 1; i < n; ++i) {
                arr[i] = (arr[i-1] * arr[i-1]) % mod; 
            }
            
            int proizv = 1;
            for(int j = 0; j < n; ++j) {
                if (x2[j] > 0){
                    proizv*= x2[j] * arr[j];
                }
            }
            
            
            
            return 0;
        }
    }
}