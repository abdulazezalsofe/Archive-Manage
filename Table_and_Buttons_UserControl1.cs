using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchifProjcet_2
{

    public partial class Table_and_Buttons_UserControl1 : DevExpress.XtraEditors.XtraUserControl
    {
       
        public Table_and_Buttons_UserControl1( )
        {
           
            InitializeComponent();
            //Load_Data(num);
        }

        private void dataGridViewUserControl_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUserControl.Columns[e.ColumnIndex].Name == "Password" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
                e.FormattingApplied = true;
            }

        }
    }
}
