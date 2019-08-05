///<summary>
///
/// # Hintergrund
/// Im Laufe einer Woche werden alle notwendigen Produkte im Haushalt auf einem Einkaufszettel notiert. Dabei werden die Produkte
/// weder strukturiert noch in einer bestimmten Reihenfolge notiert. Dadurch zieht sich der Einkauf in die Länge weil die Produkte
/// nach Markt und Standort herausgesucht werden müssen. 
/// 
/// # Benutzerschnittstellen
/// Die funktionalen Anforderungen der vollständigen Erfassung der Produkte und die Ausgabe in einer für den Einkauf optimierten Liste werden
/// zwei Masken abgebildet. 
/// </summary>
namespace EinkaufslisteV2
{
}
/// <summary>
/// ## Datenerfassung
/// Die Erfassungs-Maske gliedert die Produkte in einer Klassifikation von Nahrungsmitteln und Haushaltsprodkten zur einfacheren Auswahl für den 
/// Benutzer. 
/// 
/// ## Datenausgabe
/// Die Datenausgabe filter die Produkte nach Markt und ordnet diese in eine Rangfolge abhängig vom Standort des Produktes.
/// 
/// # Datenmodel
/// Besteht aus einer Eintität "Produkt" mit den Eigenschaften ID, Name, Markt, Rangfolge und Preis
/// 
/// # Funktionen
/// Speichern der ausgewählten Daten.
/// Sortierung der Ausgewählten Daten nach Markt und Standort
/// </summary>
/// 
