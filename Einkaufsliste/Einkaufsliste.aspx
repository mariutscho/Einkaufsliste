<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Einkaufsliste.aspx.cs" Inherits="Einkaufsliste.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <div id="globalNavi">
        <ul>
            <li><a href="default.aspx">Was brauche ich?</a></li>
            <li><a href="Einkaufsliste.aspx">Einkaufsliste</a></li>
        </ul>
    </div>
    <div id="content" class="pad20">
        <h1>Einkaufsliste</h1>
        <form id="form1" runat="server">
            <div id="Einkaufsliste">
                <%-- Alle Produkte anzeigen, gefiltert nach Markt und sortiert nach Produktstandort
                        TODO: Control um alle Checkboxen zu deaktivieren --%>
                <div class="einkaufMarkt">
                    <asp:GridView ID="EinkaufslisteAldi" runat="server"></asp:GridView>
                </div>
                <div class="einkaufMarkt">
                    <asp:GridView ID="EinkaufslisteRewe" runat="server"></asp:GridView>
                </div>
                <div class="einkaufMarkt">
                    <asp:GridView ID="EinkaufslisteDm" runat="server"></asp:GridView>
                </div>
                <asp:Label ID="ausgabe" runat="server" CssClass="error"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
