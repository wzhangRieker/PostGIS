using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Npgsql;
//using System.Data;

namespace PgSQL
{
    public class Task
    {

        public Task()
        {
        }

        //DB objects
        //private static NpgsqlConnection m_pPgsConn = null;
        //private static NpgsqlCommand m_pPgsCmd = null;
        //private static NpgsqlConnection m_pPgsConn2 = null;
        //private static NpgsqlCommand m_pPgsCmd2 = null;

        //Open PGSQLDB connection
        //private static void OpenPGSQLDB(bool bTwo)
        //{
        //    try
        //    {
        //        m_pPgsCmd = m_pPgsConn.CreateCommand();
        //        if (!bTwo) return;
        //        m_pPgsConn2 = m_pPgsConn.Clone();
        //        m_pPgsCmd2 = m_pPgsConn2.CreateCommand();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "OpenPGSQLDB()");
        //    }
        //}

        //private static void ClosePgsSQLDB(bool bTwo)
        //{
        //    try
        //    {
        //        if (m_pPgsConn.State != ConnectionState.Closed) m_pPgsConn.Close();
        //        m_pPgsConn.Dispose();
        //        m_pPgsCmd.Dispose();
        //        m_pPgsConn = null;
        //        m_pPgsCmd = null;
        //        if (bTwo)
        //        {
        //            if (m_pPgsConn2.State != ConnectionState.Closed) m_pPgsConn2.Close();
        //            m_pPgsConn2.Dispose();
        //            m_pPgsCmd2.Dispose();
        //            m_pPgsConn2 = null;
        //            m_pPgsCmd2 = null;
        //        }
        //        GC.Collect();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "ClosePgsSQLDB()");
        //    }
        //}

        public static void TestRun(string sTable, string sClause, ref bool bDone)
        {
            try
            {
                bDone = false;
                //m_pStartTime = DateTime.Now;
                //m_iTable = iTable;
                //m_iVLDTask = iVLDTask;
                //m_bSelectAllProv = bSelectAllProv;
                //m_sSelectedProv = sSelectedProv;
                //DecideTask();
                int iWork = 0;
                string sError="";
                //string sClause = "VALUES ('" + sSAbbr + "', " + iTable.ToString() + ", '" + m_sVLDTable + "', '" + Environment.UserName + "')";
                GlobalClass.InsertRow(sTable, sClause, ref iWork, ref sError);
                if (sError != "")
                    MessageBox.Show(sError, "TestRun 0");

                //labStatus.Text = "Validate " + m_sVLDTable + " for " + sSAbbr + "...";
                //labStatus.Refresh();
                //GlobalClass.WriteLog(pStreamWriter, sLogFilePath, labStatus.Text, false);
                //if (bTruncate)
                //{
                //    GlobalClass.TruncateTable(m_sRLTTarget);
                //    GlobalClass.TruncateTable(m_sNotUsedTarget);
                //    GlobalClass.ExecuteNonQueryCannotT("VACUUM \"" + m_sRLTTarget + "\"", ref iWork);
                //    GlobalClass.ExecuteNonQueryCannotT("VACUUM \"" + m_sNotUsedTarget + "\"", ref iWork);
                //}
                //int iUpdated = 0;
                //int iVLDUnlg = 0;
                //CreateUnloggedVldRltUsedVOidViewLookup(sSAbbr, sSFips, ref pStreamWriter, sLogFilePath, ref labStatus, ref iVLDUnlg);

                //if (bProgressBar)
                //{
                //    progressBarStatus.Minimum = 0;
                //    progressBarStatus.Maximum = m_sIdentityTables.Length;
                //    progressBarStatus.Refresh();
                //}
                //GlobalClass.ReturnPgsConn(ref m_pPgsConn);
                //OpenPGSQLDB(false);
                //int iSubI = 0;
                //int iSubW = 0;
                //m_iRLTWork = 0;
                //for (int j = 0; j < m_sIdentityTables.Length; j++)
                //{
                //    if (bProgressBar)
                //    {
                //        progressBarStatus.Value = j + 1;
                //        progressBarStatus.Refresh();
                //    }
                //    Application.DoEvents();
                //    if (m_bCTR || (m_bFccOkla && !m_bFccOklaWLess)) if (j == m_sIdentityTables.Length - 1) goto NextOne;
                //    if (m_bMOS || (m_bFccOkla && m_bFccOklaWLess)) if (j != m_sIdentityTables.Length - 1) goto NextOne;

                //    if (!GlobalClass.TableExists3(m_sIdentityTables[j])) goto NextOne;
                //    iSubI = 0;
                //    InsertStateIdentity(j, sSAbbr, sSFips, ref pStreamWriter, sLogFilePath, ref iSubI, bUseES_State);

                //    if (iSubI < 1 && !bUseES_State) goto NextOne;
                //    iSubW = 0;
                //    if (j > 1) InsertStateService(j, sSAbbr, sSFips, ref pStreamWriter, sLogFilePath, ref iSubW, bUseES_State);

                //    if (bSelectAllProv) ExtractProvidersNotInLookUp(j, sSAbbr);
                //    ExtractRLTWorkTable(sSAbbr, ref pStreamWriter, sLogFilePath, j, iVLDUnlg);
                //NextOne:
                //    if (bDoAll)
                //    {
                //        if (m_iVLDTask == Convert.ToInt32(m_sS_V_R_T_P_TableNumber[1]) - 1)
                //        {
                //            GlobalClass.DropTable(m_sIdentityUnlogged[j]);
                //            if (j > 1) GlobalClass.DropTable(m_sServiceUnlogged[j]);
                //        }
                //    }
                //    else if (bDropS_State)
                //    {
                //        GlobalClass.DropTable(m_sIdentityUnlogged[j]);
                //        if (j > 1) GlobalClass.DropTable(m_sServiceUnlogged[j]);
                //    }
                //}
                ////GlobalClass.WriteLog(pStreamWriter, sLogFilePath, "The number of rows inserted into " + m_sRLTWorkUnlg + " is " + m_iRLTWork.ToString(), false);
                //if (m_bCTR || m_bMOS)
                //    UpdateCtrMos(ref iUpdated, sSAbbr, ref pStreamWriter, sLogFilePath);
                //else if (m_bF477)
                //    UpdateF477(ref iUpdated, sSAbbr, ref pStreamWriter, sLogFilePath);
                //else if (m_bFccOkla)
                //    UpdateFccOklaSPD(ref iUpdated, sSAbbr, ref pStreamWriter, sLogFilePath);
                ////bool bTest = true;
                ////if (bTest) goto KeepUnlg;
                //InsertIntoNotUsed(sSAbbr, ref pStreamWriter, sLogFilePath);
                //InsertIntoRLT(sSAbbr, ref pStreamWriter, sLogFilePath);

                //m_sIdentityTables = GlobalClass.DeriveNodeValue("IDENTITY_TABLES", "name").Split(';');
                //m_sServiceTables = GlobalClass.DeriveNodeValue("SERVICE_TABLES", "name").Split(';');
                //DropUnloggedTableView();
                ////KeepUnlg:
                //ClosePgsSQLDB(false);
                //if (bSelectAllProv) OutProviderNotInLookUp(ref pStreamWriter, sLogFilePath);
                //sClause = "\"" + m_sRunningTaskColumn[0] + "\"='" + sSAbbr + "' AND \"" + m_sRunningTaskColumn[1] + "\"=" + iTable.ToString();
                //GlobalClass.DeleteRows3(m_sVTaskTable, sClause, ref iWork);
                //GlobalClass.ExecuteNonQueryCannotT("VACUUM \"" + m_sVTaskTable + "\"", ref iWork);
                //GlobalClass.RuntimeDuration(ref pStreamWriter, sLogFilePath, ref m_pStopTime, m_pStartTime);
                bDone = true;
            }
            catch (Exception ex)
            {
                //GlobalClass.DeleteRows3(m_sVTaskTable, "\"" + m_sRunningTaskColumn[0] + "\"='" + sSAbbr +
                //    "' AND \"" + m_sRunningTaskColumn[1] + "\"=" + iTable.ToString(), ref iTable);
                MessageBox.Show(ex.ToString(), "TestRun");
            }
        }

    }
}
