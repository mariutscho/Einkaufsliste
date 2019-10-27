using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using log4net;
using EinkaufslisteV2.View;

namespace EinkaufslisteV2
{
    public partial class Contact : Page
    {
        private Models.DBConnection dbconnect = new Models.DBConnection();
        private SqlCommand cmdListe = new SqlCommand(); //!< Abfrage an Datenbank
        private SqlDataReader readerListe; //!< Rückgabe der Datenbankabfrage
        private static readonly ILog log = LogManager.GetLogger(typeof(WebForm1));
        protected void Page_Load(object sender, EventArgs e)
        {
            dbconnect.BuildSQLConnectionString();
            dbconnect.OpenSQLConnection();
          
            generiereEinkaufsliste();
            
        }
        /// <summary>
        /// Einkaufsliste mit Produkten aus REWE generieren
        /// </summary>
        private void generiereEinkaufsliste()
        {
            try
            {
                // Generiere Warenkorb sortiert nach Standort der Produkte im Regal
                // TODO: Unterscheide nach Markt
                // RequestForm Objekt  holen

                // DEFAULT: wenn nicht markiert oder "MarktAlle": Alle Produkte ausgeben
                cmdListe.CommandText = "SELECT produktID, produktName, produktMarkt, produktPreis FROM Produkt WHERE produktWarenkorb = 'TRUE' ORDER BY produktRangfolge";

                //"MarktAldi" als Optionsfeld ausgewählt
                //if (inlineRadioOptionen == "MarktAldi")
                //cmdListe.CommandText = "SELECT produktID, produktName, produktMarkt, produktPreis FROM Produkt WHERE produktWarenkorb = 'TRUE' AND produktMarkt = 'Aldi' ORDER BY produktRangfolge";

                //"MarktRewe" als Optionsfeld ausgewählt

                //"MarktDM" als Optionsfeld ausgewählt

                cmdListe.Connection = dbconnect.con;
                // Frage nach Status der DB Verbindung
                if (dbconnect.con.State == ConnectionState.Closed)
                {
                    dbconnect.con.Open();
                    log.Debug("Datenbankabfrage für Einkaufsliste wird gestellt");
                    readerListe = cmdListe.ExecuteReader();
                    // https://stackoverflow.com/questions/15829079/how-to-bind-dataset-with-gridview
                    log.Debug("Daten werden an das Table Control gebunden");
                    
                    while (readerListe.Read())
                    {

                        //HtmlGenericControl input = new HtmlGenericControl("input");
                
                        //input.InnerText = readerListe["produktName"].ToString();
                        //input.Attributes.Add("value", readerListe["produktName"].ToString());
                        //input.Attributes.Add("type", "checkbox");
                        //input.Attributes.Add("autocomplete", "off");

                        // http://holdirbootstrap.de/javascript/#buttons
                        // das auf Bootstrap Code passt.
                        //https://www.codeproject.com/articles/25573/building-asp-net-web-pages-dynamically-in-the-code
                        // HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                        //Einkaufsliste.Controls.Add(input);
                        CheckboxButton checkboxButton = new CheckboxButton();
                        String HtmlElement = checkboxButton.GetElements(readerListe["produktName"].ToString(), readerListe["produktID"].ToString());
                        Einkaufsliste.Controls.Add(new LiteralControl(HtmlElement));
                    }
                    //EinkaufslisteRewe.DataSource = readerListe;
                    //DataBind();
                    readerListe.Close();
                    dbconnect.con.Close();
                    //TODO: zurückgestellt: Ausgabe für Print optimieren
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

        public void ClearWarenkorb(object sender, EventArgs e)
        {
            try
            {
                //(fachlich: Das Produkt ist im Einkaufswagen und kann von der Einkaufsliste 
                // entfernt werden.


                //https://docs.microsoft.com/en-us/dotnet/api/system.web.httprequest.form?view=netframework-4.8

                var formParameter = Request.Form;
                var i = 0;

                // FOREACH (checkbox IS checked)
                foreach (string param in formParameter)
                {

                    var formWert = Request.Form.GetKey(i);
                    var formValue = Request.Form.GetValues(formWert);
                    
                    //var Form8 = Form[8];
                    //-Form    { __EVENTTARGET = &__EVENTARGUMENT = &__VIEWSTATE = ZcVA % 3d % 3d & __VIEWSTATEGENERATOR = 58A9F7E8 & __EVENTVALIDATION = ZsvOg % 3d % 3d & 5 = on & 10 = on & 17 = on & ctl00 % 24MainContent % 24DeleteItem = Eingekaufte + Produkte + entfernen}
                    //System.Collections.Specialized.NameValueCollection { System.Web.HttpValueCollection}
                    if (formValue[0] == "on") { 
                    
                        cmdListe.CommandText = " UPDATE produkt SET produktWarenkorb = 0 where produktId =" + formWert;
                        if (dbconnect.con.State == ConnectionState.Closed) dbconnect.con.Open();
                        cmdListe.ExecuteNonQuery();

                        // UPDATE item to set flag Warenkorb = false
                        //ausgabe.Text = "checkbox aktiv ist im Request-Objekt: " + param;
                    }
                    else
                    {
                        //ausgabe.Text = "Nix gefunden";
                    }
                    i++;

                }
                Response.Redirect(Request.RawUrl);


            }
            catch (Exception ex)
            {
                log.Error("Fehler!!! " + ex.Message);
                ausgabe.Font.Bold = true;
                ausgabe.Text = ex.Message;
            }
        }
    }
}