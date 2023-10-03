package sm2Webshop;

import sm2Webshop.Product.DiscountStrategy;

public class Clothing extends Product {

	private String size;
	private String material;
	
	
	public Clothing(String name, double price, String description, String size, String material) {
		
		super(name, price, description); 
		this.size = size; 
		this.material = material; 
		
	}
	
	
	

	public Clothing(String name, double price, String description, DiscountStrategy discountStrategy , String size, String material) {

		super(name, price, description, discountStrategy);
		this.size = size;
		this.material = material;

	}
	
	
	public String displayProductDetailsReturn() {
		
		return "Clothing Product: " + getName() + " - Size: " + size + " - Material: " + material; 
		
		
	}
	
	
	

}
