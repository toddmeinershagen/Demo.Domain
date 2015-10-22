namespace Demo.Domain
{
	public interface ICar : IEntity
	{
		string Make { get; }

		string Model { get; }
	}
}