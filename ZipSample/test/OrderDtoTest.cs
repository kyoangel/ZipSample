using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ZipSample.test
{
	/// <summary>
	/// Summary description for OrderDtoTest
	/// </summary>
	[TestClass]
	public class OrderDtoTest
	{
		[TestMethod]
		public void order_to_orderDto()
		{
			var order = new Order()
			{
				OrderId = 1,
				Amount = 10,
				CreateDate = new DateTime(2018, 4, 1)
			};

			var expected = new OrderDto()
			{
				Id = 1,
				TotalAmount = 10,
				Date = "20180401"
			};

			var actual = Mylinq.MyProject(order, o => new OrderDto()
			{
				Id = o.OrderId,
				TotalAmount = o.Amount,
				Date = o.CreateDate.ToString("yyyyMMdd")
			});

			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.TotalAmount, actual.TotalAmount);
			Assert.AreEqual(expected.Date, actual.Date);
		}

		[TestMethod]
		public void order_to_orderDto_interface()
		{
			var order = new Order()
			{
				OrderId = 1,
				Amount = 10,
				CreateDate = new DateTime(2018, 4, 1)
			};

			var expected = new OrderDto()
			{
				Id = 1,
				TotalAmount = 10,
				Date = "20180401"
			};

			var actual = Mylinq.MyProject(order, new OrderDtoMapper());

			Assert.AreEqual(expected.Id, actual.Id);
			Assert.AreEqual(expected.TotalAmount, actual.TotalAmount);
			Assert.AreEqual(expected.Date, actual.Date);
		}

		[TestMethod]
		public void order_to_orderDto_refection()
		{
			var order = new Order()
			{
				OrderId = 1,
				Amount = 10,
				CreateDate = new DateTime(2018, 4, 1),
				Name = "xxx",
				Key = 100
			};

			var expected = new OrderDto()
			{
				Name = "xxx",
				Key = 100
			};

			var actual = Mylinq.Refelction(order);

			Assert.AreEqual(expected.Name, actual.Name);
			Assert.AreEqual(expected.Key, actual.Key);
		}
	}

	public class OrderDto
	{
		public string Date { get; set; }
		public decimal TotalAmount { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public int Key { get; set; }
	}

	public class Order
	{
		public DateTime CreateDate { get; set; }
		public int Amount { get; set; }
		public int OrderId { get; set; }
		public string Name { get; set; }
		public int Key { get; set; }
	}
}