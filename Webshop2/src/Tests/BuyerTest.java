package Tests;

import org.junit.jupiter.api.*;

import sm2Webshop.Buyer;
import sm2Webshop.Electronic;
import sm2Webshop.Product;

import static org.junit.jupiter.api.Assertions.*;

public class BuyerTest {

	// @Test test method. JUnit's runner looks for methods annotated with
	// @Test

	@Test
	void testConstructor() {

		Buyer buyer = new Buyer("Burak_Ergin", "123", "burak.ergin@outlook.com", "Burak", "Ergin");

		// does not return null?. If the method does return null
		// then the assertNotNull check will fail.

		assertNotNull(buyer.getShoppingCart());

	}

	@Test
	void testAddElectronicProductToCart() {

		Buyer buyer = new Buyer("Burak_Ergin", "123", "burak.ergin@outlook.com", "Burak", "Ergin");
		Electronic electronic = new Electronic("iPhone_15", 2000, "iPhone 15 Pro MAX 512 GB", "Apple", "2 years");

		buyer.addProductToCart(electronic);

		assertTrue(buyer.getShoppingCart().contains(electronic),
				"Shopping cart should contain the added electronic product.");

	}

}
