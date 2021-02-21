using System;
using System.Collections.Generic;

namespace ProductOfConsecutiveFibNumbers
{
	class Program
	{
		static void Main()
		{
			var result = ProductFib(4895);
			Console.WriteLine(string.Join(", ", result).TrimEnd());
		}

		public static ulong[] ProductFib(ulong prod)
		{
			var set = new List<ulong>();
			set.AddRange(new ulong[] { 0, 1 });
			for (ulong i = 2; i <= prod; i++)
			{
				set.Add(set[(int)i - 1] + set[(int)i - 2]);
			}
			var fibonacii = set.ToArray();

			ulong factorOne;
			ulong factorTwo;
			var isValidFactors = false;
			var result = new ulong[3];

			for (int i = 0; i < fibonacii.Length; i++)
			{
				factorOne = fibonacii[i];
				for (int k = 0; k < fibonacii.Length; k++)
				{
					factorTwo = fibonacii[k];
					var productValue = factorOne * factorTwo;
					if (productValue == prod)
					{
						result[0] = factorOne;
						result[1] = factorTwo;
						result[2] = 1;
						return result;

					}
					else if (factorOne * factorTwo > prod)
					{
						break;
					}
				}
			}

			if (isValidFactors == false)
			{
				for (int i = 0; i < fibonacii.Length; i++)
				{
					var firstFactor = fibonacii[i];
					var secondFactor = fibonacii[i + 1];
					if (firstFactor * secondFactor > prod)
					{
						result[0] = firstFactor;
						result[1] = secondFactor;
						result[2] = 0;
						return result;
					}
				}
			}

			return result;
		}
	}
}
