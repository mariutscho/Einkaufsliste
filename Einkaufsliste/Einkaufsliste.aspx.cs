using System;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace Einkaufsliste
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        //TODO DB Connection auslagern, da von mehreren Klassen verwendet
        private DBConnection dbconnect = new DBConnection();
        //private SqlConnection conAldi = new SqlConnection(); //!< Verbindung zur Datenbank
        //private SqlConnection conRewe = new SqlConnection(); //!< Verbindung zur Datenbank
        //private SqlConnection conDm = new SqlConnection(); //!< Verbindung zur Datenbank
        private SqlCommand cmdAldi = new SqlCommand(); //!< Abfrage an Datenbank
        //private SqlCommand cmdRewe = new SqlCommand(); //!< Abfrage an Datenbank
        //private SqlCommand cmdDm = new SqlCommand(); //!< Abfrage an Datenbank
        private SqlDataReader readerAldi; //!< Rückgabe der Datenbankabfrage
        //private SqlDataReader readerRewe; //!< Rückgabe der Datenbankabfrage
        //private SqlDataReader readerDm; //!< Rückgabe der Datenbankabfrage
        private static readonly ILog log = LogManager.GetLogger(typeof(WebForm2));

        protected void Page_Load(object sender, EventArgs e)
        {

            dbconnect.BuildSQLConnectionString();
            dbconnect.OpenSQLConnection();
            //cmdAldi.Connection = dbconnect.con;
            //cmdRewe.Connection = dbconnect.con;
            //cmdDm.Connection = dbconnect.con;

            // Übergebe Verbdingung für SQL Abfrage
            //cmd.Connection = con;
            EinkaufslisteGenerierenAldi();
            //EinkaufslisteGenerierenRewe();
            //EinkaufslisteGenerierenDm();
        }

        /// <summary>Gebe alle ausgewählten Produkte aus und sortiere sie nach Produktstandort pro Markt.</summary>
        private void EinkaufslisteGenerierenAldi()
        {
            try
            {
                // TODO: Unterscheide nach Markt und gebe in zwei Tabellen aus
                // Generiere Warenkorb sortiert nach Srandort der Produkte im Regal
                cmdAldi.CommandText = "SELECT produktName, produktMarkt, produktPreis FROM Produkt WHERE produktWarenkorb = 'TRUE' ORDER BY produktRangfolge";
                cmdAldi.Connection = dbconnect.con;
                // Frage nach Status der DB Verbindung
                if (dbconnect.con.State == ConnectionState.Closed)
                {
                    dbconnect.con.Open();
                    log.Debug("Datenbankabfrage für Einkaufsliste wird gestellt");
                    readerAldi = cmdAldi.ExecuteReader();
                    // https://stackoverflow.com/questions/15829079/how-to-bind-dataset-with-gridview
                    log.Debug("Daten werden an das Table Control gebunden");
                    EinkaufslisteAldi.DataSource = readerAldi;
                    DataBind();
                    readerAldi.Close();
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
        
        //private void EinkaufslisteGenerierenRewe()
        //{
        //    try
        //    {
        //        // Generiere Warenkorb sortiert nach Srandort der Produkte im Regal
        //        cmdRewe.CommandText = "SELECT produktName, produktMarkt, produktPreis FROM Produkt WHERE produktWarenkorb = 'TRUE' AND produktMarkt='REWE' ORDER BY produktRangfolge";
        //        cmdRewe.Connection = con;
        //        // Frage nach Status der DB Verbindung
        //        if(dbconnect.con.State == ConnectionState.Closed)
        //        {
        //            dbconnect.con.Open();
        //            log.Debug("Datenbankabfrage für Einkaufsliste wird gestellt");
        //            readerRewe = cmdRewe.ExecuteReader();
        //            // https://stackoverflow.com/questions/15829079/how-to-bind-dataset-with-gridview
        //            log.Debug("Daten werden an das Table Control gebunden");
        //            EinkaufslisteRewe.DataSource = readerRewe;
        //            DataBind();
        //            readerRewe.Close();
        //            con.Close();
        //            //TODO Ausgabe für Print optimieren
        //        }
        //    }
        //    ///<exception cref="ex">Einkaufsliste erstellen</exception>
        //    catch (Exception ex)
        //    {
        //        log.Error("Fehler!!! " + ex.Message);
        //        ausgabe.Font.Bold = true;
        //        ausgabe.Text = ex.Message;
        //    }
        //}
        //private void EinkaufslisteGenerierenDm()
        //{
        //    try
        //    {
        //        // Generiere Warenkorb sortiert nach Srandort der Produkte im Regal
        //        cmdDm.CommandText = "SELECT produktName, produktMarkt, produktPreis FROM Produkt WHERE produktWarenkorb = 'TRUE' AND produktMarkt='DM' ORDER BY produktRangfolge";
        //        cmdDm.Connection = con;
        //        // Frage nach Status der DB Verbindung
        //        if (dbconnect.con.State == ConnectionState.Closed)
        //        {
        //            dbconnect.con.Open();
        //            log.Debug("Datenbankabfrage für Einkaufsliste wird gestellt");
        //            readerDm = cmdDm.ExecuteReader();
        //            // https://stackoverflow.com/questions/15829079/how-to-bind-dataset-with-gridview
        //            log.Debug("Daten werden an das Table Control gebunden");
        //            EinkaufslisteDm.DataSource = readerDm;
        //            DataBind();
        //            readerDm.Close();
        //            con.Close();
        //            //TODO Ausgabe für Print optimieren
        //        }

        //    }
        //    ///<exception cref="ex">Einkaufsliste erstellen</exception>
        //    catch (Exception ex)
        //    {
        //        log.Error("Fehler!!! " + ex.Message);
        //        ausgabe.Font.Bold = true;
        //        ausgabe.Text = ex.Message;
        //    }
        //}
    }
}