<%@ Page Title="Aldi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aldi.aspx.cs" Inherits="EinkaufslisteV2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2><%: Title %>.</h2>
        
                <%-- Alle Produkte anzeigen, gefiltert nach Markt und sortiert nach Produktstandort --%>
                
                <div class="einkaufMarkt">
                    <asp:GridView ID="EinkaufslisteAldi" runat="server" ></asp:GridView>
                </div>

                <asp:Label ID="ausgabe" runat="server" CssClass="error"></asp:Label>
</asp:Content>
