using System.Collections.Generic;
using System.Linq.Expressions;

namespace ZipSample.test
{
	public static class MyLinq
	{
		public static IEnumerable<TSource> MyConcat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			var firstEnumerator = first.GetEnumerator();
			while (firstEnumerator.MoveNext())
			{
				yield return firstEnumerator.Current;
			}

			var secondEnumerator = second.GetEnumerator();
			while (secondEnumerator.MoveNext())
			{
				yield return secondEnumerator.Current;
			}
		}

		public static IEnumerable<TSource> MyReverse<TSource>(this IEnumerable<TSource> source)
		{
			return new Stack<TSource>(source);
		}
	}
}