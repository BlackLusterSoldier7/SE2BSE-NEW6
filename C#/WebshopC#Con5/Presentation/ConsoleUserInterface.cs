using Domain;
using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class ConsoleUserInterface
    {

        private Warehouse warehouse = new Warehouse();
        private Shoppingcart shoppingcart;
        private User currentUser;
        private ProductRepository productRepository = new ProductRepository();
        private UserRepository userRepository = new UserRepository();






        public static void Main(string[] args)
        {

            ConsoleUserInterface consoleUserInterface = new ConsoleUserInterface();

            consoleUserInterface.RunShop();

        }


        public ConsoleUserInterface()
        {
            shoppingcart = new Shoppingcart(warehouse);
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
            Console.WriteLine("8. Exit");
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
                return 0;
            }
            return choice;



        }


        private void DisplayProducts()
        {

            Console.WriteLine("Products:");

            List<ProductDTO> products = productRepository.GetAllProducts();
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - ${products[i].Price}");

            }


        }


        private void AddProductToCart()
        {
            Console.Write("Enter product number to add to cart: ");
            int productNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter amount: ");
            int amount = int.Parse(Console.ReadLine());

            List<ProductDTO> products = productRepository.GetAllProducts();

            if (productNumber <= 0 || productNumber > products.Count)
            {
                Console.WriteLine("Invalid product number. ");
                return;
            }

            ProductDTO selectedProductDTO = products[productNumber - 1];
            Product selectedProduct = new Product(selectedProductDTO.Name, selectedProductDTO.Description,
                selectedProductDTO.Price, selectedProductDTO.Category);
            shoppingcart.AddProductToShoppingcart(selectedProduct, amount);

            Console.WriteLine($"{amount} {selectedProduct.Name}(s) added to shoppingcart. ");

        }




        private void ViewCart()
        {

            Console.WriteLine("Your Shoppingcart:");

            var cartItems = shoppingcart.ViewProducts();

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


            List<ProductDTO> products = productRepository.GetAllProducts();
            if (productNumber <= 0 || productNumber > products.Count)
            {
                Console.WriteLine("Invalid product number.");
                return;
            }

            ProductDTO selectedProductDTO = products[productNumber - 1];

            ReviewDTO newReview = new ReviewDTO
            {

                Comment = reviewText,
                Rating = rating

            };

            selectedProductDTO.Reviews.Add(newReview);
            productRepository.UpdateProduct(selectedProductDTO.Name, selectedProductDTO); // Update the product in the repository 

            Console.WriteLine("Review added successfully!");


        }






        private void ViewReviews()
        {


            Console.WriteLine("Enter product number to view reviews: ");
            int productNumber = int.Parse(Console.ReadLine());

            List<ProductDTO> products = productRepository.GetAllProducts();

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


                List<UserDTO> users = userRepository.GetAllUsers();
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
                    currentUser = new User(userDTO.Username, shoppingcart);
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

                currentUser = new User(newUsername, shoppingcart);
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

            Order order = new Order();
            PaymentService paymentService = new PaymentService(shoppingcart);
            PaymentResultDTO paymentResult = paymentService.DoPayment(order);


            if (paymentResult.Success)
            {
                Console.WriteLine(paymentResult.Message);
                Console.WriteLine("Total amount paid: eur" + paymentResult.AmountPaid);
            }
            else
            {
                Console.WriteLine(paymentResult.Message);
            }





        }




    }
}

