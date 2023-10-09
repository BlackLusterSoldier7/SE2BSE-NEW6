package logicDomainLayer;

public class Entry {

	private Product product;
	private int quantity; // aantal van product in winkelwagen

	public Entry(Product product, int quantity) {

		if (product == null) {

			throw new IllegalArgumentException("Product can not be null");

		}

		if (quantity <= 0) {

			throw new IllegalArgumentException("Quantity should be greater than 0");

		}

		this.product = product;
		this.quantity = quantity;

	}

	public Product getProduct() {

		return product;
	}

	public void getQuantity(int quantity) {

		if (quantity <= 0) {

			throw new IllegalArgumentException("Quantity should be greater than 0.");

		}

		this.quantity = quantity;

	}

	@Override
	public String toString() {

		return "Entry[Product=" + product.getName() + ", Quantity=" + quantity + "]";

	}

}
