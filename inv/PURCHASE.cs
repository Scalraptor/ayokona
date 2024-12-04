using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INVENTORYSYSTEM_GROUP2
{
    public partial class PURCHASE : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lenovo\\source\\repos\\INVENTORYSYSTEM_GROUP2\\InventoryDB.mdf;Integrated Security=True";
        private string transactionId;

        public PURCHASE()
        {
            InitializeComponent();
        }

        private void PURCHASE_Load(object sender, EventArgs e)
        {
            GenerateNewTransactionId();
            LoadProductsToListView();

            // category ComboBox
            cb_category.Items.Add("ALL");
            cb_category.Items.Add("CPU");
            cb_category.Items.Add("GPU");
            cb_category.Items.Add("MOTHERBOARD");
            cb_category.Items.Add("RAM");

            // sort ComboBox
            cb_sort.Items.Add("ID");
            cb_sort.Items.Add("STOCK");
            cb_sort.Items.Add("PRODUCT NAME");
            cb_sort.Items.Add("PRICE");

            cb_category.SelectedIndex = 0;  
            cb_sort.SelectedIndex = 0;      

            cb_category.SelectedIndexChanged += cb_category_SelectedIndexChanged;
            cb_sort.SelectedIndexChanged += cb_sort_SelectedIndexChanged;
            btn_search.Click += btn_search_Click;

            // ListView 
            lv_products.View = View.Details;
            lv_products.FullRowSelect = true;
            lv_products.Columns.Add("ID", 50);
            lv_products.Columns.Add("Product Name", 150);
            lv_products.Columns.Add("Category", 100);
            lv_products.Columns.Add("Stock", 50);
            lv_products.Columns.Add("Price", 100);

            lv_products.SelectedIndexChanged += lv_products_SelectedIndexChanged;
            InitializeTransactionDataGridView();  

            dgv_transaction.DefaultCellStyle.Font = new Font("Perpetua Titling MT", 10.2f, FontStyle.Bold);
            dgv_transaction.SelectionChanged += dgv_transaction_SelectionChanged;
        }

        private void cb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cb_category.SelectedItem.ToString();
            LoadProductsToListView(selectedCategory);
        }

        private void cb_sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = cb_sort.SelectedItem.ToString();
            LoadProductsToListView(sortBy);  
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        private void GenerateNewTransactionId()
        {
            transactionId = Guid.NewGuid().ToString();
        }

        private void LoadProductsToListView(string filterCategory = "ALL", string sortBy = "ID", string searchTerm = "")
        {
            lv_products.Items.Clear();

            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT Id, Name, Category, Stock, Price FROM Products";

                    if (filterCategory != "ALL")
                    {
                        query += " WHERE Category = @Category";
                    }

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += string.IsNullOrEmpty(filterCategory) || filterCategory == "ALL"
                            ? " WHERE Name LIKE @SearchTerm"
                            : " AND Name LIKE @SearchTerm";
                    }

                    query += " ORDER BY " + sortBy;

                    SqlCommand command = new SqlCommand(query, connection);

                    if (filterCategory != "ALL")
                    {
                        command.Parameters.AddWithValue("@Category", filterCategory);
                    }

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    }

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["Id"].ToString());
                        item.SubItems.Add(reader["Name"].ToString());
                        item.SubItems.Add(reader["Category"].ToString());
                        item.SubItems.Add(reader["Stock"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(reader["Price"]).ToString("₱0.00"));
                        lv_products.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading products: {ex.Message}");
                }
            }
        }


        private int selectedProductId;

        private void lv_products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_products.SelectedItems.Count > 0)
            {
                var selectedItem = lv_products.SelectedItems[0];
                selectedProductId = int.Parse(selectedItem.SubItems[0].Text);
                tb_prodname.Text = selectedItem.SubItems[1].Text;
                textbox_category.Text = selectedItem.SubItems[2].Text;
                tb_price.Text = selectedItem.SubItems[4].Text; 
            }
            else
            {
                ClearInputs(); 
            }

            tb_units.Enabled = true; 

        }

        private void SetupTransactionDataGridView()
        {
            dgv_transaction.Columns.Add("ProductName", "Product Name");
            dgv_transaction.Columns.Add("Category", "Category");
            dgv_transaction.Columns.Add("Units", "Units");
            dgv_transaction.Columns.Add("Price", "Price");
            dgv_transaction.Columns.Add("TotalPrice", "Total Price");

        }

        private void ClearInputs()
        {
            tb_prodname.Text = string.Empty;
            textbox_category.Text = string.Empty;
            cb_category.SelectedIndex = 0; 
            tb_price.Text = string.Empty;
            tb_units.Text = string.Empty;
        }


        private void SaveTransactionToDatabase()
        {
            if (dgv_transaction.Rows.Count == 0)
            {
                MessageBox.Show("Please add products to the transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();

                    string transactionId = GenerateTransactionId(connection);

                    using (var sqlTransaction = connection.BeginTransaction())
                    {
                        try
                        {
                            foreach (DataGridViewRow row in dgv_transaction.Rows)
                            {
                                if (row.IsNewRow) continue;

                                int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                                int units = Convert.ToInt32(row.Cells["Units"].Value);
                                decimal totalPrice = Convert.ToDecimal(row.Cells["TotalPrice"].Value.ToString().Trim('₱').Replace(",", ""));

                                string insertTransactionQuery = @"
                            INSERT INTO Transactions (TransactionId, ProductId, Units, TotalPrice, TransactionDate)
                            VALUES (@TransactionId, @ProductId, @Units, @TotalPrice, @TransactionDate)";

                                using (var command = new SqlCommand(insertTransactionQuery, connection, sqlTransaction))
                                {
                                    command.Parameters.AddWithValue("@TransactionId", transactionId);
                                    command.Parameters.AddWithValue("@ProductId", productId);
                                    command.Parameters.AddWithValue("@Units", units);
                                    command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                                    command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                                    command.ExecuteNonQuery();
                                }

                                string updateStockQuery = "UPDATE Products SET Stock = Stock - @Units WHERE Id = @ProductId";
                                using (var updateCommand = new SqlCommand(updateStockQuery, connection, sqlTransaction))
                                {
                                    updateCommand.Parameters.AddWithValue("@Units", units);
                                    updateCommand.Parameters.AddWithValue("@ProductId", productId);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }

                            sqlTransaction.Commit();

                            MessageBox.Show("Transaction saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgv_transaction.Rows.Clear();
                            RecalculateGrandTotal();
                            ClearTransactionSummaryInputs();
                        }
                        catch (Exception ex)
                        {
                            sqlTransaction.Rollback();
                            MessageBox.Show($"Failed to save transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearTransactionSummaryInputs()
        {
            tb_grandtotal.Text = string.Empty;
            tb_amount.Text = string.Empty;
            tb_change.Text = string.Empty;
        }


        private string GenerateTransactionId(SqlConnection connection)
        {
            string transactionId;
            string query = "SELECT ISNULL(MAX(CAST(SUBSTRING(TransactionId, 2, LEN(TransactionId) - 1) AS INT)), 0) FROM Transactions";

            using (var command = new SqlCommand(query, connection))
            {
                int lastTransactionId = Convert.ToInt32(command.ExecuteScalar());
                transactionId = "T" + (lastTransactionId + 1).ToString("D4");
            }

            return transactionId;
        }


        private void btn_search_Click(object sender, EventArgs e)
        {
            string searchTerm = tb_search.Text.Trim();
            string selectedCategory = cb_category.SelectedItem.ToString();
            string sortBy = cb_sort.SelectedItem.ToString();

            LoadProductsToListView(selectedCategory, sortBy, searchTerm);  
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_prodname.Text) || string.IsNullOrEmpty(tb_units.Text) || string.IsNullOrEmpty(tb_price.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!int.TryParse(tb_units.Text, out int units) || units <= 0)
            {
                MessageBox.Show("Please enter a valid number of units greater than 0.");
                return;
            }

            if (!decimal.TryParse(tb_price.Text.Trim('₱'), out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            foreach (DataGridViewRow row in dgv_transaction.Rows)
            {
                if (row.IsNewRow) continue;

                if (Convert.ToInt32(row.Cells["ProductId"].Value) == selectedProductId)
                {
                    row.Cells["Units"].Value = units;
                    row.Cells["TotalPrice"].Value = (units * price).ToString("₱0.00");

                    RecalculateGrandTotal();
                    ClearInputs();
                    return;
                }
            }
            dgv_transaction.Rows.Add(
                selectedProductId,        
                tb_prodname.Text,           
                units,                     
                price.ToString("₱0.00"),   
                (units * price).ToString("₱0.00") 
            );

            RecalculateGrandTotal();
            ClearInputs();
        }

        private void RecalculateGrandTotal()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dgv_transaction.Rows)
            {
                if (row.IsNewRow) continue;

                totalAmount += decimal.Parse(row.Cells["TotalPrice"].Value.ToString().Trim('₱').Replace(",", ""));
            }

            tb_grandtotal.Text = "₱" + totalAmount.ToString("N2");

            decimal amountPaid = 0;
            if (decimal.TryParse(tb_amount.Text.Trim('₱').Replace(",", "").Trim(), out amountPaid))
            {
                UpdateChange(amountPaid, totalAmount);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)

        {
            if (dgv_transaction.SelectedRows.Count > 0)
            {
                dgv_transaction.Rows.RemoveAt(dgv_transaction.SelectedRows[0].Index);
                RecalculateGrandTotal();
            }
            else
            {
                MessageBox.Show("Please select a product to remove.");
            }
        }

        private void InitializeDataGridView()
        {
            dgv_transaction.Columns.Clear();

            dgv_transaction.Columns.Add("productName", "Product Name");
            dgv_transaction.Columns.Add("category", "Category");
            dgv_transaction.Columns.Add("stock", "Stock");
            dgv_transaction.Columns.Add("price", "Price");
            dgv_transaction.Columns.Add("totalPrice", "Total Price");

            dgv_transaction.Columns[0].Width = 200;
            dgv_transaction.Columns[1].Width = 150;
            dgv_transaction.Columns[2].Width = 80;
            dgv_transaction.Columns[3].Width = 150;
            dgv_transaction.Columns[4].Width = 150;
        }


        private void dgv_transaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeTransactionDataGridView()
        {
            dgv_transaction.Columns.Clear(); 

            dgv_transaction.Columns.Add("ProductId", "Product ID");    
            dgv_transaction.Columns.Add("ProductName", "Product Name");  
            dgv_transaction.Columns.Add("Units", "Units");               
            dgv_transaction.Columns.Add("Price", "Price");              
            dgv_transaction.Columns.Add("TotalPrice", "Total Price");    

            dgv_transaction.Columns["ProductId"].Visible = false;
        }


        private void tb_units_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_category_TextChanged(object sender, EventArgs e)
        {

        }

        private void lv_products_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tb_prodname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_increment_Click(object sender, EventArgs e)
        {
            int units;
            if (int.TryParse(tb_units.Text, out units))
            {
                int stock = 10;  

                if (units < stock)
                {
                    tb_units.Text = (units + 1).ToString();
                }
                else
                {
                    MessageBox.Show("You cannot exceed the available stock.");
                }
            }
            else
            {
                tb_units.Text = "1"; 
            }
        }

        private void btn_decrement_Click(object sender, EventArgs e)
        {
            int units;
            if (int.TryParse(tb_units.Text, out units))
            {
                if (units > 1)
                {
                    tb_units.Text = (units - 1).ToString();
                }
            }
            else
            {
                tb_units.Text = "1";
            }
        }



        private void tb_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cleanedAmount = tb_amount.Text.Trim('₱').Replace(",", "").Trim();

                decimal amountPaid;
                decimal grandTotal;

                bool isAmountValid = decimal.TryParse(cleanedAmount, out amountPaid);
                bool isGrandTotalValid = decimal.TryParse(tb_grandtotal.Text.Trim('₱').Replace(",", "").Trim(), out grandTotal);

                if (!isAmountValid)
                {
                    MessageBox.Show("Please enter a valid amount.");
                    return;
                }

                if (!isGrandTotalValid)
                {
                    MessageBox.Show("Grand total is not valid.");
                    return;
                }

                if (amountPaid < grandTotal)
                {
                    MessageBox.Show("Amount cannot be less than the Grand Total.");
                    tb_amount.Text = "₱" + grandTotal.ToString("N2");
                }
                else
                {
                    UpdateChange(amountPaid, grandTotal);
                }

                // Prevent the beep sound when Enter is pressed
                e.SuppressKeyPress = true;
            }
        }


        private void UpdateChange(decimal amountPaid, decimal grandTotal)
        {
            decimal change = amountPaid - grandTotal;
            tb_change.Text = "₱" + change.ToString("N2");
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            SaveTransactionToDatabase();
        }

        private void dgv_transaction_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_transaction.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_transaction.SelectedRows[0];

                if (selectedRow.Cells["ProductId"].Value != null)
                {
                    selectedProductId = Convert.ToInt32(selectedRow.Cells["ProductId"].Value);
                    tb_prodname.Text = selectedRow.Cells["ProductName"].Value.ToString();
                    tb_units.Text = selectedRow.Cells["Units"].Value.ToString();
                    tb_price.Text = selectedRow.Cells["Price"].Value.ToString();

                    tb_units.Enabled = true;
                }
            }
        }


    }
}