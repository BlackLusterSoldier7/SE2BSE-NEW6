package domain;

public class Product {

	private String name;
	private double price;
	private String description;
	private List<Review> reviews; // list to hold product reviews.

	public Product(String name, double price, String description) {

		this.name = name;
		this.price = price;
		this.description = description;
		this.reviews = new ArrayList<>();

	}

	public String getName() {
		return name;
	}

	public double getPrice() {
		return price;
	}

	public String getDescription() {

		return description;

	}

	public List<Review> getReviews() {

		return reviews;

	}

	public void addReview(Review review) {

		if (review != null) {
			reviews.add(review);
		}

	}

	@Override
	public String toString() {

		return "Name=" + name + ", Price=" + price + ", Description=" + description;

	}

}
