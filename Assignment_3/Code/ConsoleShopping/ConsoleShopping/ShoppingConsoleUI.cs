using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleShopping
{
    /// <summary>
    /// The presentation class of the application.
    /// Handles the user interaction and display of menus on the console.
    /// </summary>
    class ShoppingConsoleUI
    {
        #region Private data members
        private Shopping shopping;
        private static string separator = new string('-', 79);
        #endregion
        #region Constructors
        public ShoppingConsoleUI()
        {
            shopping = new Shopping();
        }
        #endregion
        #region Public methods
        public void Start()
        {
            int mainMenuInput = -1;
            shopping.Initialize();
            Console.WriteLine("--!!Welcome to Shopping Application!!--");
            do
            {
                do
                {
                    DisplayMainMenu();
                    Console.WriteLine("Enter your choice (1 - 4)");
                    mainMenuInput = GetUserInput();
                } while ((mainMenuInput < 1) || (mainMenuInput > 4));
                switch (mainMenuInput)
                {
                    case 1:
                        ShowAvailableItems();
                        break;
                    case 2:
                        CreateNewOrder();
                        break;
                    case 3:
                        GenerateInvoice();
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            } while (mainMenuInput != 4);
        }
        #endregion
        #region Private methods
        private void ShowAvailableItems()
        {
            string displayFormat = "{0,10} | {1, -40} | {2, 6}";
            Console.WriteLine(separator);
            Console.WriteLine(displayFormat, "Product Id", "Product Name", "Price");
            Console.WriteLine(separator);
            ShoppingItem[] availableItems = shopping.GetAvailableItems();
            foreach (ShoppingItem shoppingItem in availableItems)
            {
                Console.WriteLine(displayFormat, shoppingItem.ItemNo, shoppingItem.ItemName, shoppingItem.ItemPrice);
            }
            Console.WriteLine(separator);
        }

        private void CreateNewOrder()
        {
            Console.WriteLine(separator);
            Console.WriteLine("---- Beginning new order ----");
            shopping.InitiateNewOrder();
            ShoppingItem[] shoppingItems = shopping.GetAvailableItems();
            int orderMenuInput = -1;
            do
            {
                DisplayOrderMenu();
                Console.WriteLine("Enter your choice (1 - 2)");
                orderMenuInput = GetUserInput();
                if (orderMenuInput == 1)
                {
                    int productIdInput = -1;
                    bool itemFound = false;
                    ShoppingItem selectedShoppingItem = null;
                    do
                    {
                        Console.WriteLine("Enter Product Id");
                        productIdInput = GetUserInput();
                        var selectedItems = from item in shoppingItems
                                           where item.ItemNo == productIdInput
                                           select item;
                        itemFound = (selectedItems != null && selectedItems.Count<ShoppingItem>() > 0);
                        selectedShoppingItem = selectedItems.ToList<ShoppingItem>()[0];
                    } while (!itemFound);
                    
                    int prodOrderQty = -1;
                    do
                    {
                        Console.WriteLine("Enter order quantity for {0}", selectedShoppingItem.ItemName);
                        prodOrderQty = GetUserInput();
                    } while ((prodOrderQty < 1) && (prodOrderQty > 100));
                    shopping.AddToShoppingCart(selectedShoppingItem, prodOrderQty);
                }
            } while (orderMenuInput != 2);
        }

        private void DisplayOrderMenu()
        {
            Console.WriteLine(separator);
            Console.WriteLine("----Order Menu----");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Finish order");
        }

        private void GenerateInvoice()
        {
            Invoice invoiceForOrder = shopping.GetInvoice();
            string displayFormat = "{0,10} | {1, -30} | {2, 6} | {3, 8} | {4, 8}";
            Console.WriteLine(separator);
            Console.WriteLine(displayFormat, new object[] { "Product Id", "Product Name", "Price", "Quantity", "Amount"});
            Console.WriteLine(separator);
            IEnumerator<InvoiceItem> invoiceEnumerator = invoiceForOrder.GetEnumerator();
            while (invoiceEnumerator.MoveNext())
            {
                Console.WriteLine(displayFormat, new object[] { 
                    invoiceEnumerator.Current.ItemNo, 
                    invoiceEnumerator.Current.ItemName, 
                    invoiceEnumerator.Current.ItemPrice, 
                    invoiceEnumerator.Current.Quantity, 
                    invoiceEnumerator.Current.InvoiceItemPrice });
            }
            Console.WriteLine(separator);
            Console.WriteLine("{0, 70}", invoiceForOrder.InvoiceValue);
        }

        private int GetUserInput()
        {
            int userInput = -1;
            string userInputStr = null;
            bool isInvalidInput = false;
            do
            {
                if (isInvalidInput)
                {
                    Console.WriteLine("Please enter a valid option");
                }
                userInputStr = Console.ReadLine();
                isInvalidInput = (!int.TryParse(userInputStr, out userInput)) || (userInput < 0);
            }
            while (isInvalidInput);
            return userInput;
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine(separator);
            Console.WriteLine("----Main Menu----");
            Console.WriteLine("1. Show available items");
            Console.WriteLine("2. Create new order");
            Console.WriteLine("3. Generate invoice");
            Console.WriteLine("4. Exit");
        }
        #endregion
    }
}
