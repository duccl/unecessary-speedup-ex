using System;

namespace primes
{
    
    class Program
    {
        static int TestaPrimo(int n)
        {
            int EhPrimo = 1;
            int d = 2;
            if(n<=1) EhPrimo = 0;
            
            while(EhPrimo ==1 && d <= n/2){
                if (n % d  == 0){
                    EhPrimo = 0;
                }
                d = d + 1;
            }
            return EhPrimo;
        }
        
        static bool IsPrime(int n){
            for(int i = 2; i<n;i++) if(n % i == 0) return false;
            return true;
        }

        static bool IsPrimeSquareRoot(int n){
            for(int i = 1; i<-Math.Sqrt(n);i++) if(n % i == 0) return false;
            return true;
        }

        static void Main(string[] args)
        {
            int[] values = {7,37,8431,13033,524287,664283,3531271,2147483647};
            double media = 0;
            foreach(var _value in values){
                double[] timeDeltaOfEachExecution = new double[30];
                for (int i = 0; i < 30; i++)
                {
                    var startTime = DateTime.Now;
                    TestaPrimo(_value);
                    //IsPrimeSquareRoot(_value);
                    //IsPrime(_value);
                    double dif = (DateTime.Now - startTime).TotalMilliseconds;
                    timeDeltaOfEachExecution.SetValue(dif,i);
                    media += dif;    
                }
                double dp = 0.0;
                for (int j = 0; j < timeDeltaOfEachExecution.Length; j++)
                {
                    dp += Math.Pow((timeDeltaOfEachExecution[j] - media/30.0),2)/30.0;
                } 
                Console.WriteLine("value " + _value + " levou " + string.Format("{0:0.000000}", media/30.0) + " com Desvio Padrao de " + string.Format("{0:0.000000}", Math.Sqrt(dp)));
            }
        }
    }
}
