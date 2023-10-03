package sm2Webshop;

// inherit from super class User 
public class Buyer extends User {

	// associaton Buyer with ShoppingCart class

	private ShoppingCart shoppingCart;

	public Buyer(String username, String password, String email, String firstname, String lastname) {

		super(new UserProfile(username, password, email, firstname, lastname));

		this.shoppingCart = new ShoppingCart();

	}

	public void addProductToCart(Product product) {

		this.shoppingCart.addProduct(product);

	}

}
