using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class ConsoleUserInterface
    {

        private Warehouse warehouse = new Warehouse();
        private Shoppingcart shoppingcart;
        private User currentUser;

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
            Console.WriteLine("7. Exit");
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
            Console.WriteLine("1. iPhone 15 Pro MAX 512 GB");
            Console.WriteLine("2. HP laptop i9 32 RAM 1 TB SSD");
            Console.WriteLine("3. JP laptop i9 32 RAM 1 TB SSD");
            Console.WriteLine("4. GP laptop i9 32 RAM 1 TB SSD");


        }


        private void AddProductToCart()
        {


            Console.WriteLine("Enter product number to add to cart: ");
            int productNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter amount: ");
            int amount = int.Parse(Console.ReadLine());

            Product sampleProduct = new Product("Sample Product", "This is a sample product", 15.75, amount);
            shoppingcart.AddProductToShoppingcart(sampleProduct, amount);

            Console.WriteLine($"{amount} of {sampleProduct.Name} added to cart.");



        }



        private void ViewCart()
        {



            Console.WriteLine("Your Shoppingcart:");
            double total = shoppingcart.CalculateTotalPrice();
            Console.WriteLine($"Total Price: ${total}");


        }


        private void WriteReview()
        {


            if (currentUser == null)
            {


                Console.WriteLine("Please login or register first.");
                return;

            }


            Console.WriteLine("Enter product number to review: ");
            int productNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your review: ");
            string reviewText = Console.ReadLine();

            Console.WriteLine("Enter your rating (1-5): ");
            int rating = int.Parse(Console.ReadLine());

            Product sampleProduct = new Product("Sample Product", "dummy data", 19.35, 5);
            Review newReview = new Review(currentUser, sampleProduct, reviewText, rating);

            Console.WriteLine("Review submitted");







        }



        private void ViewReviews()
        {

            Console.WriteLine("Reviews for sample dummy product:");
            Console.WriteLine("User A: Good product - 5/5");
            Console.WriteLine("User B: Not what I expected. - 2/5");
            Console.WriteLine("User C: Good product, but breaks fast. - 3/5");




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


                currentUser = new User(username);
                Console.WriteLine($"Logged in as {username}.");

            }

            else if (option == 2)
            {

                Console.Write("Enter a new username: ");
                string newUsername = Console.ReadLine();

                currentUser = new User(newUsername);
                Console.WriteLine($"Registered and logged in as {newUsername}.");

            }


        }



    }
}

