using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleShopping
{
    class InvoiceItem : ShoppingItem
    {
        public InvoiceItem(ShoppingItem shoppingItem, int quantity) : base (shoppingItem.ItemNo, shoppingItem.ItemName, shoppingItem.ItemPrice)
        {
            Quantity = quantity;
        }
        public int Quantity { get; private set; }
        public int InvoiceItemPrice
        {
            get
            {
                return (ItemPrice * Quantity);
            }
        }
    }
}
