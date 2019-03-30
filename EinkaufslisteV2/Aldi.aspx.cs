using System;
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
        private SqlCommand cmdAldi = new SqlCommand(); //!< Abfrage an Datenbank
        private SqlDataReader readerAldi; //!< Rückgabe der Datenbankabfrage
        private static readonly ILog log = LogManager.GetLogger(typeof(WebForm1));
        protected void Page_Load(object sender, EventArgs e)
        {
            dbconnect.BuildSQLConnectionString();
            dbconnect.OpenSQLConnection();
             EinkaufslisteGenerierenAldi();
        }
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
    }
}