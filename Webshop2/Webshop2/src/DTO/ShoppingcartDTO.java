package DTO;

import java.util.ArrayList;
import java.util.List;

public class ShoppingcartDTO {

	private List<ProductDTO> products;

	public ShoppingcartDTO() {

		this.products = new ArrayList<>();
	}

	public ShoppingcartDTO(List<ProductDTO> products) {

		this.products = products;

	}

	public List<ProductDTO> getProducts() {

		return products;

	}

	public void setProducts(List<ProductDTO> products) {

		this.products = products;

	}

}
