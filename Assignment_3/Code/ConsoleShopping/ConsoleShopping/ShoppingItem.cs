using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConsoleShopping
{
    /// <summary>
    /// The basic encapsulation of an item available for sale.
    /// It encapsulates the product id, product name and unit price.
    /// </summary>
    class ShoppingItem : IEqualityComparer<ShoppingItem>
    {
        #region Constructors
        public ShoppingItem()
        {
            ItemNo = 0;
            ItemName = string.Empty;
            ItemPrice = 0;
        }
        public ShoppingItem(int itemNo, string itemName, int itemPrice)
        {
            ItemNo = itemNo;
            ItemName = itemName;
            ItemPrice = itemPrice;
        }
        #endregion
        #region Public properties
        public int ItemNo { get; private set; }
        public string ItemName { get; private set; }
        public int ItemPrice { get; private set; }
        #endregion
        #region IEqualityComparer<ShoppingItem> implementation
        public bool Equals(ShoppingItem x, ShoppingItem y)
        {
            return (x.ItemNo == y.ItemNo);
        }

        public int GetHashCode(ShoppingItem obj)
        {
            return obj.ItemNo;
        }
        #endregion
    }
}
