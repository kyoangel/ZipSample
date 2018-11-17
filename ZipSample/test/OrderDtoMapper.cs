namespace ZipSample.test
{
	public class OrderDtoMapper : IMapper<Order, OrderDto>
	{
		public OrderDto Project(Order order)
		{
			return new OrderDto()
			{
				Id = order.OrderId,
				TotalAmount = order.Amount,
				Date = order.CreateDate.ToString("yyyyMMdd")
			};
		}
	}
}