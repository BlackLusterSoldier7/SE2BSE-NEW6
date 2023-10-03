package sm2Webshop;

public class WebshopUI {

	public void displayProductDetails(Product product) {

		System.out.println("Product: " + product.getName() + ", Price: " + product.getPrice() + ", Description: "
				+ product.getDescription());

	}

}
