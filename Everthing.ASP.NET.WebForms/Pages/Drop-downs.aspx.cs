using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Everthing.ASP.NET.WebForms.Pages
{
    public partial class Drop_downs : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["database_aspwebforms"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountryDropdown();
            }
        }

        private void BindCountryDropdown()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT CountryId, CountryName FROM Country", con))
                {
                    con.Open();
                    ddlCountry.DataSource = cmd.ExecuteReader();
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "CountryId";
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));
                }
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCapital.Items.Clear();
            ddlCapital.Items.Insert(0, new ListItem("--Select Capital--", "0"));
            ddlState.Items.Clear();
            ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));

            if (ddlCountry.SelectedValue != "0")
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT CapitalId, CapitalName FROM Capital WHERE CountryId = @CountryId", con))
                    {
                        cmd.Parameters.AddWithValue("@CountryId", ddlCountry.SelectedValue);
                        con.Open();
                        ddlCapital.DataSource = cmd.ExecuteReader();
                        ddlCapital.DataTextField = "CapitalName";
                        ddlCapital.DataValueField = "CapitalId";
                        ddlCapital.DataBind();
                        ddlCapital.Items.Insert(0, new ListItem("--Select Capital--", "0"));
                    }
                }
            }
        }

        protected void ddlCapital_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlState.Items.Clear();
            ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));

            if (ddlCapital.SelectedValue != "0")
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT StateId, StateName FROM State WHERE CapitalId = @CapitalId", con))
                    {
                        cmd.Parameters.AddWithValue("@CapitalId", ddlCapital.SelectedValue);
                        con.Open();
                        ddlState.DataSource = cmd.ExecuteReader();
                        ddlState.DataTextField = "StateName";
                        ddlState.DataValueField = "StateId";
                        ddlState.DataBind();
                        ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
                    }
                }
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));

            if (ddlState.SelectedValue != "0")
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT CityId, CityName FROM City WHERE StateId = @StateId", con))
                    {
                        cmd.Parameters.AddWithValue("@StateId", ddlState.SelectedValue);
                        con.Open();
                        ddlCity.DataSource = cmd.ExecuteReader();
                        ddlCity.DataTextField = "CityName";
                        ddlCity.DataValueField = "CityId";
                        ddlCity.DataBind();
                        ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));
                    }
                }
            }
        }
    }
}
