package logicDomainLayer;

import DTO.UserDTO;

public class Review {

	// private User user; // who wrote the review
	private UserDTO user;
	private String message;
	private double rating;

	public Review(UserDTO user, String message, double rating) {

		if (rating < 0 || rating > 5) {

			throw new IllegalArgumentException("Rating moet tussen 0 en 5 zijn");

		}

		this.user = user;
		this.message = message;
		this.rating = rating;

	}

	public UserDTO getUser() {
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

		return "Review[User=" + user.getFirstname() + ", Message=" + message + ", Rating=" + rating + "]";

	}

}
