package DTO;

public class ProductDTO {

	private String name;
	private double price;

	public ProductDTO() {

	}

	public ProductDTO(String name, double price) {

		this.name = name;
		this.price = price;

	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {

		this.name = name;
	}

	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {

		this.price = price;

	}

}
