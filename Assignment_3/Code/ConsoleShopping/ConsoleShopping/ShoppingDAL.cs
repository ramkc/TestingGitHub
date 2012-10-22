using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ConsoleShopping
{
    /// <summary>
    /// The data access class for the application.
    /// Handles the database interactions requested by the business logic class
    /// </summary>
    class ShoppingDAL
    {
        #region Private data members
        private DbProviderFactory dbProviderFactory;
        private bool availableItemsRetrieved;
        private List<ShoppingItem> availableItems;
        #endregion
        #region Constructors
        public ShoppingDAL()
        {
            availableItemsRetrieved = false;
            availableItems = new List<ShoppingItem>();
        }
        #endregion
        #region Private methods
        private DbConnection getConnection()
        {
            if (dbProviderFactory == null)
            {
                dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            }
            DbConnection dbConnection = dbProviderFactory.CreateConnection();
            dbConnection.ConnectionString = ConfigurationManager.ConnectionStrings["SqlExpressConnString"].ConnectionString;
            return dbConnection;
        }
        #endregion
        #region Public methods
        public void Initialize()
        {
        }
        public ShoppingItem[] GetAvailableItems()
        {
            if (!availableItemsRetrieved)
            {
                using (DbConnection connection = getConnection())
                {
                    connection.Open();
                    DbCommand selectCommand = dbProviderFactory.CreateCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM ShoppingItems";
                    selectCommand.CommandType = System.Data.CommandType.Text;
                    using (DbDataAdapter daSelectAllRows = dbProviderFactory.CreateDataAdapter())
                    {
                        daSelectAllRows.SelectCommand = selectCommand;
                        using (DataSet selectDataset = new DataSet())
                        {
                            daSelectAllRows.Fill(selectDataset, "ShoppingItems");
                            connection.Close();
                            if (selectDataset.Tables["ShoppingItems"].Rows.Count > 0)
                            {
                                DataRowCollection dataRows = selectDataset.Tables["ShoppingItems"].Rows;
                                foreach (DataRow dataRow in dataRows)
                                {
                                    int itemNo = (int) dataRow["ItemId"];
                                    string itemName = dataRow["ItemName"].ToString();
                                    int itemPrice = (int) dataRow["Price"];
                                    availableItems.Add(new ShoppingItem(itemNo, itemName, itemPrice));
                                }
                            }
                            selectDataset.Dispose();
                        }
                    }
                }
                availableItemsRetrieved = true;
            }
            return availableItems.ToArray<ShoppingItem>();
        }
        public int PersistInvoice(Invoice invoice)
        {
            int rowsInserted = 0;
            using (DbConnection connection = getConnection())
            {
                connection.Open();
                DbCommand insertCommand = dbProviderFactory.CreateCommand();
                insertCommand.Connection = connection;
                insertCommand.CommandText = "INSERT INTO InvoiceData(InvoiceValue) VALUES (@InvoiceValue)";
                DbParameter paramInvoiceValue = dbProviderFactory.CreateParameter();
                paramInvoiceValue.DbType = DbType.Int32;
                paramInvoiceValue.ParameterName = "@InvoiceValue";
                paramInvoiceValue.Value = invoice.InvoiceValue;
                insertCommand.Parameters.Add(paramInvoiceValue);
                rowsInserted = insertCommand.ExecuteNonQuery();
                connection.Close();
            }
            return rowsInserted;
        }
        #endregion
    }
}
