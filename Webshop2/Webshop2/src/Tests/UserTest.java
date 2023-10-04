package Tests;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import DTO.UserDTO;
import logicDomainLayer.Order;
import logicDomainLayer.User;

public class UserTest {

	private User user;

	@BeforeEach
	void setUp() {

		UserDTO userProfile = new UserDTO("Burak", "user", "burak@outlook.com", "burak", "ergin");
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
