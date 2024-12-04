using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace INVENTORYSYSTEM_GROUP2
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lenovo\\source\\repos\\INVENTORYSYSTEM_GROUP2\\InventoryDB.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            changedate.ValueChanged += Changedate_ValueChanged; // Event handler for DateTimePicker
            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged; // Event handler for ListView selection change
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTransactions(); // Load data from the database into the ListView
        }

        private void LoadTransactions()
        {
            listView1.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                    SELECT 
                        t.Id, 
                        t.TransactionId, 
                        p.Name AS ProductName, 
                        t.Units, 
                        t.TotalPrice, 
                        t.TransactionDate
                    FROM Transactions t
                    INNER JOIN Products p ON t.ProductId = p.Id
                    ORDER BY t.Id";

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Id"].ToString());
                        item.SubItems.Add(reader["TransactionId"].ToString());
                        item.SubItems.Add(reader["ProductName"].ToString());
                        item.SubItems.Add(reader["Units"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(reader["TotalPrice"]).ToString("₱0.00"));
                        item.SubItems.Add(Convert.ToDateTime(reader["TransactionDate"]).ToString("yyyy-MM-dd"));

                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Changedate_ValueChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) // Check if a row is selected
            {
                var selectedItem = listView1.SelectedItems[0];
                int transactionId = int.Parse(selectedItem.Text); // Assumes the first column is the transaction ID

                UpdateTransactionDate(transactionId, changedate.Value);
            }
            else
            {
                MessageBox.Show("Please select a transaction to update the date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateTransactionDate(int transactionId, DateTime newDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Transactions SET TransactionDate = @TransactionDate WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionDate", newDate);
                        command.Parameters.AddWithValue("@Id", transactionId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Transaction date updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadTransactions(); // Reload the data in the ListView
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Please check the selected transaction.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating transaction date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                string selectedId = selectedItem.Text; // First column (ID)
                label2.Text = $"Selected ID: {selectedId}";
            }
            else
            {
                label2.Text = "Selected ID: None";
            }
        }
    }
}
