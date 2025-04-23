using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public sealed class Customer: BaseEntity
{
	public string Name { get; private set; }
}