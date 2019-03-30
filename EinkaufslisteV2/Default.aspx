<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EinkaufslisteV2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-3">
            <h3>Brot, Cerialien, etc.</h3>
            <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
            <div class="checkbox">
                <asp:CheckBoxList ID="BrotEtc" runat="server"></asp:CheckBoxList>
                <!-- https://stackoverflow.com/questions/873944/asp-net-display-selected-items-from-listbox-in-textbox -->
            </div>
        </div>
        <div class="col-md-3">
            <h3>Fisch, Fleisch & Vegi</h3>
            <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
            <div class="checkbox">
                <asp:CheckBoxList ID="FischEtc" runat="server"></asp:CheckBoxList>
            </div>
        </div>
        <div class="col-md-3">
            <h3>Gemüse</h3>
            <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
            <div class="checkbox">
                <asp:CheckBoxList ID="Gemuese" runat="server"></asp:CheckBoxList>
            </div>
        </div>
                <div class="col-md-3">
            <h3>Getränke</h3>
            <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
            <div class="checkbox">
                <asp:CheckBoxList ID="Getraenke" runat="server"></asp:CheckBoxList>
            </div>
        </div>
        <div class="col-md-3">
            <h3>Grundnahrungsmittel</h3>
             <div class="checkbox">
                <asp:CheckBoxList ID="Grundnahrungsmittel" runat="server"></asp:CheckBoxList>
            </div>
        </div>
        <div class="col-md-3">
            <h3>Obst</h3>
            <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
            <div class="checkbox">
                <asp:CheckBoxList ID="Obst" runat="server"></asp:CheckBoxList>
            </div>
        </div>

        <div class="col-md-3">
            <h3>Haushalt & Katzen</h3>
            <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
            <div class="checkbox">
                <asp:CheckBoxList ID="HaushaltEtc" runat="server"></asp:CheckBoxList>
            </div>
        </div>
        <div class="col-md-3">
            <h3>Käse, Eier & Milch</h3>
            <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
            <div class="checkbox">
                <asp:CheckBoxList ID="KaeseEtc" runat="server"></asp:CheckBoxList>
            </div>
        </div>
        <div class="col-md-3">
            <h3>Körperpflege</h3>
            <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
            <div class="checkbox">
                <asp:CheckBoxList ID="Koerperpflege" runat="server"></asp:CheckBoxList>
            </div>
        </div>
        <div class="col-md-3">
            <h3>Sonstiges</h3>
            <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
            <div class="checkbox">
                <asp:CheckBoxList ID="Sonstiges" runat="server"></asp:CheckBoxList>
            </div>
        </div>
        <div class="col-md-3">
            <h3>Süßes</h3>
            <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
            <div class="checkbox">
                <asp:CheckBoxList ID="Suesses" runat="server"></asp:CheckBoxList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-30">
            <asp:Button ID="Button2" runat="server" Text="Warenkorb speichern" OnClick="SpeichereWarenkorb" CssClass="btn btn-default" />
            <input onclick="clear_form_elements(this.form)" type="button" value="Formular zurücksetzen" class="btn btn-default"/> 
        </div>
    </div>
    
    <asp:Label ID="ausgabe" runat="server"></asp:Label>

<%--      <div class="btn-group" data-toggle="buttons">
    <asp:PlaceHolder ID="test" runat="server"></asp:PlaceHolder>
          </div>--%>

</asp:Content>
