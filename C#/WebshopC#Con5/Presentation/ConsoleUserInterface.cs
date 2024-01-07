using Domain;
using Infrastructure;
using Domain.DTO;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class ConsoleUserInterface
    {
        private readonly IWarehouse warehouse;
        private readonly IProductRepository productRepository;
        private User currentUser;

        private UserRepository userRepository;
        private ProductService productService;
        private UserService userService;



        private List<IDiscount> availableDiscounts;
        private List<IDiscount> selectedDiscounts;

        private PaymentService paymentService; 


        public static void Main(string[] args)
        {

            Warehouse warehouse = new Warehouse();
            ProductRepository productRepository = new ProductRepository();
            UserRepository userRepository = new UserRepository();
            PaymentService paymentService = new PaymentService(); 

            ConsoleUserInterface consoleUserInterface = new ConsoleUserInterface(warehouse, productRepository, userRepository, paymentService);
            consoleUserInterface.RunShop();
        }

        public ConsoleUserInterface(IWarehouse warehouse, IProductRepository productRepository, IUserRepository userRepository, PaymentService paymentService)
        {
            this.productRepository = productRepository;

            this.productService = new ProductService(productRepository);
            this.userService = new UserService(userRepository);
            this.warehouse = warehouse;

            this.paymentService = paymentService; 

            var shoppingCart = new Shoppingcart(warehouse);

            availableDiscounts = new List<IDiscount>
            {
                new QuantityDiscount(4,5),
                new ChristmasDiscount(3),
                new GrouponCodeDiscount(2, "GroupC")
            };

            selectedDiscounts = new List<IDiscount>();

        }

        public void RunShop()
        {
            while (true)
            {
                ShowMenu();

                int choice = GetChoiceFromUser();

                switch (choice)
                {
                    case 1:
                        DisplayProducts();
                        break;
                    case 2:
                        AddProductToCart();
                        break;
                    case 3:
                        ViewCart();
                        break;
                    case 4:
                        WriteReview();
                        break;
                    case 5:
                        ViewReviews();
                        break;
                    case 6:
                        LoginOrRegister();
                        break;
                    case 7:
                        HandlePayment();
                        break;
                    case 8:
                        SortProductsByPriceLowToHighAscending();
                        break;
                    case 9:
                        SortedProductsByPriceDescendingOrderFromHighToLow();
                        break;
                    case 10:
                        DisplaySearchHistoryRecommendations();
                        break;
                    case 11:
                        SearchForProducts();
                        break;
                    case 12:
                        ChooseDiscounts();
                        break;
                    case 14:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("Welcome to the Webshop Menu: ");
            Console.WriteLine("1. Display products");
            Console.WriteLine("2. Add Product to Shoppingcart");
            Console.WriteLine("3. View Shoppingcart");
            Console.WriteLine("4. Write a Review");
            Console.WriteLine("5. View Reviews for a Product");
            Console.WriteLine("6. Login/Register");
            Console.WriteLine("7. Make a Payment");
            Console.WriteLine("8. BubbleSort Low To High Prices Ascending");
            Console.WriteLine("9. BubbleSort Product Prices Descending Order From High To Low");
            Console.WriteLine("10. View Search History Recommendations");
            Console.WriteLine("11. Search For Products");
            Console.WriteLine("12. ChooseDiscounts");
            Console.WriteLine("14. Exit");
            Console.WriteLine("Enter your choice: ");
        }
        private int GetChoiceFromUser()
        {
            string userInput = Console.ReadLine();
            int choice;

            bool isValidNumber = int.TryParse(userInput, out choice);

            if (!isValidNumber)
            {
                Console.WriteLine("Please enter a valid number. ");
            }
            return choice;
        }

        private void DisplayProducts()
        {
            Console.WriteLine("Products:");

            // for each loop doen 
            // warehouse repo aanmaken en die gebruiken 
            // iterator onderzoeken voor GetAllProducts. Miljoenen database products 
            // iterator is complex niet maken alleen onderzoek doen. Alleen als je tijd hebt 

            // List<ProductDTO> products = productRepository.GetAllProducts(); dit mag dus niet naar infrastructure layer reference

            List<ProductDTO> products = productService.GetAllProducts();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - ${products[i].Price}");
            }
        }

        private void SortProductsByPriceLowToHighAscending()
        {
            Console.WriteLine("Sorting products by price");

            // Get the list of products from productService 
            List<ProductDTO> products = productService.GetAllProducts();

            // Create a Category object 
            Category category = new Category("Electronics", "All availe electronic products");

            // Call the BubbleSort method to sort the products 
            category.BubbleSortLowToHighPricesAscending(products);

            // Display the sorted products 
            DisplaySortedProductsLowToHighAscending(products);
        }

        private void DisplaySortedProductsLowToHighAscending(List<ProductDTO> products)
        {
            Console.WriteLine("Sorted Products by Price: ");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - ${products[i].Price}");
            }
        }

        private void SortedProductsByPriceDescendingOrderFromHighToLow()
        {
            Console.WriteLine("Sorting products by price");

            // Get the list of products from productService 
            List<ProductDTO> products = productService.GetAllProducts();

            // Create a Category object 
            Category category = new Category("Electronics", "All availble electronics");

            // Call the BubbleSort method to sort the products 
            category.BubbleSortProductPricesDescendingOrderFromHighToLow(products);

            // Display the sorted products 
            DisplaySortedProductsDescendingOrderFromHighToLow(products);
        }

        private void DisplaySortedProductsDescendingOrderFromHighToLow(List<ProductDTO> products)
        {
            Console.WriteLine("Sorted Products by Price: ");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - ${products[i].Price}");
            }
        }

        private void SearchForProducts()
        {
            Console.Write("Enter your search query please: ");
            string searchQuery = Console.ReadLine().ToLower();

            // Capture the search query in the user's search history 
            currentUser.SearchHistory.Add(searchQuery);
        }

        // product lijst doorlopen uitprinten if contains. 
        // to do 
        // naam naar lowercase omzetten voordat je verlijkt. 

        private void DisplaySearchHistoryRecommendations()
        {
            if (currentUser == null)
            {
                Console.WriteLine("Please login or register first.");
                return;
            }

            List<ProductDTO> recommendations = productService.GetSearchHistoryRecommendations(currentUser);

            if (recommendations.Count == 0)
            {
                Console.WriteLine("No search history recommendations available. ");
                return;
            }

            Console.WriteLine("Search History Recommendations:");

            for (int i = 0; i < recommendations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recommendations[i].Name} - ${recommendations[i].Price}");
            }
        }

        private void AddProductToCart()
        {
            Console.Write("Enter product number to add to cart: ");
            int productNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter amount: ");
            int amount = int.Parse(Console.ReadLine());

            // List<ProductDTO> products = productRepository.GetAllProducts(); dit mag niet 

            List<ProductDTO> products = productService.GetAllProducts();

            if (productNumber <= 0 || productNumber > products.Count)
            {
                Console.WriteLine("Invalid product number. ");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater or equal to 1 ");
                return;
            }

            ProductDTO selectedProductDTO = products[productNumber - 1];
            Product selectedProduct = new Product(selectedProductDTO.Name, selectedProductDTO.Description,
                selectedProductDTO.Price, selectedProductDTO.Category);

            currentUser.shoppingCart.AddProductToShoppingcart(selectedProduct, amount);

            Console.WriteLine($"{amount} {selectedProduct.Name}(s) added to shoppingcart. ");

        }

        private void ViewCart()
        {
            Console.WriteLine("Your Shoppingcart:");

            var cartItems = currentUser.shoppingCart.ViewProducts();

            foreach (var item in cartItems)
            {
                Console.WriteLine($"{item.Product.Name} - ${item.Product.Price} x {item.Amount} = ${item.Product.Price * item.Amount} ");
            }
        }

        private void WriteReview()
        {
            if (currentUser == null)
            {
                Console.WriteLine("Please login or register first.");
                return;
            }

            DisplayProducts();
            Console.Write("Enter product number to review: ");
            int productNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter your review: ");
            string reviewText = Console.ReadLine();

            Console.Write("Enter your rating (1-5): ");
            int rating = int.Parse(Console.ReadLine());

            // List<ProductDTO> products = productRepository.GetAllProducts();

            List<ProductDTO> products = productService.GetAllProducts();

            if (productNumber <= 0 || productNumber > products.Count)
            {
                Console.WriteLine("Invalid product number.");
                return;
            }

            // rating ook checken 

            ProductDTO selectedProductDTO = products[productNumber - 1];

            ReviewDTO newReview = new ReviewDTO
            {
                Comment = reviewText,
                Rating = rating
            };

            selectedProductDTO.Reviews.Add(newReview);

            Console.WriteLine("Review added successfully!");
        }

        private void ViewReviews()
        {
            Console.WriteLine("Enter product number to view reviews: ");
            int productNumber = int.Parse(Console.ReadLine());

            // List<ProductDTO> products = productRepository.GetAllProducts();
            List<ProductDTO> products = productService.GetAllProducts();

            if (productNumber <= 0 || productNumber > products.Count)
            {
                Console.WriteLine("Invalid product number.");
                return;
            }

            ProductDTO selectedProductDTO = products[productNumber - 1];
            Console.WriteLine($"Reviews for {selectedProductDTO.Name}:");

            if (selectedProductDTO.Reviews.Count == 0)
            {
                Console.WriteLine("No reviews available for this product.");
                return;
            }

            foreach (ReviewDTO review in selectedProductDTO.Reviews)
            {
                Console.WriteLine($"{review.Comment} - {review.Rating}/5");
            }
        }

        private void LoginOrRegister()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.Write("Choose option: ");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                //List<UserDTO> users = userRepository.GetAllUsers();

                List<UserDTO> users = userService.GetAllUsers();

                UserDTO userDTO = null;

                foreach (UserDTO u in users)
                {
                    if (u.Username == username)
                    {
                        userDTO = u;
                        break;
                    }
                }

                if (userDTO != null)
                {
                    currentUser = new User(userDTO.Username, warehouse);
                    Console.WriteLine($"Logged in as {username}.");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter a new username: ");
                string newUsername = Console.ReadLine();

                currentUser = new User(newUsername, warehouse);
                Console.WriteLine($"Registered and logged in as {newUsername}.");
            }
            else
            {
                Console.WriteLine("Invalid option. ");
            }
        }

        private void HandlePayment()
        {
            if (currentUser == null)
            {
                Console.WriteLine("Please login or register before making a payment.");
                return;
            }

          

            Bill bill = paymentService.CheckOut(currentUser.shoppingCart, selectedDiscounts);

            Console.WriteLine($"Total before discount: EUR {bill.Total:.2f}");
            Console.WriteLine($"Total discount: EUR {bill.Discount:.2f}");
            Console.WriteLine($"Total after discount: EUR {bill.Total - bill.Discount:.2f}");

            selectedDiscounts.Clear();
        }

        private void ChooseDiscounts()
        {
            Console.WriteLine("Available Discounts: ");

            for (int i = 0; i < availableDiscounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableDiscounts[i].GetType().Name}");
            }

            Console.WriteLine("Select a discount to apply (0 for none): ");
            int choice = int.Parse(Console.ReadLine());

            if (choice > 0 && choice <= availableDiscounts.Count)
            {
                selectedDiscounts.Add(availableDiscounts[choice - 1]);
                Console.WriteLine("Discount applied. ");
            }
            EnterGrouponCode();
        }

        private void EnterGrouponCode()
        {
            Console.Write("Enter your Groupon code (leave blank if none): ");
            string grouponCode = Console.ReadLine();

            currentUser.shoppingCart.CouponCode = grouponCode;
            GrouponCodeDiscount grouponDiscount = null;

            foreach (var discount in availableDiscounts)
            {
                // Binnen de loop wordt gecontroleerd of de huidige korting van
                // het type GrouponCodeDiscount is door gebruik te maken van is keyword.
                // Als dit waar is, wordt de korting naar een GrouponCodeDiscount object 
                // gecast en wordt deze aan de grouponDiscountItem variabele toegewezen. 

                if (discount is GrouponCodeDiscount grouponDiscountItem)
                {
                    // Vervolgens roept het de methode IsValidCode aan op het 
                    // grouponDiscountItem object, waarbij de grouponCode als argument 
                    // wordt doorgegeven. Van deze methode wordt verwacht dat deze valideert
                    // of de ingevoerde Groupon code geldig is voor de huidige korting. 

                    if (grouponDiscountItem.IsValidCode(grouponCode))
                    {
                        // Als de methode IsValidCode true return, betekent dit dat de 
                        // ingevoerde Groupon code geldig is voor de huidige korting. In 
                        // dit geval wijst het de grouponDiscountItem toe aan de grouponDiscount 
                        // variabele en wordt de loop verlaten. 

                        grouponDiscount = grouponDiscountItem;
                        break;
                    }
                }
            }

            if (grouponDiscount != null)
            {
                selectedDiscounts.Add(grouponDiscount);
                Console.WriteLine("Groupon code applied successfully.");
            }
            else if (!string.IsNullOrWhiteSpace(grouponCode))
            {
                Console.WriteLine("Invalid Groupon code.");
            }
        }
    }
}