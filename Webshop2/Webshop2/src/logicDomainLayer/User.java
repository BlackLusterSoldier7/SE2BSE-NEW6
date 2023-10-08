package logicDomainLayer;

import java.util.*;

import DTO.UserDTO;

public class User {

	private UserDTO profile;

	public User(UserDTO profile, Shoppingcart shoppingcart) {

		this.profile = profile;

	}

	public UserDTO getProfile() {
		return profile;
	}

}
