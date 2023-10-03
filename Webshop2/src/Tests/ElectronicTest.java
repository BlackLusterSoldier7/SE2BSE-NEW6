package Tests;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import sm2Webshop.Electronic;

import static org.junit.jupiter.api.Assertions.*;

public class ElectronicTest {

	private Electronic electronic;

	@BeforeEach
	void setUp() {

		electronic = new Electronic("Macbook", 5000, "Macbook Pro i9 162 GB RAM 20TB SSD", "Apple", "2 years");

	}

	@Test
	void testName() {

		assertEquals("Macbook", electronic.getName());

	}

	@Test
	void testPrice() {

		assertEquals(5000, electronic.getPrice());

	}

	@Test
	void testDescription() {

		assertEquals("Macbook Pro i9 162 GB RAM 20TB SSD", electronic.getDescription());

	}

	@Test
	void testBrand() {

		assertEquals("Apple", electronic.getBrand());

	}

	@Test
	void testWarrantyPeriod() {

		assertEquals("2 years", electronic.getWarrantyPeriod());

	}

	@Test
	void testDisplayProductDetails() {

		String actualOutput = electronic.displayProductDetailsReturn();
		String expectedOutput = "Electronic Product: Macbook - Brand: Apple - Warranty: 2 years";

		assertEquals(expectedOutput, actualOutput);
	}

}
