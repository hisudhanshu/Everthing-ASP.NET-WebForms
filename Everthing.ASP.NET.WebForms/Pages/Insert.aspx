<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="Everthing.ASP.NET.WebForms.Pages.Insert_data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="form1" runat="server">
        <div>
            <h2>Insert Data into Database</h2>

            <asp:Label runat="server" Text="First Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
            <br />

            <asp:Label runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />

            <asp:Label runat="server" Text="Dob:"></asp:Label>
            <asp:TextBox ID="txtDob" TextMode="Date" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
            <br />
            <br />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
        </div>
    </div>
</asp:Content>
