using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace INVENTORYSYSTEM_GROUP2
{
    public partial class SALES : Form
    {
        private Database db;

        public SALES()
        {
            InitializeComponent();
            db = new Database();
            LoadTransactionsToListView(); 
            cbTRANSSORT.SelectedIndex = -1; 
            LoadProductsToComboBox();
            LoadProductsToComboBox(); // Load products into ComboBox when the form is loaded
            LoadTransactionsToListView();
        }

        private void LoadTransactionsToListView()
        {
            lvINVOICE.Items.Clear(); // Clear existing data in ListView

            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    t.TransactionId AS [ID],
                    COUNT(t.ProductId) AS [NoOfProducts],
                    SUM(t.Units) AS [TotalUnits],
                    SUM(t.TotalPrice) AS [TotalAmountPaid],
                    t.TransactionDate AS [DatePurchased]
                FROM Transactions t
                GROUP BY t.TransactionId, t.TransactionDate
                ORDER BY t.TransactionId";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    bool dataAvailable = false;
                    while (reader.Read())
                    {
                        dataAvailable = true;
                        var item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["NoOfProducts"].ToString());
                        item.SubItems.Add(reader["TotalUnits"].ToString());
                        item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["TotalAmountPaid"])));
                        item.SubItems.Add(Convert.ToDateTime(reader["DatePurchased"]).ToString("yyyy-MM-dd"));
                        lvINVOICE.Items.Add(item);
                    }
                    // If no data found, the ListView will remain empty, and no message is shown.
                    if (!dataAvailable)
                    {
                        lvINVOICE.Items.Clear(); // Clear the ListView if no data is found
                    }
                }
            }
            catch (Exception)
            {
                // Catch any errors without showing a message box
                lvINVOICE.Items.Clear(); // Clear the ListView if there is an error
            }
        }

        private string sortColumn = "t.TransactionId"; 
        private bool isAscending = true; 

        private void cbTRANSSORT_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (cbTRANSSORT.SelectedItem.ToString())
            {
                case "ALL":
                    sortColumn = "t.TransactionId"; 
                    break;
                case "NO. OF PRODUCT":
                    sortColumn = "COUNT(t.ProductId)";
                    break;
                case "UNITS":
                    sortColumn = "SUM(t.Units)";
                    break;
                case "AMOUNT PAID":
                    sortColumn = "SUM(t.TotalPrice)";
                    break;
                case "DATE PURCHASED":
                    sortColumn = "t.TransactionDate";
                    break;
                default:
                    sortColumn = "t.TransactionId"; 
                    break;
            }
            
            LoadTransactionsToListView();
        }

        private void btn_asc_invoice_Click(object sender, EventArgs e)
        {
            isAscending = true; 
            LoadTransactionsToListView();
        }

        private void btn_dsc_invoice_Click(object sender, EventArgs e)
        {
            isAscending = false;
            LoadTransactionsToListView();
        }

        private void LoadProductsToComboBox()
        {
            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Id, Name FROM Products ORDER BY Name";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    cbPRODUCT.Items.Clear(); // Clear existing items in the ComboBox
                    // Add the default choice and the "ALL" option
                    cbPRODUCT.Items.Add("SELECT A PRODUCT TO SEARCH"); // Default item
                    cbPRODUCT.Items.Add("ALL"); // Option to show all products

                    if (!reader.HasRows)
                    {
                        // If no rows are found, leave the ComboBox empty
                        cbPRODUCT.Text = string.Empty; // Clear any displayed text
                        return;
                    }
                    // Add products to the ComboBox
                    while (reader.Read())
                    {
                        cbPRODUCT.Items.Add(reader["Name"].ToString());
                    }

                    cbPRODUCT.SelectedIndex = 0; // Set the default item as the first option
                }
            }
            catch
            {               
                cbPRODUCT.Items.Clear(); // In case of error, clear ComboBox and leave it empty
                cbPRODUCT.Text = string.Empty; // Clear any displayed text
            }
        }

        private void LoadTransactionsForProduct(string productName)
        {
            lvINVOICE.Items.Clear(); // Clear existing data in ListView

            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    t.TransactionId AS [ID],
                    COUNT(t.ProductId) AS [NoOfProducts],
                    SUM(t.Units) AS [TotalUnits],
                    SUM(t.TotalPrice) AS [TotalAmountPaid],
                    t.TransactionDate AS [DatePurchased]
                FROM Transactions t
                INNER JOIN Products p ON t.ProductId = p.Id
                WHERE p.Name = @ProductName
                GROUP BY t.TransactionId, t.TransactionDate
                ORDER BY t.TransactionId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.HasRows)
                    {                       
                        return; // If no transactions found, leave ListView empty
                    }

                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["NoOfProducts"].ToString());
                        item.SubItems.Add(reader["TotalUnits"].ToString());
                        item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["TotalAmountPaid"])));
                        item.SubItems.Add(Convert.ToDateTime(reader["DatePurchased"]).ToString("yyyy-MM-dd"));
                        lvINVOICE.Items.Add(item);
                    }
                }
            }
            catch
            {               
                lvINVOICE.Items.Clear(); // If an error occurs, clear the ListView and leave it empty
            }
        }

        private void LoadTransactionsByProduct(string productName)
        {
            lvINVOICE.Items.Clear(); 

            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                  
                    string query = @"
                SELECT 
                    t.TransactionId AS [ID],
                    COUNT(t.ProductId) AS [NoOfProducts],
                    SUM(t.Units) AS [TotalUnits],
                    SUM(t.TotalPrice) AS [TotalAmountPaid],
                    t.TransactionDate AS [DatePurchased]
                FROM Transactions t
                INNER JOIN Products p ON t.ProductId = p.Id
                WHERE p.Name = @ProductName
                GROUP BY t.TransactionId, t.TransactionDate
                ORDER BY t.TransactionId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName", productName);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["NoOfProducts"].ToString());
                        item.SubItems.Add(reader["TotalUnits"].ToString());
                        item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["TotalAmountPaid"])));
                        item.SubItems.Add(Convert.ToDateTime(reader["DatePurchased"]).ToString("yyyy-MM-dd"));
                        lvINVOICE.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transactions for product: {ex.Message}");
            }
        }

        private void LoadAllTransactions()
        {
            lvINVOICE.Items.Clear(); // Clear existing data in ListView

            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    t.TransactionId AS [ID],
                    COUNT(t.ProductId) AS [NoOfProducts],
                    SUM(t.Units) AS [TotalUnits],
                    SUM(t.TotalPrice) AS [TotalAmountPaid],
                    t.TransactionDate AS [DatePurchased]
                FROM Transactions t
                GROUP BY t.TransactionId, t.TransactionDate
                ORDER BY t.TransactionId";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.HasRows)
                    {                       
                        return; // If no transactions found, leave ListView empty
                    }

                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["NoOfProducts"].ToString());
                        item.SubItems.Add(reader["TotalUnits"].ToString());
                        item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["TotalAmountPaid"])));
                        item.SubItems.Add(Convert.ToDateTime(reader["DatePurchased"]).ToString("yyyy-MM-dd"));
                        lvINVOICE.Items.Add(item);
                    }
                }
            }
            catch
            {                
                lvINVOICE.Items.Clear(); // If an error occurs, clear the ListView and leave it empty
            }
        }

        private void cbPRODUCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = cbPRODUCT.SelectedItem.ToString();

            // If the user selects the default "SELECT A PRODUCT TO SEARCH" option, do nothing
            if (selectedProduct == "SELECT A PRODUCT TO SEARCH")
            {
                LoadAllTransactions(); // Method to load all transactions
                return;
            }
            // If "ALL" is selected, load all transactions
            if (selectedProduct == "ALL")
            {
                LoadAllTransactions(); // Method to load all transactions
                return;
            }
            // Otherwise, load transactions for the selected product
            LoadTransactionsForProduct(selectedProduct);
        }
   
        private void lvINVOICE_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lvINVOICE.SelectedItems.Count > 0)
            {

                string transactionId = lvINVOICE.SelectedItems[0].SubItems[0].Text;


                lblTRANSNUMBER.Text = "Transaction ID: " + transactionId;


                LoadProductsForTransaction(Convert.ToInt32(transactionId));
            }
        }
        // Query and load products for the selected transactionId
        private void LoadProductsForTransaction(int transactionId)
        {
            // Clear existing items in lvTRANSACTION
            lvTRANSACTION.Items.Clear();

            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    // Query to get the product details for the selected transactionId
                    string query = @"
                SELECT 
                    p.Name AS PRNAME, 
                    p.Category AS CATEGORY, 
                    t.Units AS UNITS, 
                    t.Price AS PRICE, 
                    t.TotalPrice AS TOTALPRICE
                FROM Transactions t
                INNER JOIN Products p ON t.ProductId = p.Id
                WHERE t.TransactionId = @TransactionId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TransactionId", transactionId);

                    SqlDataReader reader = command.ExecuteReader();

                    bool hasData = false;

                    while (reader.Read())
                    {
                        hasData = true;
                        var item = new ListViewItem(reader["PRNAME"].ToString());
                        item.SubItems.Add(reader["CATEGORY"].ToString());
                        item.SubItems.Add(reader["UNITS"].ToString());
                        item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["PRICE"])));
                        item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["TOTALPRICE"])));
                        lvTRANSACTION.Items.Add(item);
                    }
                    // If no data found, just leave the ListView empty
                    if (!hasData)
                    {
                        // The ListView remains empty without showing a message box
                        // Just clear it to ensure it's empty
                        lvTRANSACTION.Items.Clear();
                    }
                }
            }
            catch (Exception ex)
            {               
                lvTRANSACTION.Items.Clear(); // In case of an error, ensure ListView is empty without showing a message box
                Console.WriteLine($"Error loading products for transaction: {ex.Message}");  // Optionally log the error
            }
        }

        private void lblTRANSNUMBER_Click(object sender, EventArgs e)
        {

        }

        private void lvTRANSACTION_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadTransactionsSorted(string column)
        {
            string sortOrder = cbPRODUCTSORT.Text == "SORT" ? "ASC" : "DESC";
            lvTRANSACTION.Items.Clear(); // Clear any previous items in the ListView

            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    // Query to sort transactions based on the selected column (UNITS, PRICE, or TOTALPRICE)
                    string query = @"
                SELECT p.Name AS [PRNAME], 
                       p.Category AS [CATEGORY], 
                       t.Units AS [UNITS], 
                       t.Price AS [PRICE], 
                       t.TotalPrice AS [TOTALPRICE]
                FROM Transactions t
                INNER JOIN Products p ON t.ProductId = p.Id
                ORDER BY t." + column + " " + sortOrder;

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    bool dataAvailable = false;
                    while (reader.Read())
                    {
                        dataAvailable = true;
                        var item = new ListViewItem(reader["PRNAME"].ToString());
                        item.SubItems.Add(reader["CATEGORY"].ToString());
                        item.SubItems.Add(reader["UNITS"].ToString());
                        item.SubItems.Add(reader["PRICE"].ToString());
                        item.SubItems.Add(reader["TOTALPRICE"].ToString());
                        lvTRANSACTION.Items.Add(item);
                    }
                    // If no data found, the ListView will remain empty
                    if (!dataAvailable)
                    {
                        lvTRANSACTION.Items.Clear(); // Clear the ListView if no data is found
                    }
                }
            }
            catch (Exception) // Catch any errors without showing a message box
            {                
                lvTRANSACTION.Items.Clear(); // Clear the ListView if there is an error
            }
        }

        private void cbPRODUCTSORT_SelectedIndexChanged(object sender, EventArgs e)
        {         
            string sortOption = cbPRODUCTSORT.SelectedItem.ToString();
           
            if (sortOption == "ALL")
            {
                LoadTransactionsSortedByProductId("ASC"); 
            }
            else if (sortOption == "UNITS")
            {
                LoadTransactionsSorted("UNITS");
            }
            else if (sortOption == "PRICE")
            {
                LoadTransactionsSorted("PRICE");
            }
            else if (sortOption == "TOTAL PRICE")
            {
                LoadTransactionsSorted("TOTALPRICE");
            }
        }
        private void LoadTransactionsSortedByProductId(string sortOrder)
        {
            lvTRANSACTION.Items.Clear(); 
            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    
                    string query = @"
                SELECT p.Name AS [PRNAME], 
                       p.Category AS [CATEGORY], 
                       t.Units AS [UNITS], 
                       t.Price AS [PRICE], 
                       t.TotalPrice AS [TOTALPRICE]
                FROM Transactions t
                INNER JOIN Products p ON t.ProductId = p.Id
                ORDER BY t.ProductId " + sortOrder;

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["PRNAME"].ToString());
                        item.SubItems.Add(reader["CATEGORY"].ToString());
                        item.SubItems.Add(reader["UNITS"].ToString());
                        item.SubItems.Add(reader["PRICE"].ToString());
                        item.SubItems.Add(reader["TOTALPRICE"].ToString());
                        lvTRANSACTION.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transactions: {ex.Message}");
            }
        }

        private void btn_asc_trans_Click(object sender, EventArgs e)
        {
            string sortOption = cbPRODUCTSORT.SelectedItem.ToString();
            string sortOrder = "ASC";
           
            if (sortOption == "UNITS")
            {
                LoadTransactionsSorted("UNITS");
            }
            else if (sortOption == "PRICE")
            {
                LoadTransactionsSorted("PRICE");
            }
            else if (sortOption == "TOTAL PRICE")
            {
                LoadTransactionsSorted("TOTALPRICE");
            }
            else
            {
                LoadTransactionsSortedByProductId(sortOrder); 
            }
        }

        private void btn_dsc_trans_Click(object sender, EventArgs e)
        {
            string sortOption = cbPRODUCTSORT.SelectedItem.ToString();
            string sortOrder = "DESC";
         
            if (sortOption == "UNITS")
            {
                LoadTransactionsSorted("UNITS");
            }
            else if (sortOption == "PRICE")
            {
                LoadTransactionsSorted("PRICE");
            }
            else if (sortOption == "TOTAL PRICE")
            {
                LoadTransactionsSorted("TOTALPRICE");
            }
            else
            {
                LoadTransactionsSortedByProductId(sortOrder);
            }
        }

        private void SALES_Load(object sender, EventArgs e)
        {
            cbPRODUCT.Text = "SELECT A PRODUCT TO SEARCH";
            LoadProductsToComboBox();

            cbPRODUCTSORT.Text = "SORT";

            LoadTransactionsSortedByProductId("ASC");

            cbCATEGORY.Text = "CATEGORY";
            cbPERIOD.Text = "PERIOD";

            dtpDATE1.Value = DateTime.Now;
            dtpDATE2.Value = DateTime.Now;
        }

        private void lvPRODUCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPRODUCT.Items.Clear(); // Clear existing items in the ListView
            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    // Query to get product details along with the total units sold and total amount
                    string query = @"
                SELECT p.Id AS [ID], 
                       p.Name AS [PRONAME], 
                       p.Category AS [CATEGORY], 
                       ISNULL(SUM(t.Units), 0) AS [SOLD], 
                       ISNULL(SUM(t.Units * p.Price), 0) AS [TOTALAMOUNT], 
                       p.Priority AS [PRIORITY]
                FROM Products p
                LEFT JOIN Transactions t ON p.Id = t.ProductId
                GROUP BY p.Id, p.Name, p.Category, p.Priority
                ORDER BY p.Id";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    // Check if there is data
                    if (!reader.HasRows)
                    {
                        // No data found, leave the ListView empty
                        return;
                    }
                    // Process the data and populate the ListView
                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["PRONAME"].ToString());
                        item.SubItems.Add(reader["CATEGORY"].ToString());
                        item.SubItems.Add(reader["SOLD"].ToString());
                        item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["TOTALAMOUNT"])));
                        item.SubItems.Add(reader["PRIORITY"].ToString()); // Placeholder for future use
                        lvPRODUCT.Items.Add(item);
                    }
                }
            }
            catch (Exception ex) // If there's an error, clear the ListView and don't show any message box
            {               
                lvPRODUCT.Items.Clear();
            }
        }

        private void LoadAllProducts()
        {
            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    // Query to load all products
                    string query = @"
                SELECT p.Id AS [ID], 
                       p.Name AS [PRONAME], 
                       p.Category AS [CATEGORY], 
                       ISNULL(SUM(t.Units), 0) AS [SOLD], 
                       ISNULL(SUM(t.Units * p.Price), 0) AS [TOTALAMOUNT], 
                       p.Priority AS [PRIORITY]
                FROM Products p
                LEFT JOIN Transactions t ON p.Id = t.ProductId
                GROUP BY p.Id, p.Name, p.Category, p.Priority
                ORDER BY p.Id";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    bool dataFound = false; // Flag to track if any data is found

                    while (reader.Read())
                    {
                        dataFound = true; // Data found for all products
                        var item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["PRONAME"].ToString());
                        item.SubItems.Add(reader["CATEGORY"].ToString());
                        item.SubItems.Add(reader["SOLD"].ToString());
                        item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["TOTALAMOUNT"])));
                        item.SubItems.Add(reader["PRIORITY"].ToString()); // Placeholder for future use
                        lvPRODUCT.Items.Add(item);
                    }

                    // If no data was found, leave ListView empty without showing a message
                    if (!dataFound)
                    {
                        lvPRODUCT.Items.Clear(); // Optionally clear the ListView if no data found
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error but don't show a message box
                // Optionally log the error or handle it silently
            }
        }

        private void cbCATEGORY_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the ListView before adding new data
            lvPRODUCT.Items.Clear();

            // Get the selected category from the ComboBox
            string selectedCategory = cbCATEGORY.SelectedItem.ToString();

            // If "ALL" is selected, show all products
            if (selectedCategory == "ALL")
            {
                LoadAllProducts(); // A method to load all products (without category filter)
            }
            else
            {
                try
                {
                    using (var connection = db.GetConnection())
                    {
                        connection.Open();

                        // Query to filter products by the selected category
                        string query = @"
                    SELECT p.Id AS [ID], 
                           p.Name AS [PRONAME], 
                           p.Category AS [CATEGORY], 
                           ISNULL(SUM(t.Units), 0) AS [SOLD], 
                           ISNULL(SUM(t.Units * p.Price), 0) AS [TOTALAMOUNT], 
                           p.Priority AS [PRIORITY]
                    FROM Products p
                    LEFT JOIN Transactions t ON p.Id = t.ProductId
                    WHERE p.Category = @Category
                    GROUP BY p.Id, p.Name, p.Category, p.Priority
                    ORDER BY p.Id";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Category", selectedCategory);
                        SqlDataReader reader = command.ExecuteReader();

                        bool dataFound = false; // Flag to track if any data is found

                        while (reader.Read())
                        {
                            dataFound = true; // Data found for the selected category
                            var item = new ListViewItem(reader["ID"].ToString());
                            item.SubItems.Add(reader["PRONAME"].ToString());
                            item.SubItems.Add(reader["CATEGORY"].ToString());
                            item.SubItems.Add(reader["SOLD"].ToString());
                            item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["TOTALAMOUNT"])));
                            item.SubItems.Add(reader["PRIORITY"].ToString()); // Placeholder for future use
                            lvPRODUCT.Items.Add(item);
                        }

                        // If no data was found, leave ListView empty without showing a message
                        if (!dataFound)
                        {
                            // Optionally, you can clear the ListView to ensure it's empty if no data found
                            lvPRODUCT.Items.Clear();
                        }
                    }
                }
                catch (Exception ex) // Handle error but don't show a message box
                {
                    // You can optionally log the error or handle it silently
                }
            }
        }

        private DateTime GetStartDate(string period)
        {
            switch (period)
            {
                case "WEEKLY":
                    return DateTime.Today.AddDays(-7); 
                case "MONTHLY":
                    return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); 
                case "ANNUALLY":
                    return new DateTime(DateTime.Today.Year, 1, 1); 
                default:
                    return DateTime.Today; 
            }
        }

        private string GetSqlDateDiff(string period)
        {
            switch (period)
            {
                case "WEEKLY":
                    return "week";
                case "MONTHLY":
                    return "month";
                case "ANNUALLY":
                    return "year";
                default:
                    return "day"; 
            }
        }

        private void LoadSalesData(string query)
        {
            lvPRODUCT.Items.Clear();
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["ProductID"].ToString());
                        item.SubItems.Add(reader["ProductName"].ToString());
                        item.SubItems.Add(reader["Category"].ToString());
                        item.SubItems.Add(reader["TotalUnitsSold"].ToString());

                        int totalUnitsSold = Convert.ToInt32(reader["TotalUnitsSold"]);
                        int datePeriod = Convert.ToInt32(reader["DatePeriod"]);
                        if (datePeriod > 0)
                        {
                            item.SubItems.Add((totalUnitsSold / datePeriod).ToString());
                        }
                        else
                        {
                            item.SubItems.Add("0");
                        }

                        lvPRODUCT.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading sales data: {ex.Message}");
                }
            }
        }

        private void cbPERIOD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string period = cbPERIOD.Text;
            string query = "";
       
            if (period == "DAILY")
            {
                query = @"
            SELECT 
                p.Id AS ProductID,
                p.Name AS ProductName,
                p.Category AS Category,
                SUM(t.Units) AS TotalUnitsSold
            FROM Transactions t
            JOIN Products p ON t.ProductId = p.Id
            GROUP BY p.Id, p.Name, p.Category
            ORDER BY p.Id";
            }
            
            else if (period == "WEEKLY" || period == "MONTHLY" || period == "ANNUALLY")
            {
                
                DateTime startDate = GetStartDate(period);
                DateTime endDate = DateTime.Today; 

                
                query = @"
            SELECT 
                p.Id AS ProductID,
                p.Name AS ProductName,
                p.Category AS Category,
                SUM(t.Units) AS TotalUnitsSold,
                DATEDIFF(" + GetSqlDateDiff(period) + @", '" + startDate.ToString("yyyy-MM-dd") + @"', '" + endDate.ToString("yyyy-MM-dd") + @"') AS DatePeriod
            FROM Transactions t
            JOIN Products p ON t.ProductId = p.Id
            WHERE t.TransactionDate BETWEEN '" + startDate.ToString("yyyy-MM-dd") + @"' AND '" + endDate.ToString("yyyy-MM-dd") + @"'
            GROUP BY p.Id, p.Name, p.Category
            ORDER BY p.Id";
            }

            
            LoadSalesData(query);
        }

        private void ValidateAndFetchTransactions()
        {
            DateTime date1 = dtpDATE1.Value.Date;
            DateTime date2 = dtpDATE2.Value.Date;

            if (date1 > date2)
            {
                // Show error message
                MessageBox.Show("Start date cannot be later than the end date. Resetting to the current date.",
                                "Invalid Date Range",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Reset DateTimePickers to current date
                dtpDATE1.Value = DateTime.Now;
                dtpDATE2.Value = DateTime.Now;

                return;
            }

            // Fetch transactions for the valid date range
            LoadTransactionsForDateRange(date1, date2);
        }

        private void LoadTransactionsForDateRange(DateTime startDate, DateTime endDate)
        {
            lvINVOICE.Items.Clear(); // Clear previous items

            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    t.TransactionId AS [ID],
                    COUNT(t.ProductId) AS [NoOfProducts],
                    SUM(t.Units) AS [TotalUnits],
                    SUM(t.TotalPrice) AS [TotalAmountPaid],
                    t.TransactionDate AS [DatePurchased]
                FROM Transactions t
                WHERE t.TransactionDate BETWEEN @StartDate AND @EndDate
                GROUP BY t.TransactionId, t.TransactionDate
                ORDER BY t.TransactionId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["NoOfProducts"].ToString());
                        item.SubItems.Add(reader["TotalUnits"].ToString());
                        item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["TotalAmountPaid"])));
                        item.SubItems.Add(Convert.ToDateTime(reader["DatePurchased"]).ToString("yyyy-MM-dd"));
                        lvINVOICE.Items.Add(item);
                    }

                    // No need for additional messages; an empty ListView will suffice.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transactions: {ex.Message}");
            }
        }

        private void dtpDATE1_ValueChanged(object sender, EventArgs e)
        {
            ValidateAndFetchTransactions();
        }

        private void dtpDATE2_ValueChanged(object sender, EventArgs e)
        {
            ValidateAndFetchTransactions();
        } 
    }
}