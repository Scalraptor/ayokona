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
    public partial class DASHBOARD : Form
    {
        private Database db;
        private string filter_category = "ALL";
        private string filter_sort = "Id";
        private bool isAsc = true;
        private string filter_search = "";


        public DASHBOARD()
        {
            InitializeComponent();
            db = new Database();
            LoadProductsToListView();
            UpdateStatistics(); // Update stats on load
        }
        private void UpdateStatistics(DateTime? startDate = null, DateTime? endDate = null)
        {
            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Query for Total Products (not date-dependent)
                    string totalProductsQuery = "SELECT SUM(Stock) AS TotalProducts FROM Products";
                    SqlCommand totalProductsCommand = new SqlCommand(totalProductsQuery, connection);
                    object totalProductsResult = totalProductsCommand.ExecuteScalar();
                    lblTotalProducts.Text = totalProductsResult != DBNull.Value ? totalProductsResult.ToString() : "0";

                    // Query for Total Sales (conditionally include date range)
                    string totalSalesQuery = "SELECT SUM(TotalPrice) AS TotalSales FROM Transactions";
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        totalSalesQuery += " WHERE TransactionDate >= @StartDate AND TransactionDate <= @EndDate";
                    }

                    SqlCommand totalSalesCommand = new SqlCommand(totalSalesQuery, connection);

                    // Add parameters only if the date range is specified
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        totalSalesCommand.Parameters.AddWithValue("@StartDate", startDate.Value);
                        totalSalesCommand.Parameters.AddWithValue("@EndDate", endDate.Value);
                    }

                    object totalSalesResult = totalSalesCommand.ExecuteScalar();
                    decimal totalSales = totalSalesResult != DBNull.Value ? Convert.ToDecimal(totalSalesResult) : 0;

                    // Display Total Sales as Percentage
                    decimal salesGoal = 1000000m; // Example goal
                    decimal salesPercentage = salesGoal > 0 ? (totalSales / salesGoal) * 100 : 0;
                    lblTotalSales.Text = $"{salesPercentage:F2}%";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating statistics: {ex.Message}");
                }
            }
        }



        private void LoadProductsToListView(string searchTerm = "")
        {
            lv_products.Items.Clear();

            using (var connection = db.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT Id, Name, Category, Stock, Status, Priority, Price 
                                     FROM Products";

                    if (filter_category != "ALL")
                    {
                        query += " WHERE Category = @Category";
                    }

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += filter_category != "ALL" ? " AND Name LIKE @SearchTerm" : " WHERE Name LIKE @SearchTerm";
                    }

                    query += $" ORDER BY {GetSortColumn()}";

                    query += isAsc ? " ASC" : " DESC";

                    SqlCommand command = new SqlCommand(query, connection);

                    if (filter_category != "ALL")
                        command.Parameters.AddWithValue("@Category", filter_category);

                    if (!string.IsNullOrEmpty(searchTerm))
                        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["Id"].ToString());
                        item.SubItems.Add(reader["Name"].ToString());
                        item.SubItems.Add(reader["Category"].ToString());
                        item.SubItems.Add(reader["Stock"].ToString());
                        item.SubItems.Add(reader["Status"].ToString());
                        item.SubItems.Add(reader["Priority"].ToString());
                        item.SubItems.Add("₱" + string.Format("{0:n2}", Convert.ToDecimal(reader["Price"])));
                        lv_products.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private string GetSortColumn()
        {
            switch (filter_sort)
            {
                case "ID": return "Id";
                case "PRODUCT NAME": return "Name";
                case "STOCK": return "Stock";
                case "PRICE": return "Price";
                default: return "Id";
            }
        }

        private void PopulateSortDropdown()
        {
            // Populate the dropdown for sorting options
            sort.Items.Clear();
            sort.Items.AddRange(new string[] { "ID", "PRODUCT NAME", "CATEGORY", "STOCK", "PRICE" });
            sort.SelectedIndex = 0; // Default selection
        }


        private void DASHBOARD_Load(object sender, EventArgs e)
        {
        }

        private void btn_search_Click_1(object sender, EventArgs e)
        {
            filter_search = Search.Text.Trim();
            LoadProductsToListView(filter_search);
        }

        private void btn_dsc_Click_1(object sender, EventArgs e)
        {
            isAsc = false;
            LoadProductsToListView(filter_search);
        }

        private void btn_asc_Click_1(object sender, EventArgs e)
        {
            isAsc = true;
            LoadProductsToListView(filter_search);
        }

        private void sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter_sort = sort.SelectedItem.ToString();
            LoadProductsToListView(filter_search);
        }

        private void viewCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter_category = viewCategory.SelectedItem.ToString();
            LoadProductsToListView(filter_search);
        }

        private void btn_daily_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            UpdateStatistics(today, today);
        }

        private void btn_weekly_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime weekStart = today.AddDays(-(int)today.DayOfWeek); // Start of the week (Sunday)
            UpdateStatistics(weekStart, today);
        }

        private void btn_monthly_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime monthStart = new DateTime(today.Year, today.Month, 1); // First day of the month
            UpdateStatistics(monthStart, today);
        }

        private void btn_yearly_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime yearStart = new DateTime(today.Year, 1, 1); // First day of the year
            UpdateStatistics(yearStart, today);
        }
    }
}
