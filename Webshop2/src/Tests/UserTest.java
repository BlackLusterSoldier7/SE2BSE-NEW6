package Tests;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import sm2Webshop.Order;
import sm2Webshop.User;
import sm2Webshop.UserProfile;

public class UserTest {

	private User user;

	@BeforeEach
	void setUp() {

		UserProfile userProfile = new UserProfile("Burak", "user", "burak@outlook.com", "burak", "ergin");
		user = new User(userProfile);

	}

	@Test
	void testAddOrder() {

		Order order = new Order();
		user.addOrder(order);

	}

	@Test
	void testUsernameSetAndGet() {

		String newUsername = "newUsername";
		user.setUsername(newUsername);
	
		assertEquals(newUsername, user.getUsername());

	}

	@Test
	void testPasswordSetAndGet() {

		String newPassword = "newPassword99";
		user.setPassword(newPassword);
		assertEquals(newPassword, user.getPassword());

	}

}
