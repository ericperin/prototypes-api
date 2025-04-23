using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public sealed class Branch : BaseEntity
{
	public Branch(string name)
	{
		Id = Guid.NewGuid();
		Name = name;
	}

	public string Name { get; private set; }
}