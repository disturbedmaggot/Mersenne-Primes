using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Mersenne_Primes
{
    class Program
    {
        static void Main(string[] args)
        {

            int cycles = 0;
            
            bool validNumber = false;
            while (validNumber != true)
            {
                Console.Write("Number of cycles would you like to run: ");
                validNumber = int.TryParse(Console.ReadLine(), out cycles);
                Console.WriteLine();

                if (validNumber == false)
                {
                    Console.WriteLine("entry not valid\n");
                }
            }
            BigInteger prime = 1;
            BigInteger power = 2;


            for (int i = 0; i < cycles; i++)
            {
                prime = BigIntegerPow(2, power) - 1;
                power = prime;
            }
            Console.WriteLine(prime);
        }

        static BigInteger BigIntegerPow(BigInteger powBase, BigInteger powExponent)
        {
            BigInteger constantPowBase = powBase;
            for (BigInteger i = 1; i < powExponent; i++ )
            {
                powBase = powBase * constantPowBase;
            }

            return powBase;
        }
    }
}
