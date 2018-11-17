using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
	[TestClass]
	public class ConcatTests
	{
		[TestMethod]
		public void concat_employee()
		{
			var first = new List<Employee>
			{
				new Employee() {Id = 1, Name = "David"}
			};
			var second = new List<Employee>
			{
				new Employee() {Id = 2, Name = "Kyo"},
				new Employee() {Id = 3, Name = "Tom"},
			};

			var actual = MyConcat(first, second);

			var expected = new List<Employee>
			{
				new Employee() {Id = 1, Name = "David"},
				new Employee() {Id = 2, Name = "Kyo"},
				new Employee() {Id = 3, Name = "Tom"},
			};
			expected.ToExpectedObject().ShouldEqual(actual.ToList());
		}

		[TestMethod]
		public void concat_integers()
		{
			var first = new int[] {1, 3, 5};
			var second = new int[] {2, 4, 6};

			var actual = MyConcat(first, second);

			var expected = new int[] {1, 3, 5, 2, 4, 6};
			expected.ToExpectedObject().ShouldEqual(actual.ToArray());
		}

		private IEnumerable<Employee> MyConcat(IEnumerable<Employee> first, IEnumerable<Employee> second)
		{
			throw new System.NotImplementedException();
		}

		private IEnumerable<int> MyConcat(IEnumerable<int> first, IEnumerable<int> second)
		{
			throw new System.NotImplementedException();
		}
	}
}