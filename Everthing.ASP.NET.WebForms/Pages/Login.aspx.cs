using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.Configuration;

namespace Everthing.ASP.NET.WebForms.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            // ✅ Connection String from Web.config
            string connString = WebConfigurationManager.ConnectionStrings["database_aspwebforms"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); // Use hashing in real-world applications

                    conn.Open();
                    object role = cmd.ExecuteScalar();

                    if (role != null)
                    {
                        string userRole = role.ToString();
                        Session["Username"] = username;
                        Session["Role"] = userRole;

                        if (userRole == "Admin")
                        {
                            Response.Redirect("AdminDashboard.aspx");
                        }
                        else if (userRole == "Staff")
                        {
                            Response.Redirect("StaffDashboard.aspx");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid username or password');</script>");
                    }
                }
            }
        }
    }
}
