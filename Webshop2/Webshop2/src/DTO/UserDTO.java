package DTO;

public class UserDTO {


	private String firstname;
	private String lastname;

	public UserDTO(String firstname, String lastname) {

	
		this.firstname = firstname;
		this.lastname = lastname;

	}








	public String getFirstname() {

		return this.firstname;

	}

	public void setFirstname(String firstname) {

		this.firstname = firstname;

	}
	
	
	public String getLastname() {
		
		return this.lastname; 
		
		
	}
	
	
	public void setLastname(String lastname) {
		this.lastname = lastname;
	}
	

}
