using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public sealed class Branch(string name) : BaseEntity
{
	public string Name { get; private set; } = name;
}