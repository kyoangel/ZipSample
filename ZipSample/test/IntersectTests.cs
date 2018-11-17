using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
	[TestClass]
	public class IntersectTests
	{
		[TestMethod]
		public void intersect_integers()
		{
			var first = new List<int> {1, 3, 5};
			var second = new List<int> {5, 3, 7, 9};

			var expected = new List<int> {3, 5};

			var actual = MyIntersect(first, second).ToList();
			expected.ToExpectedObject().ShouldEqual(actual);
		}

		[TestMethod]
		public void intersect_girls()
		{
			var first = new List<Girl>
			{
				new Girl() {Name = "Amanda"},
				new Girl() {Name = "Lucy"}
			};
			var second = new List<Girl>
			{
				new Girl() {Name = "Lucy"},
				new Girl() {Name = "Xinyi"}
			};

			var expected = new List<Girl>
			{
				new Girl() {Name = "Lucy"},
			};

			var actual = MyIntersect(first, second);
			expected.ToExpectedObject().ShouldEqual(actual.ToList());
		}

		private IEnumerable<Girl> MyIntersect(IEnumerable<Girl> first, IEnumerable<Girl> second)
		{
			throw new System.NotImplementedException();
		}

		private IEnumerable<int> MyIntersect(IEnumerable<int> first, IEnumerable<int> second)
		{
			throw new System.NotImplementedException();
		}
	}
}