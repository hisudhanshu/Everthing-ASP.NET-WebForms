<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Display_data.aspx.cs" Inherits="Everthing.ASP.NET.WebForms.Pages.Display_data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Display All Inserted Data</h2>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" BorderColor="Black" BorderWidth="1px" Width="100%">
        </asp:GridView>
    </div>
</asp:Content>
