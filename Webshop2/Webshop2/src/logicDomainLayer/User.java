package logicDomainLayer;

import java.util.*;

import DTO.UserDTO;

public class User {

	private UserDTO profile;

	private String[] searchHistory = new String[10];
	private List<String> searchHistoryList = new ArrayList<>();
	private List<Order> orders = new ArrayList<>();
	private Shoppingcart shoppingcart;

	public User(UserDTO profile) {

		this.profile = profile;
		this.shoppingcart = new Shoppingcart();
	}

	public void addOrder(Order order) {

		orders.add(order);

	}

	public UserDTO getProfile() {

		return profile;

	}

	public List<Order> getOrders() {
		return orders;

	}

	public String[] getSearchHistory() {

		return searchHistory;

	}

	public List<String> getSearchHistoryList() {

		return searchHistoryList;

	}

	public Shoppingcart getShoppingCart() {

		if (shoppingcart == null) {

			shoppingcart = new Shoppingcart();

		}
		return shoppingcart;

	}

	public void setUsername(String username) {

		this.profile.setUsername(username);

	}

	public void setPassword(String password) {

		this.profile.setPassword(password);

	}

	public String getUsername() {

		return this.profile.getUsername();

	}

	public String getPassword() {

		return this.profile.getPassword();

	}

}
