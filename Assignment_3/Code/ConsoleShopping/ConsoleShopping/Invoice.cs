using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleShopping
{
    /// <summary>
    /// Invoice is a collection of Shopping Items and calculates the value for each product and also the 
    /// grand total value of the invoice.
    /// It exposes an enumerator for outside classes to get information about the invoice line items, while
    /// protecting the data from external changes.
    /// </summary>
    class Invoice : IEnumerator<InvoiceItem>, IEnumerable<InvoiceItem>
    {
        #region Private data members
        private int invoiceItemIndex;
        private List<InvoiceItem> shoppingCart;
        private int invoiceValue;
        #endregion
        #region Constructors
        public Invoice(List<InvoiceItem> shoppingCart)
        {
            invoiceItemIndex = -1;
            this.shoppingCart = shoppingCart;
            if ((shoppingCart != null) && (shoppingCart.Count > 0))
            {
                foreach (InvoiceItem invoiceItem in shoppingCart)
                {
                    invoiceValue += invoiceItem.InvoiceItemPrice;
                }
            }
        }
        #endregion
        #region Public properties
        public int InvoiceValue
        {
            get
            {
                return invoiceValue;
            }
        }
        #endregion
        #region IEnumerator implementation
        public InvoiceItem Current
        {
            get { return shoppingCart[invoiceItemIndex]; }
        }
        public void Dispose()
        {
        }
        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }
        public bool MoveNext()
        {
            invoiceItemIndex++;
            return (invoiceItemIndex < shoppingCart.Count);
        }
        public void Reset()
        {
            invoiceItemIndex = -1;
        }
        #endregion
        #region IEnumerable implementation
        public IEnumerator<InvoiceItem> GetEnumerator()
        {
            return (this as IEnumerator<InvoiceItem>);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
