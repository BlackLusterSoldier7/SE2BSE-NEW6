package sm2Webshop;

import java.util.ArrayList;
import java.util.Scanner;

import sm2Webshop.Product.DiscountStrategy;

public class WebshopConsoleAppl {

	private User currentUser;
	private Scanner scanner;
	private WebshopUI webshopUI;

	private ArrayList<Product> products = new ArrayList<>(); // een lijst waar je alle producten in kunt opslaan.

	// scanner attribute of class WebshopConsoleaAppl is initialized
	// no null. no nullpointerexception more

	public WebshopConsoleAppl() {

		this.scanner = new Scanner(System.in);
		this.webshopUI = new WebshopUI(); // Initialize the WebshopUI

	}

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		System.out.println("BOL.COM webshop");

		WebshopConsoleAppl app = new WebshopConsoleAppl();
		app.run();

	}

	private void run() {

		// Product flatDiscountProduct = new Product("iPhone 13", 800, new
		// FlatDiscount(30));
		// Product seasonalDiscountProduct = new Product("Winter cap", 150, new
		// SeasonalDiscount(25)); //25% discount

		FlatDiscount flatDiscount = new FlatDiscount(30); // 30% korting
		SeasonalDiscount seasonalDiscount = new SeasonalDiscount(20);

		Electronic flatDiscountProduct = new Electronic("iPhone 13", 800, "4 GB RAM, 256 GB SSD", flatDiscount, "Apple",
				"2 years");

		Clothing seasonalDiscountProduct = new Clothing("Winter cap", 150, "Diesel winter cap leather outside",
				seasonalDiscount, "L", "Cotton");

		System.out.println("iPhone 13 price after Discount: " + flatDiscountProduct.getPriceAfterDiscount());
		System.out.println("Winter cap price after discount: " + seasonalDiscountProduct.getPriceAfterDiscount());

		int numberExit = 10;

		// test line burak local git folder?

		while (numberExit != 0) {

			printMenu();

			int userInput = scanner.nextInt();
			numberExit = userInput;
			scanner.nextLine();

			switch (userInput) {

			case 1:
				logIn();
				break;
			case 2:
				register();
				break;
			case 3:
				if (currentUser != null) {

					viewProducts();

				} else {

					System.out.println("You need to be logged in");

				}
				break;
			case 4:
				if (currentUser != null) {

					// currentUser.viewSearchHistory();

				} else {
					System.out.println("Logg in to see view search history");
				}
				break;

			case 5:

				placeOrder();
				break;

			case 6:

				addProductToCart();
				break;

			case 7:

				displayProductsInCart();
				break;

			case 8:

				addElectronics();
				break;

			case 9:

				addClothing();
				break;

			case 10:

				System.out.println("Thank you for visiting bol.com");
				// exit method
				break;

			default:
				System.out.println("Give a valid input please. ");

			}

		}

	}

	private void printMenu() {

		System.out.println("\nWelcome to bol.com");
		System.out.println("1. Log in");
		System.out.println("2. Register");
		System.out.println("3. View Products");
		System.out.println("4. View Search History");
		System.out.println("5. Place an Order");
		System.out.println("6. Add Product to ShoppingCart");
		System.out.println("7. Display Products in Shopping Cart");
		System.out.println("8. Add Electronic Product");
		System.out.println("9. Add Clothing Product");

		System.out.println("0. Exit");
		System.out.print("Enter number: ");

	}

	private void addElectronics() {

		System.out.print("Enter product name: ");
		String name = scanner.nextLine();

		System.out.print("Enter product price: ");
		double price = scanner.nextDouble();

		System.out.print("Enter product description: ");
		String description = scanner.nextLine();

		// Add other specific attributes of the electronic product
		// Electronic electronicProduct = new Electronic(name, price, description,
		// electronicProduct.getBrand(), electronicProduct.getWarrantyPeriod());
		Electronic electronicProduct = new Electronic(name, price, description, "Apple", "2 years");

		products.add(electronicProduct);
		System.out.println(name + " has been added to the product list.");

	}

	private void addClothing() {

		System.out.print("Enter product name: ");
		String name = scanner.nextLine();

		System.out.print("Enter product price: ");
		double price = scanner.nextDouble();

		System.out.print("Enter product description: ");
		String description = scanner.nextLine();

		// Add other specific attributes of the clothing product

		Clothing clothingProduct = new Clothing(name, price, description, "L", "Coton");

		products.add(clothingProduct);

		System.out.println(name + " has been added to the product list. ");

	}

	private void logIn() {

		System.out.print("Enter username: ");
		String username = scanner.nextLine();

		System.out.println("Enter password: ");
		String password = scanner.nextLine();

		if ("userBurak".equals(username) && "1234".equals(password)) {

			this.currentUser = new Buyer(username, password, null, null, null);
			System.out.println("You are succesfull logged in as " + username);

		} else {

			System.out.println("Login not succes. Check your username and password again");

		}

	}

	private void register() {

		System.out.print("Enter your username: ");
		String username = scanner.nextLine();

		System.out.print("Enter your password: ");
		String password = scanner.nextLine();

		System.out.print("Enter your email: ");
		String email = scanner.nextLine();

		System.out.print("Enter your firstName: ");
		String firstName = scanner.nextLine();

		System.out.print("Enter your lastName: ");
		String lastName = scanner.nextLine();

		this.currentUser = new Buyer(username, password, email, firstName, lastName);
		System.out.println("Your registration has been completed. Username: " + username + "\n E-mail: " + email);

	}

	// mac keyboard euro sign. option + 2 is euro sign €€€
	private void viewProducts() {

		System.out.println("1. Macbook Pro 2023 i9 - €3500");
		System.out.println("2. iPhone 15 512 GB SpaceGray - €1700");
		System.out.println("3. Headphones Apple Dokter Dre - €900");
		System.out.println("Choose a product from list. Enter 0 to stop. ");

		int inputUser = scanner.nextInt();

		Product chosenProduct = null;

		switch (inputUser) {

		case 1:
			chosenProduct = new Product("Macbook Pro 2023 i9", 3500, "");
			break;
		case 2:
			chosenProduct = new Product("iPhone 15 512 GB SpaceGray", 1700, "");
			break;
		case 3:
			chosenProduct = new Product("Headphones Apple Dokter Dre", 900, "");
			break;
		default:
			System.out.println("Invalid choice.");
			break;
		}

	}

	private void placeOrder() {

		// there is a user currently logged in.
		if (currentUser != null) {

			ShoppingCart cart = currentUser.getShoppingCart();

			Order order = cart.convertToOrder();
			currentUser.addOrder(order);
			System.out.println("Order placed successfully ");

		} else {

			System.out.println("Please login first ");
		}

	}

	private void addProductToCart() {

		System.out.println("------");
		System.out.println("Enter product name: ");
		String productName = scanner.nextLine();

		System.out.print("Enter product price: ");
		double productPrice = scanner.nextDouble();

//		Product product = new Product(productName, productPrice);
//
//		// current user's cart is updated
//		if (currentUser != null && currentUser.getShoppingCartA() != null) {
//
//			currentUser.getShoppingCartA().addProduct(product);
//			System.out.println(productName + " has been added to your personal shopping cart ");
//
//		} else {
//
//			System.out.println("User not logged in or Shopping Cart does not excist");
//
//		}

	}

	private void displayProductsInCart() {

		if (currentUser != null && currentUser.getShoppingCart() != null) {

			currentUser.getShoppingCart().viewProducts();

		} else {
			System.out.println("User is not logged in or Shopping Cart is not initialized. ");

		}

	}

}
