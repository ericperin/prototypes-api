using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public sealed class Sale : BaseEntity
{
	public Sale(Guid customerId, Guid branchId)
	{
		Id = Guid.NewGuid();
		CustomerId = customerId;
		BranchId = branchId;
	}

	public int OrderNumber { get; private set; }
	
	public Guid CustomerId { get; private set; }
	public Customer Customer { get; private set; }
	
	public Guid BranchId { get; private set; }
	public Branch Branch { get; private set; }
	
	public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

	private ICollection<SaleItem> Items { get; set; } = new List<SaleItem>();

	public decimal TotalAmount => Items.Sum(x => x.TotalPrice);

	public void AddItem(Guid productId, int quantity, decimal unitPrice)
	{
		Items.Add(new SaleItem(productId, quantity, unitPrice));
	}
}