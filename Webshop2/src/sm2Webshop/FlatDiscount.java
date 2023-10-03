package sm2Webshop;

import sm2Webshop.Product.DiscountStrategy;

public class FlatDiscount implements DiscountStrategy {

	private double discountAmount;

	public FlatDiscount(double discountAmount) {

		if (discountAmount < 0 || discountAmount > 100) {

			throw new IllegalArgumentException("Discount percentage should be between 0 and 100 inclusive.");

		}

		this.discountAmount = discountAmount;

	}

	@Override
	public double applyDiscount(double price) {

		return price - ((discountAmount / 100) * price);

	}

}
