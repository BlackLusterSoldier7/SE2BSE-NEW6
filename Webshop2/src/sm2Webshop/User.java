package sm2Webshop;

import java.util.*;

public class User {

	private UserProfile profile;

	private String[] searchHistory = new String[10];
	private List<String> searchHistoryList = new ArrayList<>();
	private List<Order> orders = new ArrayList<>();
	private ShoppingCart shoppingCart;

	public User(UserProfile profile) {

		this.profile = profile;
		this.shoppingCart = new ShoppingCart();
	}

	public void addOrder(Order order) {

		orders.add(order);

	}

	public void addSearch(String searchQuery) {

		for (int i = 0; i < searchHistory.length - 1; i++) {

			searchHistory[i] = searchHistory[i + 1];

		}

		searchHistory[searchHistory.length - 1] = searchQuery;

		searchHistoryList.add(searchQuery);

	}

	public UserProfile getProfile() {

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

	public ShoppingCart getShoppingCart() {

		if (shoppingCart == null) {

			shoppingCart = new ShoppingCart();

		}
		return shoppingCart;

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
