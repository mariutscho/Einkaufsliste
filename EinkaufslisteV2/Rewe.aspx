<%@ Page Title="REWE" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rewe.aspx.cs" Inherits="EinkaufslisteV2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
            <div class="einkaufMarkt">
                    <asp:GridView ID="EinkaufslisteRewe" runat="server" ></asp:GridView>
                </div>
                <div class="btn-group" data-toggle="buttons">
                <asp:Panel ID="Einkaufsliste" runat="server"></asp:Panel>
                 </div>
         <div class="row">
            <asp:Button ID="DeleteItem" runat="server" Text="Eingekaufte Produkte entfernen" OnClick="ClearWarenkorb" CssClass="btn btn-default" />
        </div>
                 <asp:Label ID="ausgabe" runat="server" CssClass="error"></asp:Label>
</asp:Content>
