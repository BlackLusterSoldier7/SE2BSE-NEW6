package Tests;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import org.junit.jupiter.api.function.Executable;

import logicDomainLayer.FlatDiscount;

import static org.junit.jupiter.api.Assertions.*;

public class FlatDiscountTest {

	private FlatDiscount flatDiscount;

	@Test
	void testCorrectDiscountApplied() {
		flatDiscount = new FlatDiscount(10); // 10% korting geven
		double price = 100;
		assertEquals(90, flatDiscount.applyDiscount(price));
	}

	@Test
	void testZeroDiscount() {
		flatDiscount = new FlatDiscount(0); // 0% korting testen
		double price = 100;
		assertEquals(100, flatDiscount.applyDiscount(price));
	}

	@Test
	void testNegativeDiscount() {
		assertThrows(IllegalArgumentException.class, new Executable() {
			@Override
			public void execute() throws Throwable {
				new FlatDiscount(-10); // Negative discount, should throw an exception!!!!
			}
		});
	}

	@Test
	void testOver100PercentDiscount() {
		assertThrows(IllegalArgumentException.class, new Executable() {
			@Override
			public void execute() throws Throwable {
				new FlatDiscount(110); // Greater than 100% discount, should throw an exception.
			}
		});
	}
}
