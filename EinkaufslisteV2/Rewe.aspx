<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rewe.aspx.cs" Inherits="EinkaufslisteV2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
            <div class="einkaufMarkt">
                    <asp:GridView ID="EinkaufslisteRewe" runat="server" ></asp:GridView>
                </div>

                <asp:Label ID="ausgabe" runat="server" CssClass="error"></asp:Label>
</asp:Content>
