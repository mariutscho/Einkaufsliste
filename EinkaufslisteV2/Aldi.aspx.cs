﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace EinkaufslisteV2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Models.DBConnection dbconnect = new Models.DBConnection();
        private SqlCommand cmdListe = new SqlCommand(); //!< Abfrage an Datenbank
        private SqlDataReader readerListe; //!< Rückgabe der Datenbankabfrage
        private static readonly ILog log = LogManager.GetLogger(typeof(WebForm1));
        protected void Page_Load(object sender, EventArgs e)
        {
            dbconnect.BuildSQLConnectionString();
            dbconnect.OpenSQLConnection();
             EinkaufslisteGenerieren();
        }
        private void EinkaufslisteGenerieren()
        {
            try
            {
                // TODO: Unterscheide nach Markt und gebe in zwei Tabellen aus
                // Generiere Warenkorb sortiert nach Srandort der Produkte im Regal
                cmdListe.CommandText = "SELECT produktName, produktMarkt, produktPreis FROM Produkt WHERE produktWarenkorb = 'TRUE' ORDER BY produktRangfolge";
                cmdListe.Connection = dbconnect.con;
                // Frage nach Status der DB Verbindung
                if (dbconnect.con.State == ConnectionState.Closed)
                {
                    dbconnect.con.Open();
                    log.Debug("Datenbankabfrage für Einkaufsliste wird gestellt");
                    readerListe = cmdListe.ExecuteReader();
                    // https://stackoverflow.com/questions/15829079/how-to-bind-dataset-with-gridview
                    log.Debug("Daten werden an das Table Control gebunden");
                    EinkaufslisteAldi.DataSource = readerListe;
                    DataBind();
                    readerListe.Close();
                    dbconnect.con.Close();
                    //TODO Ausgabe für Print optimieren
                }

            }
            ///<exception cref="ex">Einkaufsliste erstellen</exception>
            catch (Exception ex)
            {
                log.Error("Fehler!!! " + ex.Message);
                ausgabe.Font.Bold = true;
                ausgabe.Text = ex.Message;
            }
        }
    }
}