using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
	[TestClass]
	public class ExceptTests
	{
		[TestMethod]
		public void Except_integers()
		{
			var first = new List<int> { 1, 4, 3, 5, 4 };
			var second = new List<int> { 5, 3, 7, 9 };

			var expected = new List<int> { 1, 4 };

			var actual = first.MyExcept(second).ToList();
			expected.ToExpectedObject().ShouldEqual(actual);
		}

		[TestMethod]
		public void Except_Girl()
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
				new Girl(){Name="Amanda"}
			};

			var actual = first.MyExcept(second, new GirlEqualityComparer()).ToList();
			expected.ToExpectedObject().ShouldEqual(actual);
		}
	}
}