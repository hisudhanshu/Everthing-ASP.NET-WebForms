using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Everthing.ASP.NET.WebForms.Pages
{
    public partial class Display_data_from_view : System.Web.UI.Page
    {
        // ✅ Connection String from Web.config
        string connString = WebConfigurationManager.ConnectionStrings["database_aspwebforms"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
     private void LoadData()
        {
            // Define the connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["database_aspwebforms"].ToString();

            // Create SQL query to get data from DataView
            string query = "SELECT * FROM DataView";

            // Create a connection and command object
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                // Fill the data table with the query result
                da.Fill(dt);

                // Bind the data to the GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}