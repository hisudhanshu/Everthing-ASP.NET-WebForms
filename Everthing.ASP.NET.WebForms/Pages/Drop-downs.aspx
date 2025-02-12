<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Drop-downs.aspx.cs" Inherits="Everthing.ASP.NET.WebForms.Pages.Drop_downs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Cascading dropdowns</h3>

    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
        <asp:ListItem Text="--Select Country--" Value="0"></asp:ListItem>
    </asp:DropDownList>

    <asp:DropDownList ID="ddlCapital" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCapital_SelectedIndexChanged">
        <asp:ListItem Text="--Select Capital--" Value="0"></asp:ListItem>
    </asp:DropDownList>

    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
        <asp:ListItem Text="--Select State--" Value="0"></asp:ListItem>
    </asp:DropDownList>

    <asp:DropDownList ID="ddlCity" runat="server">
        <asp:ListItem Text="--Select City--" Value="0"></asp:ListItem>
    </asp:DropDownList>

</asp:Content>
