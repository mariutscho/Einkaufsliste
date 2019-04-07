<%@ Page Title="Produkt hinzufügen" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Eingabe.aspx.cs" Inherits="EinkaufslisteV2.NeuesProdukt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="form-group">
        <asp:Label ID="LblProdukt" runat="server" Text="Produkt" AssociatedControlID="Produkt"></asp:Label>
        <asp:TextBox ID="Produkt" runat="server" Text="" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="MarktLbl" runat="server" Text="Markt" AssociatedControlID="Markt"></asp:Label>
        <asp:RadioButtonList ID="Markt" runat="server"></asp:RadioButtonList>
    </div>
    <div class="form-group">
        <asp:Label ID="LblProduktkategorie" runat="server" Text="Produktkategorie" AssociatedControlID="Kategorie"></asp:Label>
        <asp:DropDownList ID="Kategorie" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
     <div class="form-group">
        <asp:Button ID="Speichern" runat="server" Text="Speichern" CssClass="btn btn-default" OnClick="AddProdukt" />
    </div>
    <asp:Label ID="Ausgabe" runat="server"></asp:Label>
    <asp:HiddenField ID="produktanzahl" runat="server" />
</asp:Content>
