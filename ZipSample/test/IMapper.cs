namespace ZipSample.test
{
	public interface IMapper<TSource, TResult>
	{
		TResult Project(TSource order);
	}
}