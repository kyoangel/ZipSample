using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ZipSample.test
{
	public static class Mylinq
	{
		public static IEnumerable<int> MyConcat(this IEnumerable<int> first, IEnumerable<int> second)
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

		public static IEnumerable<string> MyReverse(this IEnumerable<string> source)
		{
			var enumerator = source.GetEnumerator();
			var stack = new Stack<string>();
			while (enumerator.MoveNext())
			{
				stack.Push(enumerator.Current);
			}

			while (stack.Count != 0)
			{
				yield return stack.Pop();
			}
		}

		public static IEnumerable<TResult> MyOfType<TResult>(this IEnumerable source)
		{
			var enumerator = source.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current is TResult)
				{
					yield return (TResult)enumerator.Current;
				}
			}
		}

		public static IEnumerable<TResult> MyCast<TResult>(this IEnumerable source)
		{
			var enumerator = source.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (!(enumerator.Current is TResult))
				{
					throw new JoeyException();
				}
				else
				{
					yield return (TResult)enumerator.Current;
				}
			}
		}

		public static IEnumerable<TResult> MyZip<T1, T2, TResult>
			(this IEnumerable<T1> first
			, IEnumerable<T2> second
			, Func<T2, T1, TResult> selector)
		{
			var girlsEnumerator = second.GetEnumerator();
			var keysEnumerator = first.GetEnumerator();
			while (girlsEnumerator.MoveNext() && keysEnumerator.MoveNext())
			{
				var firstElement = girlsEnumerator.Current;
				var secondElement = keysEnumerator.Current;
				yield return selector(firstElement, secondElement);
			}
		}

		public static IEnumerable<TSource> MyUnion<TSource>(this IEnumerable<TSource> first,
			IEnumerable<TSource> second)
		{
			return MyUnion(first, second, EqualityComparer<TSource>.Default);
		}

		public static IEnumerable<TSource> MyUnion<TSource>
			(this IEnumerable<TSource> first
			, IEnumerable<TSource> second
			, IEqualityComparer<TSource> equalityComparer)
		{
			var hashSet = new HashSet<TSource>(equalityComparer);

			var firstEnumerator = first.GetEnumerator();
			while (firstEnumerator.MoveNext())
			{
				if (hashSet.Add(firstEnumerator.Current))
				{
					yield return firstEnumerator.Current;
				}
			}

			var secondEnumerator = second.GetEnumerator();
			while (secondEnumerator.MoveNext())
			{
				if (hashSet.Add(secondEnumerator.Current))
				{
					yield return secondEnumerator.Current;
				}
			}
		}

		public static IEnumerable<TSource> MyIntersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> girlEqualityComparer)
		{
			var hashSet = new HashSet<TSource>(second, girlEqualityComparer);
			var firstEnumerator = first.GetEnumerator();
			while (firstEnumerator.MoveNext())
			{
				if (hashSet.Remove(firstEnumerator.Current))
				{
					yield return firstEnumerator.Current;
				}
			}
		}

		public static IEnumerable<TSource> MyIntersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			return Mylinq.MyIntersect(first, second, EqualityComparer<TSource>.Default);
		}

		public static IEnumerable<TSource> MyExcept<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> girlEqualityComparer)
		{
			var hashSet = new HashSet<TSource>(second, girlEqualityComparer);
			var enumerator = first.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (hashSet.Add(enumerator.Current))
				{
					yield return enumerator.Current;
				}
			}
		}

		public static IEnumerable<TSource> MyExcept<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
		{
			return first.MyExcept(second, EqualityComparer<TSource>.Default);
		}

		public static TResult MyProject<TSource, TResult>(this TSource source, Func<TSource, TResult> selector)
		{
			return selector(source);
		}

		public static TResult MyProject<TSource, TResult>(this TSource source, IMapper<TSource, TResult> mapper)
		{
			return mapper.Project(source);
		}

		public static OrderDto Refelction(Order order)
		{
			//Type type = Type.GetType("ZipSample.test.OrderDto", true);
			object instance = Activator.CreateInstance(typeof(OrderDto));

			var names = typeof(Order).GetProperties().Select(x => x.Name);

			foreach (var orderDtoInfo in typeof(OrderDto).GetProperties())
			{
				if (names.Contains(orderDtoInfo.Name))
				{
					orderDtoInfo.SetValue(instance, typeof(Order).GetProperty(orderDtoInfo.Name).GetValue(order, null));
				}
			}

			return instance as OrderDto;
		}
	}

	public class GirlEqualityComparer : EqualityComparer<Girl>
	{
		public override bool Equals(Girl x, Girl y)
		{
			return x.Name == y.Name;
		}

		public override int GetHashCode(Girl girl)
		{
			return Tuple.Create(girl.Name).GetHashCode();
		}
	}
}