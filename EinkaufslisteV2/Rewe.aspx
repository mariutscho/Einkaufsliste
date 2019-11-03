<%@ Page Title="Einkaufsliste" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rewe.aspx.cs" Inherits="EinkaufslisteV2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="btn-group">
        <asp:Button ID="MarktAlle" runat="server" CssClass="btn btn-default" Text="Alle" OnClick="GeneriereEinkaufslisteMarkt" />       
        <asp:Button id="MarktAldi" runat="server" CssClass="btn btn-default" Text="Aldi" onclick="GeneriereEinkaufslisteMarkt" />  
        <asp:Button id="MarktRewe" runat="server" CssClass="btn btn-default" Text="Rewe" onclick="GeneriereEinkaufslisteMarkt" />        
        <asp:Button id="MarktDM" runat="server" CssClass="btn btn-default" Text="DM" onclick="GeneriereEinkaufslisteMarkt" />
    </div>
    <div class="clearfix">&nbsp;</div>
    <div class="btn-group" data-toggle="buttons">
        <asp:Panel ID="Einkaufsliste" runat="server"></asp:Panel>
    </div>
    <div class="clearfix">&nbsp;</div>
    <div class="btn-group">
        <asp:Button ID="DeleteItem" runat="server" Text="Produkte entfernen" OnClick="EntferneProduktVonEinkaufsliste" CssClass="btn btn-default" />
    </div>
    <asp:Label ID="ausgabe" runat="server" CssClass="error"></asp:Label>
</asp:Content>
