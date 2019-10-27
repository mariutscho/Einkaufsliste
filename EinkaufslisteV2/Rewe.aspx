<%@ Page Title="REWE" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rewe.aspx.cs" Inherits="EinkaufslisteV2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="einkaufMarkt">
        <!-- Filtern: Alle (default) Rewe Aldi

        <label class="radio-inline">
            <input type="radio" name="inlineRadioOptionen" id="MarktAlle" value="MarktAlle" onselect="GeneriereEinkaufsliste">
            Alle Märkte
        </label>
        <label class="radio-inline">
            <input type="radio" name="inlineRadioOptionen" id="MarktAldi" value="MarktAldi" onselect="GeneriereEinkaufsliste">
            Aldi
        </label>
        <label class="radio-inline">
            <input type="radio" name="inlineRadioOptionen" id="MarktRewe" value="MarktRewe" onselect="GeneriereEinkaufsliste">
            Rewe
        </label>
        <label class="radio-inline">
            <input type="radio" name="inlineRadioOptionen" id="MarktDM" value="MarktDM" onselect="GeneriereEinkaufsliste">
            DM
        </label>-->
    </div>
    <div class="btn-group" data-toggle="buttons">
        <asp:Panel ID="Einkaufsliste" runat="server"></asp:Panel>
    </div>
    <div class="row">
        <asp:Button ID="DeleteItem" runat="server" Text="Eingekaufte Produkte entfernen" OnClick="ClearWarenkorb" CssClass="btn btn-default" />
    </div>
    <asp:Label ID="ausgabe" runat="server" CssClass="error"></asp:Label>
</asp:Content>
