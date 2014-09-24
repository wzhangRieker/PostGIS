using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.Data;

namespace PgSQL
{
    public class GlobalClass
    {
        private static string m_sResource = "Resource.xml";
        //private static string[] m_sAccumulationFields = GlobalClass.DeriveNodeValue("ACCUMULATION_FIELDS", "name").Split(',');
        //private static string m_sSA = DeriveNodeValue("STATEABBR", "name");
        private static string m_sPGSQLConnction = DeriveNodeValue("POSQCONNECTION", "string");
        //private static string m_sRunningTaskTable = DeriveNodeValue("RUNNING_TASKS", "name");
        //private static string[] m_sRunningTaskColumn = DeriveNodeValue("RUNNING_TASKS_COLUMN", "name").Split(';');
        private static NpgsqlConnection m_pPgsConn = null;
        private static NpgsqlCommand m_pPgsCmd = null;

        public GlobalClass()
        {
        }

        //Open PGSQLDB connection
        public static void OpenPGSQLDB()
        {
            try
            {
                m_pPgsConn = new NpgsqlConnection(m_sPGSQLConnction);
                if (m_pPgsConn.State != ConnectionState.Open)
                    m_pPgsConn.Open();
                m_pPgsCmd = m_pPgsConn.CreateCommand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "OpenPGSQLDB()");
            }
        }

        //Get a connection
        public static void ReturnPgsConn(ref NpgsqlConnection pPgsConn)
        {
            try
            {
                pPgsConn = m_pPgsConn.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ReturnPgsConn");
            }
        }

        //Close PgsSQLDB connection
        public static void ClosePgsSQLDB()
        {
            try
            {
                if (m_pPgsConn.State != ConnectionState.Closed) m_pPgsConn.Close();
                m_pPgsConn.Dispose();
                m_pPgsCmd.Dispose();
                m_pPgsConn = null;
                m_pPgsCmd = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ClosePgsSQLDB()");
            }
        }

        public static void InsertRow(string sTable, string sClause, ref int iInsert, ref string sError)
        {
            try
            {
                NpgsqlTransaction pPgsTrans = m_pPgsConn.BeginTransaction();
                string sSQLCommand = "INSERT INTO \"" + sTable + "\" " + sClause;
                m_pPgsCmd.CommandText = sSQLCommand;
                try
                {
                    iInsert = m_pPgsCmd.ExecuteNonQuery();
                    //MessageBox.Show(iInsert.ToString(), "iInsert.ToString()");
                }
                catch (Exception pEx)
                {
                    sError = pEx.Message;
                }
                finally
                {
                    ReleaseTransaction(ref pPgsTrans);
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                //MessageBox.Show(ex.ToString(), "InsertRow");
            }
        }

        public static void RowCount3(string sTable, string sWhereClause, ref int iCount)
        {
            try
            {
                NpgsqlTransaction pPgsTrans = m_pPgsConn.BeginTransaction();
                string sSQLCommand = "SELECT COUNT(*) FROM \"" + sTable + "\"" + sWhereClause;
                m_pPgsCmd.CommandText = sSQLCommand;
                iCount = Convert.ToInt32(m_pPgsCmd.ExecuteScalar());
                //MessageBox.Show(iCount.ToString(), "iCount.ToString()");
                ReleaseTransaction(ref pPgsTrans);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "RowCount3");
            }
        }

        public static void ReleaseTransaction(ref NpgsqlTransaction pPgsTrans)
        {
            try
            {
                pPgsTrans.Commit();
                pPgsTrans.Dispose();
                pPgsTrans = null;
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ReleaseTransaction");
            }
        }

        public static string DeriveNodeValue(string sKey, string sAttr)
        {
            try
            {
                string sResFile = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + m_sResource;
                //MessageBox.Show(sResFile, "sResFile");
                XmlTextReader pResReader = new XmlTextReader(sResFile);
                while (pResReader.Read())
                {
                    if (pResReader.NodeType == XmlNodeType.Element)
                    {
                        if (pResReader.Name == sKey)
                        {
                            string sWork = pResReader.GetAttribute(sAttr);
                            pResReader.Close();
                            return sWork;
                        }
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "DeriveNodeValue");
                return "";
            }
        }
    }
}
