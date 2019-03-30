using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace EinkaufslisteV2.Models
{
    public class DBConnection
    {
        //TODO DB Connection auslagern, da von mehreren Klassen verwendet
        #region ====== properties ======
        private static readonly ILog log = LogManager.GetLogger(typeof(DBConnection));
        private SqlConnectionStringBuilder conbuilder;
        public SqlConnection con;
        //public SqlCommand cmd;
        /// <summary>
        /// Baue Datenbankverbindung auf und lese Produkte aus
        /// </summary>
        /// <param name="sender">Page Objekt</param>
        /// <param name="e">Event</param>
        #endregion
        #region ====== methods =====
        public void BuildSQLConnectionString()
        {

            conbuilder = new SqlConnectionStringBuilder //! Verbindungsparameter initiieren
            {
               //TODO: Verbindungsparamenter in web.config auslagern
               //Verbindungsparameter zur lokalen Datenbank
                //DataSource = "maz-01\\sqlexpress",
                //InitialCatalog = "einkaufsliste",
                //IntegratedSecurity = true

                //Verbindungsparameter zur Azure Datenbank
                DataSource = "mariutscho.database.windows.net",
                InitialCatalog = "Einkaufsliste",
                PersistSecurityInfo = false,
                UserID = "SQLAdmin",
                Password = "Passw0rd!",
                MultipleActiveResultSets = false,
                Encrypt = true,
                TrustServerCertificate = false,
                ConnectTimeout = 30

                //Server=tcp:mariutscho.database.windows.net,1433;Initial Catalog=Einkaufsliste;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
            };

            log.Debug("Datenbankverbindung zu Server: " + conbuilder.DataSource + "und Datenbank: " + conbuilder.InitialCatalog);
        }

        public void OpenSQLConnection()
        {
            // Verbindung zur Datenbank öffnen
            con = new SqlConnection
            {
                ConnectionString = conbuilder.ConnectionString
            };

        }


        //public void PerformSQLQuery(string query)
        //{
        //    //
        //    cmd.Connection = con;
        //    cmd = new SqlCommand();
        //    //{
        //    //    CommandText = query
        //    //}; //!< Abfrage an Datenbank
        //}

        public void CloseSQLConnection()
        {
            con.Close();
        }
        #endregion
    }
}