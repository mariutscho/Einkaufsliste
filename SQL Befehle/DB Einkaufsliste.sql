
/* einkaufsliste.sql 
*
* Einrichten der Datenbank EINKAUFSLISTE inkl. der Datensätzen für die Anwendung Einkaufsliste
* Autor: Mario Zimmermann
* Datum: 18.11.2018
* 
DROP database EINKAUFSLISTE;

*/

 CREATE database EINKAUFSLISTE;

 Use EINKAUFSLISTE;

 CREATE TABLE Produkt (
 produktID int NOT NULL,
 produktName varChar (50),
 produktKategorie varChar(50),
 produktMarkt varChar(20),
 produktRangfolge char(8),
 produktPreis decimal(10,2),
 produktWarenkorb bit,
 PRIMARY KEY (produktID)
 )


 /*
 CREATE TABLE Einkauf (
 einkaufDatum datetime,
 einkaufWarenkorb text
 ),produktRangfolge,produktKategorie


 */

/*NSERT into Produkt (produktID,produktName,produktMarkt,produktRangfolge,produktKategorie) values ('0001','Nussecke','Aldi','al00500','Standard');*/

SELECT * FROM produkt
