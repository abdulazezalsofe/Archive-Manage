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
    public partial class SettingsUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public SettingsUserControl()
        {
            InitializeComponent();
        }

        private void SettingsUserControl_Load(object sender, EventArgs e)
        {
            labUserName.Text = Properties.Settings.Default.UserName;
            labRoleName.Text = Properties.Settings.Default.RoleName;
            labFullName.Text = Properties.Settings.Default.FullName;
            labCategory.Text = Properties.Settings.Default.Category;
            labAddDate.Text = Properties.Settings.Default.AddDate;
            labeSize.Text = DBL.Tb_Archive.GetTotalSizeFilesByUserID(Properties.Settings.Default.ID).ToString("N2") + " MB";


        }

      
    }
}
