package Tests;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import sm2Webshop.Electronic;
import sm2Webshop.Product;
import sm2Webshop.Seller;

import static org.junit.jupiter.api.Assertions.*;

public class SellerTest {

	private Seller seller;
	private Product product1;
	private Product product2;

	@BeforeEach
	void setUp() {

		seller = new Seller("userGuest", "123", "userguest@outlook.com", "User", "Lastname");

		product1 = new Electronic("iPhone 13", 800, "iPhone 13 512 GB", "Apple", "1 year");
		product2 = new Electronic("Macbook", 7000, "Macbook Pro 15 inch 64 gb graphic card", "Apple", "2 years");

	}

	@Test
	void testAddSingleProduct() {

		seller.addProduct(product1);
		assertTrue(seller.contains(product1));

	}

	@Test
	void testAddMultipleProducts() {

		seller.addProduct(product1);
		seller.addProduct(product2);

		assertTrue(seller.contains(product1));
		assertTrue(seller.contains(product2));

	}

	@Test
	void testContainsProductTrue() {

		seller.addProduct(product1);
		assertTrue(seller.contains(product1));

	}

	@Test
	void testContainsProductFalse() {

		assertFalse(seller.contains(product1));

	}

}
