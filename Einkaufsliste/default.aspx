<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Einkaufsliste.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%-- TODO: Auslagerung von mehrmals verwendetem HTML Code --%>
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <div id="globalNavi">
        <ul>
            <li><a href="default.aspx">Was brauche ich?</a></li>
            <li><a href="Einkaufsliste.aspx">Einkaufsliste</a></li>
        </ul>
    </div>

    <div id="content">
        <form id="form1" runat="server">
            <div id="auswahlForm">
                <div class="produktKategorie produktKategorie1stBox">
                    <h1>Grundnahrungsmittel</h1>
                    <asp:CheckBoxList ID="Grundnahrungsmittel" runat="server"></asp:CheckBoxList>
                </div>
                <div class="produktKategorie">
                    <h1>Brot, Cerialien, etc.</h1>
                    <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
                    <asp:CheckBoxList ID="BrotEtc" runat="server"></asp:CheckBoxList>
                    <!-- https://stackoverflow.com/questions/873944/asp-net-display-selected-items-from-listbox-in-textbox -->
                </div>
                <div class="produktKategorie">
                    <h1>Gemüse</h1>
                    <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
                    <asp:CheckBoxList ID="Gemuese" runat="server"></asp:CheckBoxList>
                </div>
                <div class="produktKategorie">
                    <h1>Obst</h1>
                    <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
                    <asp:CheckBoxList ID="Obst" runat="server"></asp:CheckBoxList>
                </div>
                <div class="produktKategorie">
                    <h1>Fisch, Fleisch & Vegi</h1>
                    <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
                    <asp:CheckBoxList ID="FischEtc" runat="server"></asp:CheckBoxList>
                </div>
                <div class="produktKategorie">
                    <h1>Käse, Eier & Milch</h1>
                    <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
                    <asp:CheckBoxList ID="KaeseEtc" runat="server"></asp:CheckBoxList>
                </div>
                <div class="produktKategorie">
                    <h1>Süßes</h1>
                    <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
                    <asp:CheckBoxList ID="Suesses" runat="server"></asp:CheckBoxList>
                </div>
                <div class="produktKategorie">
                    <h1>Getränke</h1>
                    <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
                    <asp:CheckBoxList ID="Getraenke" runat="server"></asp:CheckBoxList>
                </div>
                <div class="produktKategorie">
                    <h1>Haushalt & Katzen</h1>
                    <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
                    <asp:CheckBoxList ID="HaushaltEtc" runat="server"></asp:CheckBoxList>
                </div>
                <div class="produktKategorie">
                    <h1>Körperpflege</h1>
                    <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
                    <asp:CheckBoxList ID="Koerperpflege" runat="server"></asp:CheckBoxList>
                </div>
                <div class="produktKategorie">
                    <h1>Sonstiges</h1>
                    <%-- Alle Produkte anzeigen, sortiert nach Kategorie --%>
                    <asp:CheckBoxList ID="Sonstiges" runat="server"></asp:CheckBoxList>
                </div>
            </div>
            <div id="submitForm">
                <asp:Button ID="Button2" runat="server" Text="Speichere Warenkorb" OnClick="SpeichereWarenkorb" />
            </div>
            <asp:Label ID="ausgabe" runat="server"></asp:Label>
        </form>
    </div>
</body>
</html>
