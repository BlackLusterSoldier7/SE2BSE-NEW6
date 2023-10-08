package logicDomainLayer;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class OrderManager {
	
	
	private List<Order> orders = new ArrayList<>(); 
	
	public void addOrder(Order order) {
		
		orders.add(order); 
		
		
	}
	
	public List<Order> getOrders() {
		
		return Collections.unmodifiableList(orders); // return an unmodifiable list 
		
	}
	
	

}
