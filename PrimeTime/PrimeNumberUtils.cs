using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeTime
{
	public class PrimeNumberUtils
	{
		private List<int> primeHolder, compositeHolder;

		public string message;

		public PrimeNumberUtils()
		{
			this.primeHolder = new List<int>();
			this.compositeHolder = new List<int>();

			this.message = "";
		}

		public bool testPrimality(double dbInput)
		{
			/*
			 *	Using the square root property of Prime numbers
					A prime number is a integer (whole number) greater than 1 divisble only by 1 and itself.
					If any whole number lteq to sqrt(n) evenly divides n, then n cannot be a prime number.

					Assumption: Every composite (non prime) number has a proper factor less than or equal to its square root.

					Proof: We reason with proof by contradiction. Assume there exsists a composite number where 
					a proper factor is not lteq its sqrt, call it n. If n can be written as a pair of factors, say (a, b) where
					a, b are between 1 and n, then n = a*b. If both a > sqrt(n) and b > sqrt(n), then a*n > n. =><= contradiction. 
					Our assumption was ab = n and if not then at least one of a, b is lteq sqrt(n) and if n is composite, then
					n has a prime factor p <= sqrt(n).

					E.g. 6 is a not prime number. Suppose it is. Factors of 6 are: 1, 2, 3, 6. We only have 2, 3 to work with given 
					our criterion and both 2, 3 are between 1, 6 = n. If 2 > 2.45 and 3 > 2.45 then 6 >= 6. But 2 is not > 2.45 so 
					we find p = 2 <= 2.45 and 6 is non prime. 



					Anyway.. we start with 2 since we need an integer > 1.


			 */

			// int arrayIndex = 0;
			int currentInt = 2;
			// The numbers should be whole numbers so explicit cast should go from a .0..0 decimal to whole no issues
			int number = (int)dbInput;
			// We only need to check up until the floor'd integer of the square root
			int flsqrt = (int)Math.Floor(Math.Sqrt(dbInput));

			bool stillPrime = true;

			do
			{	// If the number tested is divisible by our current integer, its composite
			 	// If the number is the current integer then its going to divide evenly and ofc thats a factor

				if (number % currentInt == 0 && number != currentInt)
				{
					stillPrime = false;
				}

			} while (currentInt++ <= flsqrt && stillPrime);


			return stillPrime;
		}

		public void primeFactorization(int composite)
		{
			List<int> factors = new List<int>();
			//primeHolder = findFirstNPrimes(composite);
			//int flr = (int) Math.floor(Math.sqrt((double) composite));
			primeHolder = findPrimes(composite);

			int count = 0;
			int currentFactor = 0;
			int powerCounter = 1;
			double dbNum = (double) composite;
			double pwr = 0.0;
			int currentPrime = primeHolder[0];
			int primeCount = primeHolder.Count;
			int factorCount = 0;
			message = "";


			while (count < primeCount && composite > (currentPrime = primeHolder[count]))
			{

				if (composite % currentPrime == 0)
				{
					factors.Add(currentPrime);
				}

				count++;

			}

			factorCount = factors.Count;

			for (int i = 0; i < factorCount; i++)
			{
				currentFactor = factors[i];
				count = 0;
				powerCounter = 1;


				while ((dbNum / (pwr = Math.Pow(currentFactor, powerCounter))) % 1 == 0)
				{
					count++;
					powerCounter++;
				}

				if (count > 0)
				{
					message += currentFactor + "^" + count;
					//System.out.printf("%d^%d", currentFactor, count);
				}
				if (i < factorCount - 1)
				{
					message += "*";
					//System.out.printf("*");
				}
			}


			factors.Clear();

		}


		public List<int> findPrimes(int bound)
		{
			int count = 2;
			int primeCount = 0;
			List<int> alPrimes = new List<int>();

			while (count < bound + 1)
			{
				double input = (double)count;
				if (testPrimality(input))
				{
					alPrimes.Add(count);
					primeCount++;
				}
				count++;
			}

			return alPrimes;
		}

	}
}
