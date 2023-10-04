package Tests;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import logicDomainLayer.Clothing;

import static org.junit.jupiter.api.Assertions.*;

public class ClothingTest {

	private Clothing clothing;

	@BeforeEach
	void setUp() {

		clothing = new Clothing("Pokemon Shirt", 55, "Pikachu shirt", "L", "Cotton");

	}

	@Test
	void testPrice() {

		assertEquals(55, clothing.getPrice());

	}

	@Test
	void testDisplayProductDetails() {

		String result = clothing.displayProductDetailsReturn();
		String expectedOutput = "Clothing Product: " + "Pokemon Shirt" + " - Size: " + "L" + " - Material: " + "Cotton";
		assertEquals(expectedOutput, result);

	}

}
