using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using log4net.Config;
using System.Data;
using System.Data.SqlClient;
using EinkaufslisteV2.Models;


namespace EinkaufslisteV2
{
    public partial class _Default : Page
    {

        private DBConnection dbconnect = new DBConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader reader; //!< Rückgabe der Datenbankabfrage
        private static readonly ILog log = LogManager.GetLogger(typeof(_Default));
        protected void Page_Load(object sender, EventArgs e)
        {
            // Konfiguriere einfaches Logging für Log4Net. Ausgabe in Console.
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/log4net.config")));

            log.Debug("Starte Anwednung");
            dbconnect.BuildSQLConnectionString();
            dbconnect.OpenSQLConnection();
            cmd.Connection = dbconnect.con;

            if (!IsPostBack)
            {
                this.GetProdukte();
             }
        }

        /// <summary>
        /// Gebe Produkte aus und sortiere alphabetisch. 
        /// Organisiere die Produkte nach Kategorien.
        /// Selektiere bereits ausgewählte Produkte.
        /// </summary>
        //TODO: Produkte für Standardeinkauf auswählen
        //TODO: Produkte für Gelegenheiten ausblenden (wie z.B. Weihnachten)
        private void GetProdukte()
        {
            // Frage nach Status der DB Verbindung
            if (dbconnect.con.State == ConnectionState.Closed)
            {
                try
                {
                    dbconnect.con.Open();
                    // Holle alle Produkte für Einkaufsliste
                    cmd.CommandText = "SELECT * FROM produkt ORDER BY produktName";
                    reader = cmd.ExecuteReader();

                    // https://www.aspsnippets.com/Articles/Bind-CheckBoxList-from-Database-in-ASPNet.aspx

                    while (reader.Read())
                    {
                        ListItem item = new ListItem();

                        item.Text = reader["produktName"].ToString();
                        item.Value = reader["produktID"].ToString();

                        if (reader["ProduktWarenkorb"].ToString() == "True")
                        {
                            item.Selected = true;
                        }

                        string produktKategorie = reader["produktKategorie"].ToString();
                        switch (produktKategorie)
                        {
                            // Füge der Auswahlliste das Produkt hinzu
                            case "Grundnahrungsmittel":
                                Grundnahrungsmittel.Items.Add(item);
                                break;
                            case "Brot, Cerialien, etc.":
                                BrotEtc.Items.Add(item);
                                break;
                            case "Gemüse":
                                Gemuese.Items.Add(item);
                                break;
                            case "Obst":
                                Obst.Items.Add(item);
                                break;
                            case "Fisch, Fleisch & Vegi":
                                FischEtc.Items.Add(item);
                                break;
                            case "Käse, Eier & Milch":
                                KaeseEtc.Items.Add(item);
                                break;
                            case "Süßes":
                                Suesses.Items.Add(item);
                                break;
                            case "Getränke":
                                Getraenke.Items.Add(item);
                                break;
                            case "Haushalt & Katzen":
                                HaushaltEtc.Items.Add(item);
                                break;
                            case "Körperpflege":
                                Koerperpflege.Items.Add(item);
                                break;
                            default:
                                Sonstiges.Items.Add(item);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Fehler!!! " + ex.Message);
                    ausgabe.Text = "Ein Fehler ist aufgetreten: " + ex.Message;
                }
            }
            dbconnect.con.Close();
        }
        /// <summary>
        /// Speichere die ausgewählten Produkte im Warenkorb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SpeichereWarenkorb(object sender, EventArgs e)
        {

            // Aktualisiere Warenkorb
            cmd.CommandText = " UPDATE produkt SET produktWarenkorb = @IsSelected where produktId = @produktId";
            if (dbconnect.con.State == ConnectionState.Closed) dbconnect.con.Open();
            /// Gehe jede Produktliste durch und speichere den Einkauf in der Datenbank
            foreach (ListItem item in Grundnahrungsmittel.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            foreach (ListItem item in BrotEtc.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            foreach (ListItem item in Gemuese.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            foreach (ListItem item in Obst.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            foreach (ListItem item in FischEtc.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            foreach (ListItem item in KaeseEtc.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            foreach (ListItem item in Suesses.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            foreach (ListItem item in Getraenke.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            foreach (ListItem item in HaushaltEtc.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            foreach (ListItem item in Koerperpflege.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            foreach (ListItem item in Sonstiges.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsSelected", item.Selected);
                cmd.Parameters.AddWithValue("@produktId", item.Value);
                cmd.ExecuteNonQuery();
            }
            dbconnect.con.Close();
        }
    }
}