using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using log4net.Config;
using System.Data;
using System.Data.SqlClient;
using EinkaufslisteV2.Models;

namespace EinkaufslisteV2
{
    public partial class NeuesProdukt : Page
    {
        private DBConnection dbconnect = new DBConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader reader; //!< Rückgabe der Datenbankabfrage
        private static readonly ILog log = LogManager.GetLogger(typeof(_Default));

        protected void Page_Load(object sender, EventArgs e)
        {
            dbconnect.BuildSQLConnectionString();
            dbconnect.OpenSQLConnection();
            GetAnzahlProdukte();
            // Verstecke 
            addProduct.Visible = false;
         

            if (!IsPostBack) {
            // Elemente für DropDown Liste anlegen
            Kategorie.Items.Add("Brot, Cerialien, etc.");
            Kategorie.Items.Add("Fisch, Fleisch & Vegi");
            Kategorie.Items.Add("Gemüse");
            Kategorie.Items.Add("Getränke");
            Kategorie.Items.Add("Grundnahrungsmittel");
            Kategorie.Items.Add("Haushalt & Katzen");
            Kategorie.Items.Add("Käse, Eier & Milch");
            Kategorie.Items.Add("Körperpflege");
            Kategorie.Items.Add("Obst");
            Kategorie.Items.Add("Sonstiges");
            Kategorie.Items.Add("Süßes");
            // Elemente für Optionsgruppe anlegen
            Markt.Items.Add("Aldi");
            Markt.Items.Add("DM");
            Markt.Items.Add("Rewe");
            }
        }

/// <summary>
/// Ermittle die Anzahl der vorhandenen Produkte in der Datenbank, um damit die neue ProduktID zu bestimmen.
/// </summary>
        public void GetAnzahlProdukte()
        {
            // TODO: Try-Catch einbauen
            cmd.CommandText = "SELECT COUNT(*) FROM Produkt";
             cmd.Connection = dbconnect.con;
                if (dbconnect.con.State == ConnectionState.Closed)
                {
                    dbconnect.con.Open();
                    Int32 count = (Int32)cmd.ExecuteScalar()+1;
                    produktanzahl.Value = Convert.ToString(count.ToString());
                    dbconnect.con.Close();
                }
        }

        public void AddProdukt(object sender, EventArgs e)
        {
            string produktName = Produkt.Text;
            string produktKategorie = Kategorie.SelectedValue;
            string produktMarkt = Markt.SelectedValue;
            string produktAnzahl = produktanzahl.Value;
            int x = Int32.Parse(produktanzahl.Value);

            try
            {
            // https://stackoverflow.com/questions/12142806/how-to-insert-records-in-database-using-c-sharp-language

                cmd.CommandText = "INSERT INTO Produkt (ProduktID, ProduktName, ProduktMarkt, ProduktKategorie) VALUES " +
                "('"+ x + "','" + produktName + "','" + produktMarkt + "','" + produktKategorie + "')";
                //Ausgabe.Text = cmd.CommandText;
                Ausgabe.Text = "Das Produkt wurde erfolgreich hinzugefügt";
                Ausgabe.CssClass = "bg-success";
                cmd.Connection = dbconnect.con;
                if (dbconnect.con.State == ConnectionState.Closed)
                {
                    dbconnect.con.Open();
                    cmd.ExecuteNonQuery();
                    dbconnect.con.Close();
                }

                LblProdukt.Visible = false;
                Produkt.Visible = false;
                LblMarkt.Visible = false;
                Markt.Visible = false;
                LblProduktkategorie.Visible = false;
                Kategorie.Visible = false;
                addProduct.Visible = true;
                Speichern.Visible = false;


            }
            catch(Exception ex)
            {
                log.Error("Fehler!!! " + ex.Message);
                Ausgabe.Text = "Ein Fehler ist aufgetreten: " + ex.Message + "Das SQL Statement ist: " + cmd.CommandText;
            }
        }

       


    }
}