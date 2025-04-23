using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public sealed class SaleItem : BaseEntity
{
	private const int MaxLimit = 20;

	public SaleItem(Guid productId, int quantity, decimal unitPrice)
	{
		if (quantity > MaxLimit)
		{
			throw new InvalidOperationException($"Cannot purchase more than {MaxLimit} identical items.");
		}

		ProductId = productId;
		Quantity = quantity;
		UnitPrice = unitPrice;
	}

	public Guid ProductId { get; private set; }
	public Product Product { get; private set; }

	public int Quantity { get; private set; }
	public decimal UnitPrice { get; private set; }

	public decimal DiscountPercentage
	{
		get
		{
			if (Quantity is >= 10 and <= MaxLimit) return 0.20m;
			if (Quantity >= 4) return 0.10m;

			return 0;
		}
	}

	public decimal TotalPrice => Quantity * UnitPrice * (1 - DiscountPercentage);
}