package logicDomainLayer;



public class SeasonalDiscount implements DiscountStrategy {

	private double discountPercentage;

	public SeasonalDiscount(double discountPercentage) {

		if (discountPercentage > 100 || discountPercentage < 0) {
			throw new IllegalArgumentException("Discount percentage must be between 0 and 100");
		}
		this.discountPercentage = discountPercentage;
	}

	@Override
	public double applyDiscount(double price) {

		return price - ((discountPercentage / 100) * price);

	}

}
