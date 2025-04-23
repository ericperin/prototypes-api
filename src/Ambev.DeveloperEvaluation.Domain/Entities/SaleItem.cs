using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public sealed class SaleItem: BaseEntity
{
	public Guid ProductId { get; private set; }
	public Product Product { get; private set; }

	public int Quantity { get; private set; }
	public decimal UnitPrice { get; private set; }
	public decimal DiscountPercentage { get; private set; }
	public decimal TotalPrice => Quantity * UnitPrice * (1 - DiscountPercentage / 100m);
}