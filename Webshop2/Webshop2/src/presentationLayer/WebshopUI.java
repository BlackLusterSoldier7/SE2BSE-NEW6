package presentationLayer;

import logicDomainLayer.Product;

public class WebshopUI {

	public void displayProductDetails(Product product) {

		System.out.println("Product: " + product.getName() + ", Price: " + product.getPrice() + ", Description: "
				+ product.getDescription());

	}

}
