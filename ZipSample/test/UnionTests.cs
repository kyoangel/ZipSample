using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
	[TestClass]
	public class UnionTests
	{
		[TestMethod]
		public void Union_integers()
		{
			var first = new List<int> { 1, 3, 5 };
			var second = new List<int> { 5, 3, 7, 9 };

			var expected = new List<int> { 1, 3, 5, 7, 9 };

			var actual = first.MyUnion(second);
			expected.ToExpectedObject().ShouldEqual(actual.ToList());
		}

		[TestMethod]
		public void Union_Girls()
		{
			var first = new List<Girl>
			{
				new Girl(){Name="Amanda"},
				new Girl(){Name="Lucy"}
			};

			var second = new List<Girl>
			{
				new Girl(){Name="Lucy"},
				new Girl(){Name="Xinyi"},
			};

			var expected = new List<Girl>
			{
				new Girl(){Name="Amanda"},
				new Girl(){Name="Lucy"},
				new Girl(){Name="Xinyi"}
			};

			var actual = first.MyUnion(second, new GirlEqualityComparer());
			expected.ToExpectedObject().ShouldEqual(actual.ToList());
		}
	}
}