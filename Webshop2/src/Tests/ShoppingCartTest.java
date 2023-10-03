package Tests;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import sm2Webshop.Electronic;
import sm2Webshop.Product;
import sm2Webshop.ShoppingCart;

import static org.junit.jupiter.api.Assertions.*;

public class ShoppingCartTest {

	private ShoppingCart shoppingCart;
	private Product product1;
	private Product product2;

	@BeforeEach
	void setUp() {

		shoppingCart = new ShoppingCart();

		product1 = new Electronic("iPhone 13", 800, "iPhone 13 512 GB", "Apple", "1 year");
		product2 = new Electronic("Macbook", 7000, "Macbook Pro 15 inch 64 gb graphic card", "Apple", "2 years");
	}

	@Test
	void testAddProduct() {

		shoppingCart.addProduct(product1);
		assertTrue(shoppingCart.contains(product1));

	}

	@Test
	void testAddNullProduct() {

		shoppingCart.addProduct(null);
		assertFalse(shoppingCart.contains(null));

	}

}
