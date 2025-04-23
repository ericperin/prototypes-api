using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleTests
{
	/// <summary>
	/// Tests that a 10% discount for purchases of 4 to 9 identical items.
	/// </summary>
	[Fact(DisplayName = "Should apply 10% discount for purchases of 4 to 9 identical items")]
	public void Given_QuantityBetween4And9_When_CalculatingDiscount_Then_ShouldApply10PercentDiscount()
	{
		// Arrange
		var purchase = new SaleItem(Guid.NewGuid(), 9, 2.99m);
		// purchase.AddItem(Guid.NewGuid(), 2, 3.5m);
		// purchase.AddItem(Guid.NewGuid(), 1, 10.9m);
		// var purchase = ProductPurchaseTestData.CreateWithQuantity(5);

		// Act
		var discount = purchase.DiscountPercentage;

		// Assert
		Assert.Equal(0.10m, discount);
	}

	/// <summary>
	/// Tests that a 20% discount for purchases of 10 to 20 identical items.
	/// </summary>
	[Fact(DisplayName = "Should apply 20% discount for purchases of 10 to 20 identical items")]
	public void Given_QuantityBetween10And20_When_CalculatingDiscount_Then_ShouldApply20PercentDiscount()
	{
		// Arrange
		var purchase = new SaleItem(Guid.NewGuid(), 20, 3.99m);
		// var purchase = ProductPurchaseTestData.CreateWithQuantity(15);

		// Act
		var discount = purchase.DiscountPercentage;

		// Assert
		Assert.Equal(0.20m, discount);
	}

	/// <summary>
	/// Tests that a purchase with less than 4 items gets no discount.
	/// </summary>
	[Fact(DisplayName = "Should not apply discount for purchases of less than 4 identical items")]
	public void Given_QuantityLessThan4_When_CalculatingDiscount_Then_ShouldApplyNoDiscount()
	{
		// Arrange
		var purchase = new SaleItem(Guid.NewGuid(), 2, 4.99m);
		// var purchase = ProductPurchaseTestData.CreateWithQuantity(3);

		// Act
		var discount = purchase.DiscountPercentage;

		// Assert
		Assert.Equal(0m, discount);
	}

	/// <summary>
	/// Tests that a purchase of more than 20 identical items not allowed.
	/// </summary>
	[Fact(DisplayName = "Should throw exception when purchasing more than 20 identical items")]
	public void Given_QuantityGreaterThan20_When_CreatingPurchase_Then_ShouldThrowException()
	{
		// Act & Assert
		var exception = Assert.Throws<InvalidOperationException>(() => new SaleItem(Guid.NewGuid(), 21, 5.99m));
		Assert.Equal("Cannot purchase more than 20 identical items.", exception.Message);
	}
}