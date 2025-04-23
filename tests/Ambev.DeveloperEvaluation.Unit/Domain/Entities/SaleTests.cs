using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleTests
{
	/// <summary>
	/// Tests that correct customer and branch identifiers.
	/// </summary>
	[Fact(DisplayName = "Should initialize sale with correct customer and branch IDs")]
	public void Given_ValidParameters_When_CreatingSale_Then_ShouldSetCustomerAndBranchIds()
	{
		// Arrange
		var customerId = Guid.NewGuid();
		var branchId = Guid.NewGuid();

		// Act
		var sale = new Sale(customerId, branchId);

		// Assert
		Assert.Equal(customerId, sale.CustomerId);
		Assert.Equal(branchId, sale.BranchId);
	}

	/// <summary>
	/// Tests that TotalAmount returns zero when no have items.
	/// </summary>
	[Fact(DisplayName = "Should return zero total amount when no items added")]
	public void Given_NoItems_When_CalculatingTotalAmount_Then_ShouldBeZero()
	{
		// Arrange
		var sale = new Sale(Guid.NewGuid(), Guid.NewGuid());

		// Act
		var total = sale.TotalAmount;

		// Assert
		Assert.Equal(0m, total);
	}

	/// <summary>
	/// Tests that TotalAmount calculates correctly after adding multiple items.
	/// </summary>
	[Fact(DisplayName = "Should calculate total amount correctly after adding items")]
	public void Given_ItemsAdded_When_CalculatingTotalAmount_Then_ShouldReturnSumOfItemTotals()
	{
		// Arrange
		var sale = new Sale(Guid.NewGuid(), Guid.NewGuid());

		// Act
		sale.AddItem(Guid.NewGuid(), 2, 10.0m); // 20
		sale.AddItem(Guid.NewGuid(), 1, 15.5m); // 15.5

		// Assert
		Assert.Equal(35.5m, sale.TotalAmount);
	}
}