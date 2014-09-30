using System;
using System.IO;

namespace primes
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n_primes = 1000;
            int running_total = 5;


            int prime = 3;    
                
            for (int ii = 3; ii <= n_primes; ii++)
            {
                prime = next_prime(prime);
                running_total = running_total + prime;
                //Console.WriteLine(prime);
            }
            
            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            Console.WriteLine(running_total);
        }

        public static int next_prime(int p)
        {
            // p should always be odd when it gets here so we can advance in twos
            p = p + 2;
            while (true) // There are infinite primes, so we should always be able to find the next one and get out of this loop.
            {
                if (is_prime(p))
                {
                    return p;
                }
                p = p + 2;
            }
        }

        public static bool is_prime(int p)
        {
            int last_point = (int)Math.Sqrt(p); // Cast the final number we need to check as an int and calculate it up front 

            for (int i = 3; i <= last_point; i = i + 2) // We only get odd numbers input, so step in twos
            {
                if (p % i == 0) // This property of int division (it rounds down) allows us to avoid casting anything as a floating point number. We will only round down to the same number if they both fit in the gap between successive multiples of i, which is only possible if p is an integer multiple of i. 
                {
                    return false;
                }
            }
            return true;
        }
    }
}

