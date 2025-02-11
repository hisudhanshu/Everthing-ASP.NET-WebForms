using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Everthing.ASP.NET.WebForms.Pages
{
    public partial class Insert_data : System.Web.UI.Page
    {
        // ✅ Connection String Web.config
        string connString = WebConfigurationManager.ConnectionStrings["database_aspwebforms"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initial loading logic if any (not needed here)
            }
        }

        // ✅ Insert Data Method
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Everything (Name, LastName, Email, Dob) VALUES (@Name, @LastName, @Email, @Dob)", conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Dob", string.IsNullOrEmpty(txtDob.Text) ? (object)DBNull.Value : Convert.ToDateTime(txtDob.Text)); // Handle DBNull for empty date fields

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Data Inserted Successfully!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error occurred!');</script>");
                }
            }
        }
    }
}
