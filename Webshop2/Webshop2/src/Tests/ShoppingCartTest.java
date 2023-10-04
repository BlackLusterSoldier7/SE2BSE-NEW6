package Tests;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import logicDomainLayer.Electronic;
import logicDomainLayer.Product;
import logicDomainLayer.Shoppingcart;

import static org.junit.jupiter.api.Assertions.*;

public class ShoppingCartTest {

	private Shoppingcart shoppingcart;
	private Product product1;
	private Product product2;

	@BeforeEach
	void setUp() {

		shoppingcart = new Shoppingcart();

		product1 = new Electronic("iPhone 13", 800, "iPhone 13 512 GB", "Apple", "1 year");
		product2 = new Electronic("Macbook", 7000, "Macbook Pro 15 inch 64 gb graphic card", "Apple", "2 years");
	}

	@Test
	void testAddProduct() {

		shoppingcart.addProduct(product1);
		assertTrue(shoppingcart.contains(product1));

	}

	@Test
	void testAddNullProduct() {

		shoppingcart.addProduct(null);
		assertFalse(shoppingcart.contains(null));

	}

	
	
	
}
