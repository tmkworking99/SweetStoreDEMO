using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace sweetstoreDEMO
{
    public partial class Form1 : Form
    {
        protected DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            //string query = "select * from BANHNGOT where id = @id";
            //dt = DataProvider.Instance.ExecuteQuery(query, new object[] { "001" });

            //string query = "select * from BANHNGOT";
            //dt = DataProvider.Instance.ExecuteQuery(query);
            //dgv.DataSource = dt;

            //BUS method
        }
    }
}
