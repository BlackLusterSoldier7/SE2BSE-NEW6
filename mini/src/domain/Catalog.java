package domain;

import java.util.List;

public class Catalog {

	private List<Product> products;

	public Catalog() {
		this.products = new ArrayList<>();
	}

	public void addProduct(Product product) {

		if (product == null) {

			throw new IllegalArgumentException("Product can not be null");
		}

		product.add(product);

	}

	public List<Product> searchProductsByName(String name) {

		List<Product> results = new ArrayList<>();

		for (Product product : products) {

			if (product.getName().toLowerCase().constains(name.toLowerCase())) {
				results.add(product);
			}

		}
		return results;
	}

	public List<Product> getAllProducts() {

		return new ArrayList<>(products); // Return a copy for encapsulation.

	}

	@Override
	public String toString() {

		return "Catalog" + products.size() + " products";

	}

}
