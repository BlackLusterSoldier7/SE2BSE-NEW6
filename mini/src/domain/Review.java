package domain;

public class Review {

	private User user; // who wrote the review?
	private String message; // Review content
	private double rating; // Rating for the product 1 - 5

	public Review(User user, String message, double rating) {

		if (rating < 0 || rating > 5) {

			throw new IllegalArgumentException("Rating should be between 0 and 5");

		}

		this.user = user;
		this.message = message;
		this.rating = rating;

	}

	public User getUser() {

		return user;

	}

	public String getMessage() {

		return message;
	}

	public double getRating() {

		return rating;

	}

	@Override
	public String toString() {

		return "ReviewUser=" + user.getName() + ", Message=" + message + ", Rating=" + rating;

	}

}
