using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleShopping
{
    /// <summary>
    /// The business logic class of the application.
    /// Contains the logic for the shopping functionalities. 
    /// The UI interacts with this class, and this class in turn accesses the data access class
    /// </summary>
    class Shopping
    {
        #region Private data members
        private Dictionary<ShoppingItem, int> shoppingCart;
        private ShoppingDAL shoppingDAL;
        #endregion
        #region Constructors
        public Shopping()
        {
            shoppingCart = new Dictionary<ShoppingItem, int>(new ShoppingItem());
            shoppingDAL = new ShoppingDAL();
        }
        #endregion
        #region Public methods
        public void Initialize()
        {
            shoppingDAL.Initialize();
        }
        public ShoppingItem[] GetAvailableItems()
        {
            return shoppingDAL.GetAvailableItems();
        }
        public void AddToShoppingCart(ShoppingItem shoppingItem, int quantity)
        {
            if (shoppingCart.ContainsKey(shoppingItem))
            {
                shoppingCart[shoppingItem] += quantity;
            }
            else
            {
                shoppingCart.Add(shoppingItem, quantity);
            }
        }
        public void InitiateNewOrder()
        {
            shoppingCart.Clear();
        }
        public Invoice GetInvoice()
        {
            List<InvoiceItem> invoiceList = new List<InvoiceItem>();
            foreach (KeyValuePair<ShoppingItem, int> invoiceItem in shoppingCart)
            {
                invoiceList.Add(new InvoiceItem(invoiceItem.Key, invoiceItem.Value));
            }
            Invoice invoiceForShoppingCart = new Invoice(invoiceList);
            shoppingDAL.PersistInvoice(invoiceForShoppingCart);
            InitiateNewOrder();
            return (invoiceForShoppingCart);
        }
        #endregion
    }
}
