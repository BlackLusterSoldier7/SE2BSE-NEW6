package presentationLayer;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import DTO.UserDTO;

import logicDomainLayer.Order;
import logicDomainLayer.Product;
import logicDomainLayer.SeasonalDiscount;
import logicDomainLayer.Shoppingcart;
import logicDomainLayer.User;

public class ConsoleUserInterface {

	private User currentUser;
	private Scanner scanner;

	private ArrayList<Product> products = new ArrayList<>(); // een lijst waar je alle producten in kunt opslaan.

	// scanner attribute of class WebshopConsoleaAppl is initialized
	// no null. no nullpointerexception more

	public ConsoleUserInterface() {

		this.scanner = new Scanner(System.in);

		currentUser = new User(new UserDTO("Burak", "E"), null);

	}

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		System.out.println("BOL.COM webshop");

		ConsoleUserInterface app = new ConsoleUserInterface();
		app.run();

	}

	public void displayProductDetails(Product product) {
		System.out.println("Product: " + product.getName() + ", Price: " + product.getPrice() + ", Description: "
				+ product.getDescription());
	}

	private void run() {

		// Product flatDiscountProduct = new Product("iPhone 13", 800, new
		// FlatDiscount(30));
		// Product seasonalDiscountProduct = new Product("Winter cap", 150, new
		// SeasonalDiscount(25)); //25% discount

		SeasonalDiscount seasonalDiscount = new SeasonalDiscount(20);

		int numberExit = 10;

		// test line burak local git folder?

		while (numberExit != 0) {

			printMenu();

			int userInput = scanner.nextInt();
			numberExit = userInput;
			scanner.nextLine();

			switch (userInput) {

			case 1:

				viewProducts();

				break;
			case 2:
				if (currentUser != null) {

					// currentUser.viewSearchHistory();

				} else {
					System.out.println("Logg in to see view search history");
				}
				break;

			case 3:

				placeOrder();
				break;

			case 4:

				addProductToCart();
				break;

			case 5:

				displayProductsInCart();
				break;

			case 0:

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
		System.out.println("1. View Products");
		System.out.println("2. View Search History");
		System.out.println("3. Place an Order");
		System.out.println("4. Add Product to ShoppingCart");
		System.out.println("5. Display Products in Shopping Cart");

		System.out.println("0. Exit");
		System.out.print("Enter number: ");

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

		Shoppingcart cart = currentUser.getShoppingCart();

		Order order = cart.convertToOrder();
		currentUser.addOrder(order);
		System.out.println("Order placed successfully ");

	}

	private void addProductToCart() {

		System.out.println("------");
		System.out.println("Enter product name: ");
		String productName = scanner.nextLine();

		System.out.print("Enter product price: ");
		double productPrice = scanner.nextDouble();

	}

	private void displayProductsInCart() {

		currentUser.getShoppingCart().getProducts();

	}

}
