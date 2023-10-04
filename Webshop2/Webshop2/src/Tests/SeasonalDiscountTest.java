package Tests;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.function.Executable;

import logicDomainLayer.SeasonalDiscount;

import static org.junit.jupiter.api.Assertions.*;

public class SeasonalDiscountTest {

	private SeasonalDiscount discount10Percent;
	private SeasonalDiscount discount50Percent;
	private SeasonalDiscount discount0Percent;

	@BeforeEach
	void setUp() {

		discount10Percent = new SeasonalDiscount(10); // 10% discount
		discount50Percent = new SeasonalDiscount(50); // 50% discount
		discount0Percent = new SeasonalDiscount(0); // 0% discount

	}

	@Test
	void testApply10PercentDiscount() {

		double price = 100;
		assertEquals(90, discount10Percent.applyDiscount(price));

	}

	@Test
	void testApply50PercentDiscount() {

		double price = 100;
		assertEquals(50, discount50Percent.applyDiscount(price));

	}

	@Test
	void testApply0PercentDiscount() {

		double price = 100;
		assertEquals(100, discount0Percent.applyDiscount(price));

	}

	@Test
	void testApplyDiscountOnZeroPrice() {

		double price = 0;
		assertEquals(0, discount10Percent.applyDiscount(price));

	}

	@Test
	void testNegativeDiscount() {

		assertThrows(IllegalArgumentException.class, new Executable() {

			@Override
			public void execute() throws Throwable {

				new SeasonalDiscount(-10);

			}

		});

	}

	@Test
	void testOver100PercentDiscount() {

		assertThrows(IllegalArgumentException.class, new Executable() {

			@Override
			public void execute() throws Throwable {

				new SeasonalDiscount(110);

			}

		});

	}

}
