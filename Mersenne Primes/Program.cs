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
        static bool validPrime = true;
        static void Main(string[] args)
        {

            int cycles = 0;

            bool validNumber = false;
            while (validNumber != true)
            {
                Console.Write("Number of cycles would you like to run: ");

                validNumber = int.TryParse(Console.ReadLine(), out cycles);
                if (cycles < 1)
                    validNumber = false;

                Console.WriteLine();

                if (validNumber == false)
                {
                    Console.WriteLine("entry not valid\n");
                }
            }

            BigInteger prime = new BigInteger(1);
            BigInteger power = new BigInteger(2);


            for (int i = 0; i < cycles; i++)
            {
                prime = BigIntegerPow(2, power) - 1;
                power = prime;
            }
            Console.WriteLine(prime);

            Parallel.ForEach(BigIntegerPrimeValidator(prime), (i) => { });

            if (validPrime == true)
            {
                Console.WriteLine("{0} has been validated as a prime number", prime);
            }
            else
                Console.WriteLine("{0} is not a valid prime number", prime);
        }

        static IEnumerable<BigInteger> BigIntegerPrimeValidator(BigInteger number)
        {
            BigInteger max = (BigInteger)Math.Ceiling(Math.Sqrt((double)number));
            validPrime = true;
            BigInteger i = 2;

            if (BigInteger.Remainder(number, 2) == 0)
            {
                validPrime = false;
            }
            else i++;

            while (i < max && validPrime == true)
            {
                if ((BigInteger.Remainder(number, i) == 0))
                {
                    validPrime = false;
                }
                yield return i;
                i += 2;
            }
        }
        static BigInteger BigIntegerPow(BigInteger powBase, BigInteger powExponent)
        {
            BigInteger constantPowBase = powBase;
            for (BigInteger i = 1; i < powExponent; i++)
            {
                powBase = powBase * constantPowBase;
            }

            return powBase;
        }


    }
}
