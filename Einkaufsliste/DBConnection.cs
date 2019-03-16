using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace Einkaufsliste
{
    public class DBConnection
    {
        //TODO DB Connection auslagern, da von mehreren Klassen verwendet
        #region ====== properties ======
        private static readonly ILog log = LogManager.GetLogger(typeof(DBConnection));
        private SqlConnectionStringBuilder conbuilder;
        public SqlConnection con;
        public SqlCommand cmd;
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
                // Verbindungsparameter zur Datenbank
                // TODO: Verbindungsparamenter in web.config auslagern
                DataSource = "maz-01\\sqlexpress",
                InitialCatalog = "einkaufsliste",
                IntegratedSecurity = true
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