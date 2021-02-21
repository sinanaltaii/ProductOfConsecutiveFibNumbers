using System;
using System.Diagnostics;

namespace ProductOfConsecutiveFibNumbers
{
	class Program
	{
		static void Main()
		{
			var stopWatch = Stopwatch.StartNew();
			var result = ProductFib(4895);
			stopWatch.Stop();
			Console.WriteLine($"Ticks: {stopWatch.ElapsedTicks}");
			Console.WriteLine(string.Join(", ", result).TrimEnd());
		}

		public static ulong[] ProductFib(ulong prod)
		{
			ulong prev = 0;
			ulong curr = 1;
			ulong multiplication = 0;
			while (prev * curr < prod)
			{
				ulong temp = curr;
				curr += prev;
				prev = temp;
				multiplication = curr * prev;
			}
			var isFactorsOfProduct = multiplication == prod ? 1 : 0;
			return new ulong[] { prev, curr, (ulong)isFactorsOfProduct };
		}
	}
}