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
    public partial class Display_data : System.Web.UI.Page
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

        // ✅ Load Data Method to Fetch and Display Data in GridView
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, LastName, Email, Dob, CreatedDate FROM Everything", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}