using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PgSQL;

namespace WindowsFormsAppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool bDone = false;
            string sClause = "VALUES ('" + Environment.UserName + "')";
            int iCount = -1;
            GlobalClass.RowCount3("hi", "", ref iCount);
            MessageBox.Show("iCount= " + iCount.ToString(), "Message");
            //PgSQL.Task.TestRun("TestTable", sClause, ref bDone);
            MessageBox.Show("Hello " + Environment.UserDomainName + ", welcome to VS 2013","Message");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GlobalClass.OpenPGSQLDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalClass.ClosePgsSQLDB();
                this.Dispose();
                this.Close();
            }
            catch (Exception pEx)
            {
                MessageBox.Show(pEx.ToString(), "button2_Click");
            }
        }
    }
}
