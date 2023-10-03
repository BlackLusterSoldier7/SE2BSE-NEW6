package sm2Webshop;

public class UserProfile {

	private String username;
	private String password;
	private String email;
	private String firstname;
	private String lastname;

	public UserProfile(String username, String password, String email, String firstname, String lastname) {

		this.username = username;
		this.password = password;
		this.email = email;
		this.firstname = firstname;
		this.lastname = lastname;

	}

	public String getUsername() {

		return username;

	}

	public void setUsername(String username) {

		this.username = username;

	}

	public String getPassword() {

		return password;

	}

	public void setPassword(String password) {

		this.password = password;

	}

	public String getEmail() {

		return email;

	}

	public void setEmail(String email) {

		this.email = email;
	}

	public String getFirstname() {

		return this.firstname;

	}

	public void setFirstname(String firstname) {

		this.firstname = firstname;

	}

}
