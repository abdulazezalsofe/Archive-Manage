using ArchifProjcet_2.Addition_pages;
using ArchifProjcet_2.DAL;
using ArchifProjcet_2.Properties;
using DevExpress.XtraDashboardLayout;
using DevExpress.XtraEditors.ColorPick.Picker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static ArchifProjcet_2.DBL.Tb_Categor;

namespace ArchifProjcet_2
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        #region Tools

        Add_Update_Category Add_Update;
        Add_Update_User _User;
        AddFill fill;
        public enum E_Pages { Main, Categore, User, Archive, Settings, Help }
        public E_Pages Pages = E_Pages.Main;

        #endregion 


        public Main()
        {
            InitializeComponent();
            //this.KeyPreview = true;
          
            this.KeyPreview = true;       
         

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Pages = E_Pages.Main;
            LoadHomeScreen();
            Homrbutton.Focus();
            panel5.Visible = false;
            this.table_and_Buttons_UserControl11.Visible = false;
        }


        #region Buttons Methods

        private void Userbutton_Click(object sender, EventArgs e)
        {
            Pages = E_Pages.User;
            settingsUserControl1.Visible = false;
            paneINfoHome.Visible = false;

            panel5.Visible = true;
            this.table_and_Buttons_UserControl11.Visible = true;
            this.table_and_Buttons_UserControl11.dataGridViewUserControl.DataSource = DBL.Tb_Users.ReadAllItems();
        }
        private void Categorbutton_Click_1(object sender, EventArgs e)
        {
            Pages = E_Pages.Categore;
            paneINfoHome.Visible = false;

            settingsUserControl1.Visible = false;

            panel5.Visible = true;
            this.table_and_Buttons_UserControl11.Visible = true;
            this.table_and_Buttons_UserControl11.dataGridViewUserControl.DataSource = DBL.Tb_Categor.ReadAllItems();
        }     
        private void AddItems_Click(object sender, EventArgs e)
        {
            switch (Pages)
            {
                case E_Pages.Categore:
                    {
                        Add_Update = new Add_Update_Category();
                        Add_Update.RefrechEvemt += RefrichEvent;
                        Add_Update.ShowDialog();
                    }
                    break;
                case E_Pages.User:
                    {
                        _User = new Add_Update_User();
                        _User.RefrechEvemt += RefrichEvent;
                        _User.ShowDialog();

                    }
                    break;
                case E_Pages.Archive:
                    {
                        fill = new AddFill();
                        fill.RefrechEvemt += RefrichEvent;
                        fill.ShowDialog();

                    }
                    break ;

            }



        }
        private void UpdateItemsButton_Click(object sender, EventArgs e)
        {
            switch (Pages)
            {
                case E_Pages.Categore:
                    {
                        UpdateCategor();
                    }
                    break;
                case E_Pages.User:
                    {
                        UpdateUser();
                    }
                    break;
                case E_Pages.Archive:
                    {
                        UpdateFill();
                    }
                    break;


            }



        }
        private void DeleteItemsButton_Click(object sender, EventArgs e)
        {
          

            switch (Pages)
            {
                case E_Pages.Categore:
                    {

                        int id = Convert.ToInt32(this.table_and_Buttons_UserControl11.dataGridViewUserControl
                              .Rows[this.table_and_Buttons_UserControl11.dataGridViewUserControl.CurrentRow.Index]
                              .Cells[0]
                              .Value);
                        CheckDeleteMessCategore(id);
                    }
                    break;
                case E_Pages.User:
                    {

                        int id = Convert.ToInt32(this.table_and_Buttons_UserControl11.dataGridViewUserControl
                              .Rows[this.table_and_Buttons_UserControl11.dataGridViewUserControl.CurrentRow.Index]
                              .Cells[0]
                              .Value);
                        CheckDeleteMessageUser(id);
                    }
                    break;
                case E_Pages.Archive:
                    {

                        int id = Convert.ToInt32(this.table_and_Buttons_UserControl11.dataGridViewUserControl
                              .Rows[this.table_and_Buttons_UserControl11.dataGridViewUserControl.CurrentRow.Index]
                              .Cells[0]
                              .Value);
                        CheckDeleteMessageFill(id);
                    }
                    break;


            }

        }
        private void PrintButtons_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void Homrbutton_Click_1(object sender, EventArgs e)
        {

            Pages = E_Pages.Main;
            LoadHomeScreen();
            settingsUserControl1.Visible = false;

            panel5.Visible = false;
            this.table_and_Buttons_UserControl11.Visible = false;
        }
        private void ArchiveButton_Click(object sender, EventArgs e)
        {

            Pages = E_Pages.Archive;
            paneINfoHome.Visible = false;

            settingsUserControl1.Visible = false;
            panel5.Visible = true;
            this.table_and_Buttons_UserControl11.Visible = true;
            this.table_and_Buttons_UserControl11.dataGridViewUserControl.DataSource = DBL.Tb_Archive.ReadAllItems(Settings.Default.ID);            
 
        }
        private void Settingbutton_Click(object sender, EventArgs e)
        {
            Pages = E_Pages.Settings;
            paneINfoHome.Visible = false;

            panel5.Visible = false;
            //panel4.BackColor = Color.FromArgb(11, 20, 58);
            //panel3.BackColor = Color.FromArgb(11, 20, 58);
            settingsUserControl1.Visible = true;

        }


        #endregion


        #region Process
        private void RefrichEvent(bool Refrish)
        {
            switch (Pages)
            {

                case E_Pages.Categore:
                    {
                        this.table_and_Buttons_UserControl11.dataGridViewUserControl.DataSource = DBL.Tb_Categor.ReadAllItems();

                    }
                    break;
                case E_Pages.User:
                    {
                        this.table_and_Buttons_UserControl11.dataGridViewUserControl.DataSource = DBL.Tb_Users.ReadAllItems();


                    }
                    break;
                case E_Pages.Archive:
                    {
                        this.table_and_Buttons_UserControl11.dataGridViewUserControl.DataSource = DBL.Tb_Archive.ReadAllItems(Settings.Default.ID);

                    }break;

            }

        }
        private void CheckDeleteMessCategore(int Id)
        {

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("هل انت متأكد من الحذف ", "رسالة تحذير ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                TB_Categurs tb = new TB_Categurs();
                tb.ID = Id;
                if (DBL.Tb_Categor.Savechang(tb, E_Mode.Delete))
                {
                    this.table_and_Buttons_UserControl11.dataGridViewUserControl.DataSource = DBL.Tb_Categor.ReadAllItems();
                    MessageBox.Show("لقد تم حذف العنصر بنجاح ", "تمت العملية ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toastNotificationsManager1.ShowNotification("eea4c9d2-14ea-4a2c-b823-6ac2d434f83a");
                }
                else
                {
                    MessageBox.Show("لقد فشلت عملية حذف العنصر ", "فشلت  العملية ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toastNotificationsManager1.ShowNotification("e26d9fee-3c3a-4f5e-8d8a-65a1a73171ad");
                }

            }
            else
            {

            }
        }
        private void UpdateCategor()
        {

            Add_Update = new Add_Update_Category();

            Add_Update.RefrechEvemt += RefrichEvent;

            int id = Convert.ToInt32(this.table_and_Buttons_UserControl11.dataGridViewUserControl.Rows[this.table_and_Buttons_UserControl11.dataGridViewUserControl.CurrentRow.Index].Cells[0].Value);
            Add_Update.tb = DBL.Tb_Categor.FindItemById(id);
            Add_Update.AddItems.Text = "تعديل ";
            Add_Update.Text = "تعديل ";

            Add_Update.e_mode = DAL.Tools.Mode.Update;
            Add_Update.AddItems.BackColor = Color.FromArgb(59, 130, 246);
            Add_Update.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.table_and_Buttons_UserControl11.dataGridViewUserControl.Width,
                            this.table_and_Buttons_UserControl11.dataGridViewUserControl.Height);

            this.table_and_Buttons_UserControl11.dataGridViewUserControl
                      .DrawToBitmap(bitmap, new Rectangle(0, 0, this.table_and_Buttons_UserControl11.dataGridViewUserControl.Width,
                       this.table_and_Buttons_UserControl11.dataGridViewUserControl.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);


        }
        private void CheckDeleteMessageUser(int Id)
        {

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("هل انت متأكد من الحذف ", "رسالة تحذير ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DAL.Tb_Users tb = new DAL.Tb_Users();
                tb.ID = Id;
                if (DBL.Tb_Users.Savechang(tb, DBL.Tb_Users.E_Mode.Delete))
                {
                    this.table_and_Buttons_UserControl11.dataGridViewUserControl.DataSource = DBL.Tb_Users.ReadAllItems();

                    MessageBox.Show("لقد تم حذف العنصر بنجاح ", "تمت العملية ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toastNotificationsManager1.ShowNotification("eea4c9d2-14ea-4a2c-b823-6ac2d434f83a");
                }
                else
                {
                    MessageBox.Show("لقد فشلت عملية حذف العنصر ", "فشلت  العملية ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toastNotificationsManager1.ShowNotification("e26d9fee-3c3a-4f5e-8d8a-65a1a73171ad");
                }

            }
            else
            {

            }

        }
        private void CheckDeleteMessageFill(int Id)
        {

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("هل انت متأكد من الحذف ", "رسالة تحذير ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DAL.Tb_TheFilles tb = new DAL.Tb_TheFilles();
                tb.ID = Id;
                if (DBL.Tb_Archive.Savechang(tb, DBL.Tb_Archive.E_Mode.Delete))
                {
                    this.table_and_Buttons_UserControl11.dataGridViewUserControl.DataSource = DBL.Tb_Archive.ReadAllItems(Settings.Default.ID);

                    MessageBox.Show("لقد تم حذف العنصر بنجاح ", "تمت العملية ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toastNotificationsManager1.ShowNotification("eea4c9d2-14ea-4a2c-b823-6ac2d434f83a");
                }
                else
                {
                    MessageBox.Show("لقد فشلت عملية حذف العنصر ", "فشلت  العملية ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toastNotificationsManager1.ShowNotification("e26d9fee-3c3a-4f5e-8d8a-65a1a73171ad");
                }

            }
            else
            {

            }
        }
        private void UpdateUser()
        {

            _User = new Add_Update_User();

            _User.RefrechEvemt += RefrichEvent;

            int id = Convert.ToInt32(this.table_and_Buttons_UserControl11.dataGridViewUserControl
                .Rows[this.table_and_Buttons_UserControl11.dataGridViewUserControl.CurrentRow.Index]
                .Cells[0]
                .Value);

            _User.obj = DBL.Tb_Users.FindItemById(id);
            _User.AddItems.Text = "تعديل ";
            _User.Text = "تعديل ";

            _User.e_mode = DAL.Tools.Mode.Update;
            _User.AddItems.BackColor = Color.FromArgb(59, 130, 246);
            _User.ShowDialog();
        }
        private void UpdateFill()
        {

            fill = new AddFill();

            fill.RefrechEvemt += RefrichEvent;

            int id = Convert.ToInt32(this.table_and_Buttons_UserControl11.dataGridViewUserControl.Rows[this.table_and_Buttons_UserControl11.dataGridViewUserControl.CurrentRow.Index].Cells[0].Value);
            fill.obj = DBL.Tb_Archive.FindItemById(id);
            fill.AddItems.Text = "تعديل ";
            fill.Text = "تعديل ";

            fill.e_mode = DAL.Tools.Mode.Update;
            fill.AddItems.BackColor = Color.FromArgb(59, 130, 246);
            fill.ShowDialog();
        }

        #endregion

       
        private void LoadHomeScreen()
        {
            paneINfoHome.Visible = true;
            labCategorName.Text =  Settings.Default.Category;
            labeFullName.Text = Settings.Default.FullName;
            labeRoleName.Text = Settings.Default.RoleName;
            labeSize.Text = DBL.Tb_Archive.GetTotalSizeFilesByUserID(Settings.Default.ID).ToString("N2") + " MB";
        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus)
            {
                AddItems.PerformClick();
            }
            else if (e.KeyCode == Keys.F5)
            {
                UpdateItemsButton.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteItemsButton.PerformClick();
            }
            else if (e.KeyCode == Keys.P && e.Control)
            {
                PrintButtons.PerformClick();
            }
        }
    }
}
